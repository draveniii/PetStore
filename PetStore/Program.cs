using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using Models;
using Logic;

namespace PetStore
{

    internal class Program
    {
        static void Main()
        {
            IServiceProvider services = CreateServiceCollection();

            var productLogic = services.GetService<IProductLogic>();

            // Header
            Console.WriteLine("PET STORE INVENTORY");
            Console.WriteLine("-------------------");

            string userInput;

            // While the user has not input "exit"
            do
            {

                // Menu options
                Console.WriteLine("\n1. Add a product.");
                Console.WriteLine("2. Find a product by name.");
                Console.WriteLine("3. Display Products in stock.");
                Console.WriteLine("4. Display current price of inventory.");
                Console.WriteLine("5. Quit.\n");

                // Gets user menu input
                userInput = Console.ReadLine()!;

                switch (userInput)
                {
                    // Adds a product to _product List
                    case "1":
                        // Creates a new CatFood object
                        CatFood catFood = new();

                        // Adds product to productLogic list
                        productLogic.AddProduct(catFood);
                        Console.WriteLine("The Product has been added!");
                        break;

                    // Searches for a particular product by name and if the product is not found return null
                    case "2":
                        Console.WriteLine("Enter the Name of the product you're looking for:");

                        string productLookUp = Console.ReadLine()!;

                        // If the GetProductByName returns null the product has not been found
                        if (productLogic.GetProductByName(productLookUp) == null)
                        {
                            Console.WriteLine("Product not found.");
                        }
                        else
                        {
                            Console.WriteLine(JsonSerializer.Serialize(productLogic.GetProductByName(productLookUp)));

                        }
                        break;

                    // Gets all products with a quantity of 1 or greater (otherwise all products in stock
                    case "3":
                        List<string> inStockProducts = productLogic.GetOnlyInStockProducts();

                        Console.WriteLine("Current Products in Stock:");
                        Console.WriteLine("--------------------------");
                        foreach (string name in inStockProducts)
                        {
                            Console.WriteLine($"{name}");
                        }

                        break;

                    // Gets the current price of all products in stock
                    case "4":
                        decimal costOfInventory = productLogic.GetTotalPriceOfInventory();

                        Console.WriteLine($"Total Price of Inventory: ${costOfInventory}");

                        break;
                };

            } while (userInput != "5");
        }

        static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
                .AddTransient<ProductLogic, ProductLogic>()
                .BuildServiceProvider();
        }
    }


}
