using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class FakeProductRepository: IProductRepository 
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Rower", Price = 20000},
             new Product { Name = "Piłka", Price = 100},
              new Product { Name = "koło", Price = 40}
        }.AsQueryable<Product>();
        



        



    }
}
