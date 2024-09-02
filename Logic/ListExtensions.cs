using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    internal static class ListExtensions
    {
        // Returns a list of items if that item has a Quantity of 1 or more. Item must have a "Quantity member"
        public static List<T> InStock<T>(this List<T> list) where T : Product
        {
            return list.Where(x => x.Quantity > 0).ToList();
        }
    }
}
