using eCommerce;
using NUnit.Framework;
using System;

[TestFixture]
public class ProductIDTests
{
    [Test]
    public void ProductID_Valid_Test()
    {
        // Arrange
        int validID = 4999;

        // Act
        var product = new Product(validID, "Test Product", 100, 65);

        // Assert
        Assert.That(product.ProductID, Is.EqualTo(validID));
    }

    [Test]
    public void ProductID_LessThanMinimum_Test()
    {
        // Arrange
        int invalidID = 0;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(invalidID, "Test Product", 100, 66));
        Assert.That(ex.ParamName, Is.EqualTo("productId"));
    }

    [Test]
    public void ProductID_GreaterThanMaximum_Test()
    {
        // Arrange
        int invalidID = 10001;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(invalidID, "Test Product", 100, 70));
        Assert.That(ex.ParamName, Is.EqualTo("productId"));
    }
}
[TestFixture]
public class ProductNameTests
{
    [Test]
    public void ProductName_Valid_Test()
    {
        // Arrange
        string validName = "Test";

        // Act
        var product = new Product(1, validName, 100, 70);

        // Assert
        Assert.That(product.ProductName, Is.EqualTo(validName));
    }

    [Test]
    public void ProductName_Null_Test()
    {
        // Act & Assert
        var ex = Assert.Throws<ArgumentNullException>(() => new Product(1, null, 100, 60));
        Assert.That(ex.ParamName, Is.EqualTo("productName"));
    }

    [Test]
    public void ProductName_EmptyString_Test()
    {
        // Arrange
        string emptyName = "";

        // Act
        var product = new Product(1, emptyName, 100, 56);

        // Assert
        Assert.That(product.ProductName, Is.EqualTo(emptyName));
    }
}
[TestFixture]
public class PriceTests
{
    [Test]
    public void Price_Valid_Test()
    {
        // Arrange
        decimal validPrice = 2000;

        // Act
        var product = new Product(1, "Test Product", validPrice, 54);

        // Assert
        Assert.That(product.Price, Is.EqualTo(validPrice));
    }

    [Test]
    public void Price_LessThanMinimum_Test()
    {
        // Arrange
        decimal invalidPrice = 0;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", invalidPrice, 50));
        Assert.That(ex.ParamName, Is.EqualTo("price"));
    }

    [Test]
    public void Price_GreaterThanMaximum_Test()
    {
        // Arrange
        decimal invalidPrice = 5001;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", invalidPrice, 80));
        Assert.That(ex.ParamName, Is.EqualTo("price"));
    }
}
[TestFixture]
public class StockTests
{
    [Test]
    public void Stock_Valid_Test()
    {
        // Arrange
        int validStock = 50000;

        // Act
        var product = new Product(1, "Test Product", 100, validStock);

        // Assert
        Assert.That(product.Stock, Is.EqualTo(validStock));
    }

    [Test]
    public void Stock_LessThanMinimum_Test()
    {
        // Arrange
        int invalidStock = 0;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 100, invalidStock));
        Assert.That(ex.ParamName, Is.EqualTo("stock"));
    }

    [Test]
    public void Stock_GreaterThanMaximum_ShouldThrowException()
    {
        // Arrange
        int invalidStock = 100001;

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Product(1, "Test Product", 100, invalidStock));
        Assert.That(ex.ParamName, Is.EqualTo("stock"));
    }
}
[TestFixture]
public class IncreaseStockTests
{
    [Test]
    public void IncreaseStock_ValidCount_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);
        int increasecount = 10;

        // Act
        product.IncreaseStockCount(increasecount);

        // Assert
        Assert.That(product.Stock, Is.EqualTo(60));
    }

    [Test]
    public void IncreaseStock_NegativeCount_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStockCount(-10));
        Assert.That(ex.ParamName, Is.EqualTo("count"));
    }

    [Test]
    public void IncreaseStock_Zerocount_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);
        int increasecount = 0;

        // Act
        product.IncreaseStockCount(increasecount);

        // Assert
        Assert.That(product.Stock, Is.EqualTo(50));
    }
}
[TestFixture]
public class DecreaseStockTests
{
    [Test]
    public void DecreaseStock_ValidCount_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);
        int decreasecount = 10;

        // Act
        product.DecreaseStockCount(decreasecount);

        // Assert
        Assert.That(product.Stock, Is.EqualTo(40));
    }

    [Test]
    public void DecreaseStock_NegativeCount_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);

        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStockCount(-10));
        Assert.That(ex.ParamName, Is.EqualTo("count"));
    }

    [Test]
    public void DecreaseStock_MoreThanStock_Test()
    {
        // Arrange
        var product = new Product(1, "Test Product", 100, 50);

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => product.DecreaseStockCount(60));
        Assert.That(ex.Message, Is.EqualTo("Insufficient stock."));
    }
        // Test for constructor
        [Test]
        public void Product_Constructor_ValidData()
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
        public void IncreaseStock_ValidAmount()
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
        public void IncreaseStock_NegativeAmount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_ValidAmount()
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
        public void DecreaseStock_NegativeAmount()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(-10));
        }

        [Test]
        public void DecreaseStock_MoreThanStock()
        {
            // Arrange
            var product = new Product(1, "Test Product", 100, 50);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(60));
        }
    }
}

