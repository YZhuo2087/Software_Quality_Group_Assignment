using System;

namespace eCommerce
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product(int productId, string productName, decimal price, int stock)
        {
            if (productId < 1 || productId > 10000)
                throw new ArgumentOutOfRangeException(nameof(productId), "ProductID must be between 1 and 10000.");
            if (productName == null)
                throw new ArgumentNullException(nameof(productName), "ProductName cannot be null.");
            if (price < 1 || price > 5000)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be between $1 and $5000.");
            if (stock < 1 || stock > 100000)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock must be between 1 and 100000.");
            
            ProductID = productId;
            ProductName = productName;
            Price = price;
            Stock = stock;
        }

        public void IncreaseStockCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");
            Stock += count;
        }

        public void DecreaseStockCount(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");
            if (Stock - count < 0)
                throw new InvalidOperationException("Insufficient stock.");
            Stock -= count;
        }
    }
}
