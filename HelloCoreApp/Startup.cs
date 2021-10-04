using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL_Manager;
using BLL_Manager.Base;
using BLL_Manager.Contact;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Repositoris;
using Repositoris.Contacts;

namespace HelloCoreApp
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
            services.AddTransient<ICountryManager, CountryManager>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            //services.AddTransient<IShopManager, ShopManager>();
            //services.AddTransient<IShopRepository, ShopRepository>();
            //services.AddTransient<ICategoryManager, CategoryManager>();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<IProductManager, ProductManager> ();
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IOrderManager, OrderManager>();
            //services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICustomerAddressManager, CustomerAddressManager>();
            services.AddTransient<ICustomerAddressRepository, CustomerAddressRepository>();
            //services.AddTransient<IOrderdetailsRepository, OrderdetailsRepository>();
            //services.AddTransient<IOrderdetailsManager, OrderdetailsManager>();



            services.AddAutoMapper(typeof(Startup));

            services.AddCors(option =>
            {
                option.AddPolicy("AllowOrigin", policy => {
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                   policy.AllowAnyMethod();
                });
            });
    

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         ).AddXmlDataContractSerializerFormatters();


            //services.AddMvc()
            //    .AddJsonOptions((option) =>
            //    {
            //        option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });
            //    //.SetCompat

            //for image perpose
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

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

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
