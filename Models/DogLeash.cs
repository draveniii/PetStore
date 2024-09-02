using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DogLeash : Product
    {
        public int LenghtInches { get; set; }

        public DogLeash()
        {
            Name = "Dog Leash";
            Price = 0.00M;
            Quantity = 0;
            Description = "Leash for dog";
            LenghtInches = 0;
        }
    }
}
