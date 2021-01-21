using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : Controller
    {

        private IProductRepository repository;
        public ApiProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }


        [HttpGet]
        public IEnumerable<Product> Get() => repository.Products;


        [HttpGet("{ProductId}")]
        public Product Get(int ProductId) => repository.Products.FirstOrDefault(p => p.ProductID == ProductId);


       [HttpPost]
        public void Post([FromBody] Product product) => 
            repository.SaveProduct(product);


      
        [HttpPut]
        public void Put([FromBody] Product product) =>
            repository.SaveProduct(product);



        [HttpDelete("{ProductId}")]

        public void Delete(int ProductId) => repository.DeleteProduct(ProductId);





    }
}
