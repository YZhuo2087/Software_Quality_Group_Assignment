using eCommerce;
using NUnit.Framework;
using System;

namespace eCommerce.Tests
{
    [TestFixture]
    public class ProductTests
    {
        // Test for constructor
        [Test]
        public void Product_Constructor_ValidData_ShouldCreateProduct()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            decimal price = 100;
            int stock = 50;

            // Act
            var product = new Product(id, name, price, stock);

            // Assert
            Assert.That(product.ProductID, Is.EqualTo(id));
            Assert.That(product.ProductName, Is.EqualTo(name));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Stock, Is.EqualTo(stock));
        }

        // Tests for IncreaseStock method
        [Test]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);
            int increaseAmount = 10;

            // Act
            product.IncreaseStock(increaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(60));
        }

        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);
            int decreaseAmount = 10;

            // Act
            product.DecreaseStock(decreaseAmount);

            // Assert
            Assert.That(product.Stock, Is.EqualTo(40));
        }

        [Test]
        public void DecreaseStock_NegativeAmount_ShouldThrowException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_MoreThanStock_ShouldThrowException()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(60));
        }
    }
}