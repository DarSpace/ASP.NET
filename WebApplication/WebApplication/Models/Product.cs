using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(50)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(2000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage ="Proszę podać dodatnią cene produktu")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }


    }
}
