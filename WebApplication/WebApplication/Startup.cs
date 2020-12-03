using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;
using WebApplication9.Models;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using WebApplication.Extensions;

namespace WebApplication
{
    public class Startup
    {
    
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration["Data:SportStoreProducts:ConnectionString"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseDeveloperExceptionPage();// informacje szczeg�owe o b��dach
            app.UseStatusCodePages();// Wy�wietla strony ze statusem b��du
            app.UseStaticFiles();// obs�uga tre�ci statycznych css, images, js
            app.UseRouting();
            app.UseElapsedTimeMiddleware();

            app.UseEndpoints(routes => {

                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=List}/{id?}");

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Product/{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                    });

                routes.MapControllerRoute(
                    name: null,
                    pattern: "Admin/{action=Index}",
                    defaults: new
                    {
                        controller = "Admin",

                    });
            });
   
            SeedData.EnsurePopulated(app);
    
        }
    }
}
