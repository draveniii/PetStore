using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Logic
{
    public interface IProductLogic
    {
        void AddProduct(Product product);

        List<Product> GetAllProducts();

        Product GetProductByName(string name);

        List<string> GetOnlyInStockProducts();

        decimal GetTotalPriceOfInventory();
    }
}
