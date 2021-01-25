using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.Controllers;
using WebApplication.Models;
using Xunit;

namespace WebApplication.Tests
{
    public class ProductControllerTest
    {

        [Fact]
        public void GetProductByIdTests()
        {
            // Arrange 
            Mock<IProductRepository> productReposytoryMock = new Mock<IProductRepository>(); // nagrane zachowanie obiektu Product
            productReposytoryMock.Setup(x => x.Products).Returns(new Product[] { 
            new Product {ProductID = 1, Name = "P1"},
              new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            }.AsQueryable<Product>());
           
            var controller = new ProductController(productReposytoryMock.Object);
            // Act
           var result = controller.GetById(1);
            Product product = result.ViewData.Model as Product;


            //Assert
            Assert.Equal("P1", product.Name);




        }



        [Theory]
        [InlineData(1,"P1")]
        [InlineData(2, "P2")]
        public void GetProductByIdTests2(int id, string expectName)
        {
            // Arrange 
            Mock<IProductRepository> productReposytoryMock = new Mock<IProductRepository>(); // nagrane zachowanie obiektu Product
            productReposytoryMock.Setup(x => x.Products).Returns(new Product[] {
            new Product {ProductID = 1, Name = "P1"},
              new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            }.AsQueryable<Product>());

            var controller = new ProductController(productReposytoryMock.Object);
            // Act
            var result = controller.GetById(id);
            Product product = result.ViewData.Model as Product;


            //Assert
            Assert.Equal(expectName, product.Name);




        }








    }
}
