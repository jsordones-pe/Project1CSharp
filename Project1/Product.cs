using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Project1
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, float price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Product() { }

        public static Product CreateProduct(int id, string name, float price, int stock)
        {
            return new Product(id, name, price, stock);
        }

        public void ShowInfo(){
            Console.WriteLine($"Id: {Id} - Name: {Name} - Price: {Price} - Stock: {Stock}");
        }
        
    }
}