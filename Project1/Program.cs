using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sw = true;
            List<Product> products = new List<Product>();
            Console.WriteLine("Welcome to the inventory!");
            while (sw){
                Console.WriteLine();
                Console.WriteLine("1. Show products");
                Console.WriteLine("2. Add a product");
                Console.WriteLine("3. Find a product by ID");
                Console.WriteLine("4. Update stock product");
                Console.WriteLine("5. Close program");
                Console.WriteLine("");

                if(!ValidateInt("Please choose an option!", out int option))
                    Console.WriteLine("Error, you must put a valid number!");
                else{
                    switch (option){
                        case 1:
                            Inventory.ListProducts(products);
                        break;

                        case 2:
                            Product product = CreateProduct(products);
                            if (product != null){
                                products.Add(product);
                                Console.WriteLine("Product added successfully!");
                            }
                            else
                                Console.WriteLine("Error, product not added!");
                        break;

                        case 3:
                            if(Inventory.CountList(products) >= 1){
                                if (ValidateInt("Enter the product ID", out int id)){
                                    if (Inventory.FindProductById(id, products, out Product prod, out int index))
                                        prod.ShowInfo();
                                    else
                                        Console.WriteLine("Product not found!");
                                }else
                                    Console.WriteLine("Error, invalid ID!");
                            }else
                                Console.WriteLine("---- THERE ARE NOT PRODUCTS! ---");
                        break;

                        case 4:
                            if(Inventory.CountList(products) >= 1){
                                if (ValidateInt("Enter the product ID", out int id2)){
                                    if (Inventory.FindProductById(id2, products, out Product prod, out int index)){
                                        if (ValidateInt("Enter the new stock", out int stock))
                                            Inventory.UpdateStock(id2, stock, products);
                                        else
                                            Console.WriteLine("Error, invalid stock!");
                                    }else
                                        Console.WriteLine("Product not found!");
                                }else
                                    Console.WriteLine("Error, invalid ID!");
                            }else
                                Console.WriteLine("---- THERE ARE NOT PRODUCTS! ---");
                        break;

                        case 5:
                            sw = false;
                        break;

                        default:
                            Console.WriteLine("Choose a correct option please");
                        break;
                    }
                }
            }
            Console.WriteLine("GoodBye!");

        }

        public static bool ValidateInt(string message, out int num) {
            num = int.MinValue;
            try
            {
                Console.Write($"{message}: ");
                num = Convert.ToInt32(Console.ReadLine());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateFloat(string message, out float num){
            num = float.MinValue;
            try
            {
                Console.Write($"{message}: ");
                num = Convert.ToSingle(Console.ReadLine());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidateString(string message, out string cad){
            try
            {
                Console.Write($"{message}: ");
                cad = Console.ReadLine();
                if (!string.IsNullOrEmpty(cad) && cad != "Error" && cad != "Exception")
                    return true;
                cad = "Error";
                return false;
            }
            catch (Exception)
            {
                cad = "Exception";
                return false;
            }
        }

        public static Product CreateProduct(List<Product> products){
            if (ValidateString("Enter the name", out string name) && ValidateFloat("Enter the price", out float price) && ValidateInt("Enter the stock", out int stock)){
                try{
                    int id = Inventory.CountList(products);
                    return Product.CreateProduct(id + 1, name, price, stock);
                }catch (Exception){
                    return null;
                }
            }
            return null;
        }
        
    }
}
