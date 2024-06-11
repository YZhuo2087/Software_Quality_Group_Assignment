using NUnit.Framework;
using System;

namespace eCommerce.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ValidParameters_ShouldSetProperties()
        {
            // Arrange
            int productId = 1;
            string productName = "Test Product";
            decimal price = 10.0m;
            int stock = 100;

            // Act
            var product = new Product(productId, productName, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(productId));
            Assert.That(product.ProductName, Is.EqualTo(productName));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Stock, Is.EqualTo(stock));
        }

        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 100);
            int increaseAmount = 10;

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(110));
        }

        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 100);
            int decreaseAmount = 10;

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(90));
        }

        [Test]
        public void Constructor_InvalidProductID_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(0, "Test Product", 10.0m, 100));
        }

        [Test]
        public void Constructor_InvalidPrice_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 0.0m, 100));
        }

        [Test]
        public void Constructor_InvalidStock_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 10.0m, 100001));
        }

        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 100);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_NegativeAmount_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 100);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_AmountGreaterThanStock_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 10.0m, 100);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(101));
        }
    }
}
