using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Application.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
    }
}
