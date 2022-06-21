using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentManagement.Services;
using ApartmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddSingleton<IProperty, Property>();
            //services.AddSingleton<IUnitData, AptUnit>();
            services.AddScoped<IProperty, DBProperty>();
            services.AddScoped<IUnitData, DBProperty>();
            services.AddDbContext<ComplexContext>(options => options.UseSqlServer(@"Server=DESKTOP-PHIL35\SQLEXPRESS;Database=MyPropertyManagement;Trusted_Connection=true;MultipleActiveResultSets=True"));
            //services.AddDbContext<UnitContext>(options => options.UseSqlServer(@"Server=DESKTOP-PHIL35\SQLEXPRESS;Database=MyPropertyManagement;Trusted_Connection=true;MultipleActiveResultSets=True"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(ComplexContext complextContext, IApplicationBuilder app, IWebHostEnvironment env)
        {
            //just in case
            //complextContext.Database.EnsureDeleted();

            complextContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
