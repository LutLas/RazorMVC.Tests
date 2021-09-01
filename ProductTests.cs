using RazorMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Diagnostics;

namespace RazorMVC.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Arrange
            var p = new Product { Name = "Test",Description= "Test Description", Category= "Test Category", Price = 100M };
            // Act
            p.Name = "New Name";
            //Assert
            Assert.Equal("New Name", p.Name);
        }
        [Fact]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "Test Description", Category = "Test Category", Price = 100M };
            // Act
            p.Price = 200M;
            //Assert
            Assert.Equal(200M, p.Price);
        }
        [Fact]
        public void CanChangeProductDescription()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "Test Description", Category = "Test Category", Price = 100M };
            // Act
            p.Description = "New Description";
            //Assert
            Assert.Equal("New Description", p.Description);
        }
        [Fact]
        public void CanChangeProductCategory()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "Test Description", Category = "Test Category", Price = 100M };
            // Act
            p.Category = "New Category";
            //Assert
            Assert.Equal("New Category", p.Category);
        }
    }
}
