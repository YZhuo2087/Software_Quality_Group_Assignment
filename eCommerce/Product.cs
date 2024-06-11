using System;

namespace eCommerce
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productID, string productName, decimal price, int stock)
        {
            if (productID < 1 || productID > 10000)
                throw new ArgumentOutOfRangeException(nameof(productID), "ProductID must be between 1 and 10000.");
            if (price < 1 || price > 5000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be between 1 and 5000.");
            if (stock < 1 || stock > 100000)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be between 1 and 100000.");

            ProductID = productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            Stock += amount;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive.");
            if (Stock - amount < 0)
                throw new InvalidOperationException("Stock cannot be negative.");
            Stock -= amount;
        }
    }
}
