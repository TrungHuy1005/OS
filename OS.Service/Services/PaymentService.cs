using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using OS.Application.Interfaces;
using OS.Application.ViewModels;
using OS.Data.Context;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Service.Services
{
    public class PaymentService : BaseService,IPaymentService
    {
        public PaymentService(IDbContextFactory<OnlineShopDbContext> dbContextFactory, IMapper mapper) : base(dbContextFactory, mapper)
        {
        }
        public string Payment(Bill bill,List<CartProductViewModel> carts,List<ProductViewModel> products)
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "";
            foreach(var item in carts)
            {
                ProductViewModel product = products.Where(t => t.Id == item.ProductId).FirstOrDefault();
                orderInfo += product.Name + " , ";

            }
            string returnUrl = "https://localhost:44394/";
            string notifyurl = "http://ba1adf48beba.ngrok.io/Payment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = bill.Total.ToString();
            string orderid = DateTime.Now.Ticks.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MomoSecurity crypto = new MomoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return jmessage.GetValue("payUrl").ToString();
        }
        public List<Bill> GetAllInvoice()
        {
            var context = _dbContextFactory.CreateDbContext();
            List<Bill> bills = context.Bill.ToList();
            return bills;
        }    
        public List<CartProductViewModel> GetAllCartByBill(Bill bill)
        {
            var context = _dbContextFactory.CreateDbContext();
            List<CartProduct> carts= context.CartProduct.Where(t => t.BillId == bill.Id).ToList();
            return _mapper.Map<List<CartProductViewModel>>(carts);
        }
    }
}
