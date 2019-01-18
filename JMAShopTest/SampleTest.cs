using JMAShop.Models;
using System;
using Xunit;

namespace JMAShopTest
{
    public class SampleTest
    {
        [Fact]
        public void CanUpdateItemPrice()
        {
            // Arrange
            var item = new Item { Name = "Sample Item", Price = 12.95M };
            // Act
            item.Price = 20M;
            //Assert
            Assert.Equal(20M, item.Price);
        }

        [Fact]
        public void CanUpdateItemName()
        {
            // Arrange
            var item = new Item { Name = "Sample Item", Price = 12.95M };
            // Act
            item.Name = "Another item";
            //Assert
            Assert.Equal("Another item", item.Name);
        }
    }
}
