using System;
using System.Collections.Generic;

namespace Project1{
    public class Inventory{
        public static void ListProducts(List<Product> products){
            if (products.Count >= 1)
            {
                Console.WriteLine("---- LIST OF PRODUCTS ---");
                foreach (Product product in products)
                {
                    Console.WriteLine(product);
                    Console.WriteLine("***********");
                }
                Console.WriteLine("------------------------");
            }
            else
                Console.WriteLine("---- THERE ARE NO PRODUCTS! ---");
        }

        public static bool FindProductById(int id, List<Product> products, out Product product, out int index) {
            product = null;
            index = -1;
            if (id <= 0)
                return false;

            for (int i = 0; i < products.Count; i++){
                if (products[i].Id == id){
                    product = products[i];
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public static void UpdateStock(int id, int stock, List<Product> products){
            try
            {
                if (FindProductById(id, products, out Product product, out int index)){
                    if (stock >= 0){
                        products[index].Stock = stock;
                        Console.WriteLine("Product Updated!");
                        Console.WriteLine(products[index]);
                    }else
                        Console.WriteLine("Stock must be greater than or equal to 0!");
                }else
                    Console.WriteLine("Product not found!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error trying to update product!");
            }
        }
    }
}