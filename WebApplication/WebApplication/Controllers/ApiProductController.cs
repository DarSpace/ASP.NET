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

        /// <summary>
        /// Pobranie listy produktów 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public ActionResult<Product> GetProducts()
        {

            var products = repository.Products;
            if (products == null)
                return NotFound();
            return Ok(products);
            // public IEnumerable<Product> GetProducts() => repository.Products;
        }

        /// <summary>
        /// pobranie pojedynczego produktu po ID 
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        [HttpGet("{ProductId}")]

        public ActionResult<Product> GetProduct(int ProductId)
        {

         var product = repository.Products.FirstOrDefault(p => p.ProductID == ProductId);
            if (product == null)
                return NotFound();
            return Ok(product);
            //   public Product Get(int ProductId) => repository.Products.FirstOrDefault(p => p.ProductID == ProductId);
        }




        /// <summary>
        /// Dodanie produktu
        /// </summary>
        /// <param name="product"></param>
       [HttpPost]

    public ActionResult<Product> SaveProduct(Product product)
        {
            repository.SaveProduct(product);
            return Ok(product);
        }
        //public void Post([FromBody] Product product) =>
        //repository.SaveProduct(product);
       








        /// <summary>
        /// Edycja produktu 
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]

        public ActionResult<Product> Edit(Product product)
        {
            repository.SaveProduct(product);
            return Ok(product);
        }

        //public void Put([FromBody] Product product) =>
        //    repository.SaveProduct(product);
       






        /// <summary>
        /// Usunięcie produktu 
        /// </summary>
        /// <param name="ProductId"></param>
        [HttpDelete("{ProductId}")]
        public ActionResult<Product> Delete(int ProductId)
        {
            var product = repository.DeleteProduct(ProductId);
            if (product == null)
                return NotFound();
            return Ok(product);

            //public void Delete(int ProductId) => repository.DeleteProduct(ProductId);


        }


    }
}
