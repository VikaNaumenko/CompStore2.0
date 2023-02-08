using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Orders> Orders { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set;}

    }
}
