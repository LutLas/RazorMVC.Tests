using Microsoft.AspNetCore.Mvc;
using Moq;
using RazorMVC.Controllers;
using RazorMVC.Models;
using System.Collections.Generic;
using Xunit;

namespace RazorMVC.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository {
            public IEnumerable<Product> Products { get; set; }
            public void AddProduct(Product p) {
                // do nothing - not required for test
            }
        }
        [Theory]
        /*[InlineData(275, 48.95, 19.50, 24.95)]
        [InlineData(5, 48.95, 19.50, 24.95)]*/
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price && p1.Description == p2.Description && p1.Category == p2.Category));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
            .Returns(new[] { new Product { Name = "P1", Price = 100 } });
            var controller = new HomeController { Repository = mock.Object };
            // Act
            var result = controller.Index();
            // Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
