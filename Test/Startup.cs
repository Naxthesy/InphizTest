using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Test.Services;
using System;

namespace Test
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public int dev = 1;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            string connection = Configuration.GetConnectionString("DefaultConnection");
            string connectionAzure = Configuration.GetConnectionString("AzureConnection");
            if (dev == 1)
            {
                services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options => options.UseMySql(connectionAzure));
            }
            services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connection));
            services.AddScoped<RandomService>();
            services.AddScoped<GenerateSeedService>();
            services.AddScoped<StatisticService>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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