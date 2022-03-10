using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
