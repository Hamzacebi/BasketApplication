#region Added Project References and General Usings
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Managers.ManagerOfBasketApplication.Abstracts;
using Managers.ManagerOfBasketApplication.Concretes;
#endregion Added Project References and General Usings

namespace Services.WebAPIOfBasketApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(version: Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            services.AddScoped<IManagerOfMembers, ManagerOfMembers>();
            services.AddScoped<IManagerOfProducts, ManagerOfProducts>();
            services.AddScoped<IManagerOfProductStocks, ManagerOfProductStocks>();
            services.AddScoped<IManagerOfMemberBaskets, ManagerOfMemberBaskets>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //app.UseMvc(configureRoutes: routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "api/{controller}/{action}/{id?}"
            //        //defaults: new { controller = "", action = "" }
            //        );
            //});

            app.UseMvcWithDefaultRoute();
        }
    }
}
