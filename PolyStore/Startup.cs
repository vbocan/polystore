using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PolyStore.Helpers;
using PolyStore.Data.Models;
using PolyStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolyStore.Mapping;

namespace PolyStore
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
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });
            services.AddRazorPages();

            // Register database settings
            services.
                Configure<DatabaseSettings>(options =>
                {
                    options.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                });
            // Register database context
            // The MongoDB client has a pool of connections that are reused automatically and a single MongoDB client instance is enough even in multithreaded scenarios
            // See http://mongodb.github.io/mongo-csharp-driver/2.7/getting_started/quick_tour/ (Mongo Client section)
            services.AddSingleton(typeof(DatabaseContext));
            // Add current date time helper
            services.AddSingleton<ICurrentDateTime>(new CurrentDateTime());
            // Register repositories
            services.AddTransient<IStoreRepository, StoreRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            // Configure AutoMapper
            services.AddAutoMapper(typeof(PolyStoreMappingProfile));
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
