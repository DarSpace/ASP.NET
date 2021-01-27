using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.Controllers;
using WebApplication.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EditProductTests()
        {

            // Arrange 
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                }.AsQueryable<Product>());

            AdminController target = new AdminController(mock.Object);


            // Act
            Product p1 = GetViewModel<Product>(target.Edit(1));
            Product p2 = GetViewModel<Product>(target.Edit(2));
            Product p3 = GetViewModel<Product>(target.Edit(3));
            Product p4 = GetViewModel<Product>(target.Edit(4));

            // Assert
            Assert.Equal(1, p1.ProductID);
            Assert.Equal(2, p2.ProductID);
            Assert.Equal(3, p3.ProductID);
            Assert.Equal(4, p4.ProductID);
        }


        [Fact]
        public void EditNonexistentProduct()
        {
            // Arrange 
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
            new Product {ProductID = 1, Name = "P1"},
            new Product {ProductID = 2, Name = "P2"},
            new Product {ProductID = 3, Name = "P3"},
            }.AsQueryable<Product>());
            AdminController target = new AdminController(mock.Object);


            // Act
            Product result = GetViewModel<Product>(target.Edit(5));

            // Assert
            Assert.Null(result);

        }








            private Test GetViewModel<Test>(IActionResult result) where Test : class
            {
                    return (result as ViewResult).ViewData.Model as Test;

             }




    }
}
