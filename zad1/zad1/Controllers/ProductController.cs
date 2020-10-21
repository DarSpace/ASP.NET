using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zad1.Models;


namespace zad1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProductModel()
        {
            var product = new List<ProductModel>
            {
              new ProductModel { NameProducts = "Marchew", Descriptions = "opis 1 ", Price = 10 },
              new ProductModel { NameProducts = "Ananas",Descriptions = "opis 2 ", Price = 13   },
              new ProductModel { NameProducts= "Pizza", Descriptions = "opis 3 ",  Price = 15   },
              new ProductModel { NameProducts = "Lody", Descriptions = "opis 4 ",   Price = 18  },

            };
            return View(product);

        }

        
        



    }
}
