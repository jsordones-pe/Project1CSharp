using System;

namespace Project1
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public Product(int id, string name, float price, int stock)
        {
            if (price <= 0)
                throw new ArgumentException("Price cannot be negative or equal to 0.");
            if (stock < 0)
                throw new ArgumentException("Stock cannot be negative.");
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

        public override string ToString(){
            return $"Name: {Name}\nPrice: {Price}\nStock: {Stock}";
        }
        
    }
}