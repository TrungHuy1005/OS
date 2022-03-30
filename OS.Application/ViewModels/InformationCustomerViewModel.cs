using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Application.ViewModels
{
    public class InformationCustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        public string MethodPayment { get; set; }
    }
}
