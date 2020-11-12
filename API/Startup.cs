using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;

namespace API
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()           //Fix API ISSUE
                                                                   .AllowAnyMethod()               //Fix API ISSUE
                                                                    .AllowAnyHeader()));
            services.AddControllersWithViews();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IkhachhangRespo, khachhangRespo>();
            services.AddTransient<IkhachhangBusiness, khachhangBusiness>();
            services.AddTransient<IdanhmucBusiness, danhmucBusiness>();
            services.AddTransient<IdanhmucRespo, danhmucRespo>();
            services.AddTransient<IsanphamRespo, SanphamRespo>();
            services.AddTransient<IsanphamBusiness, sanphamBusiness>();
            services.AddTransient<IloaisanphamBusiness, loaisanphamBusiness>();
            services.AddTransient<IloaisanphamRespo, loaisanphamRespo>();
            services.AddTransient<ItintucBusiness, TintucBusiness>();
            services.AddTransient<ItintucRespo, TintucRespo>();
            services.AddTransient<IthongkeBusiness, ThongkeBusiness>();
            services.AddTransient<IthongkeRespo, ThongkeRespo>();
            services.AddTransient<IhoadonBusiness, HoadonBusiness>();
            services.AddTransient<IhoadonRespo, HoadonRespo>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowAll");
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
