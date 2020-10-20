using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zad1.Models;

namespace zad1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public string stringValue()
        {
            return "helloWord "; 
        }

        public string data()
        {
            DateTime thisDay = DateTime.Today;
            return thisDay.ToString("D");
        } 


        public IActionResult RedirectToGoogle()
        {
            return Redirect("http://www.google.com");
        }

        public IActionResult GetJson()
        {
            return Json(new { Name = "Jan", Surname = " Dąb "  });
        }



        public IActionResult TestModel()
        {
            var model = new List<TestModel>
            {
              new TestModel { NameProduct = "nazwa produktu 1" },
              new TestModel { NameProduct = "nazwa produktu 2" },
              new TestModel { NameProduct = "nazwa produktu 3" },
              new TestModel { NameProduct = "nazwa produktu 4" },

            };  
            return View(model); 

        }


    }
}
