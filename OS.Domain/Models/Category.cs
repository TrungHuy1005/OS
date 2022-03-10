using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; }
        [ForeignKey(nameof(Employee))]
        public int? EmployeeId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Employee Employee { get; set; }

    }
}
