using System.Diagnostics;
using System.Xml.Linq;

namespace Models
{
    public class CatFood : Product
    {
        public double WeightPounds { get; set; }

        public CatFood()
        {
            Name = "Cat Food";
            Price = 0.00M;
            Quantity = 0;
            Description = "Food for cat";
            WeightPounds = 0;
        }
    }
}
