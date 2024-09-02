using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductLogic : IProductLogic
    {
        // Member Data
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashProducts;
        private Dictionary<string, CatFood> _catFoodProducts;

        // Constructor
        public ProductLogic()
        {
            _products = new();
            _dogLeashProducts = new();
            _catFoodProducts = new();

            CatFood catFood = new()
            {
                Name = "Nutrish",
                Price = 10.00M,
                Quantity = 0,
                Description = "Healthy Cat Food",
                WeightPounds = 5       
            };

            DogLeash dogLeash = new()
            {
                Name = "Walkings",
                Price = 5.00M,
                Quantity = 5,
                Description = "Stretchy Leash",
                LenghtInches = 72
            };

            _products.Add(dogLeash);
            _products.Add(catFood);
            _catFoodProducts.Add(catFood.Name, catFood);
            _dogLeashProducts.Add(dogLeash.Name, dogLeash);
        }

        // Adds the given product to the products list and either the DogLeashProducts and CatFoodProducts
        // dictionary depending on the type of product
        public void AddProduct(Product product)
        {

            // Try catch here
            try
            {
                if (product == null)
                {
                    throw new Exception("Null object.");
                }
                else if (product is DogLeash)
                {
                    _dogLeashProducts.Add(product.Name, product as DogLeash);
                    _products.Add(product);
                }
                else if (product is CatFood)
                {
                    _catFoodProducts.Add(product.Name, product as CatFood);
                    _products.Add(product);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // Returns the list of all products
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        // Returns a product with a matching Name or null if no matching product is found
        public Product GetProductByName(string name)
        {
            if (_dogLeashProducts.ContainsKey(name))
            {
                return _dogLeashProducts[name];
            }
            else if (_catFoodProducts.ContainsKey(name))
            {
                return _catFoodProducts[name];
            }
            else
            {
                return null;
            }
        }

        // Returns a list of names of the products currently in stock
        public List<string> GetOnlyInStockProducts()
        {
            return _products.InStock().Select(x => x.Name).ToList();
        }

        // Returns the price of all items currently in stock
        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(x => x.Price).Sum();
        }
    }
}
