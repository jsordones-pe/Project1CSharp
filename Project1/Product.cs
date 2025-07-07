using System;

namespace Project1
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, decimal price, int stock){
            if (price <= 0)
                throw new ArgumentException("Price cannot be negative or equal to 0.");
            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.");

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string ToString(){
            return $"ID: {Id}\nName: {Name}\nPrice: {Price.ToString("C")}\nStock: {Stock}";
        }
        
    }
}