using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public Product()
        {
            Name = "Product";
            Price = 0.00M;
            Quantity = 0;
            Description = "A Product";
        }
    }
}
