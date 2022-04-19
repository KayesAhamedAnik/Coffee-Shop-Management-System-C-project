using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CoffeeShop.Entity
{
    public class Sale
    {
        public int id { get; set; }
        public float bill { get; set; }
        public float vat { get; set; }
        public string time { get; set; }
        public String details { get; set; }
    }
}
