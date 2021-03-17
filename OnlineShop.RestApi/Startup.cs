using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Persistence.EF;
using OnlineShop.Persistence.EF.ProductCategories;
using OnlineShop.Services.ProductCategories;
using OnlineShop.Services.ProductCategories.Contracts;

namespace OnlineShop.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.AddScoped<EFDataContext>();
            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<ProductCategoryRepository, EFProductCategoryRepository>();
            services.AddScoped<ProductCategoryService, ProductCategoryAppService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(_ => 
            {
                _.SwaggerEndpoint("/swagger/v1/swagger.josn", "Online Shop RestApi V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
