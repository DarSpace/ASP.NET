using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class EFProductRepository : IProductRepository
    {

        private readonly AppDbContext ctx;

        public EFProductRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }



        public IQueryable<Product> Products => ctx.Products;

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                Product dbProduct = ctx.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Description = product.Description;
                    dbProduct.Price = product.Price;
                    dbProduct.Category = product.Category;
                }
            }
            ctx.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbProduct = ctx.Products.Find(productID);
            if (dbProduct != null)
            {
                ctx.Products.Remove(dbProduct);
                ctx.SaveChanges();
            }
            return dbProduct;
        }


    }
}
