using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Persistence.EF;
using OnlineShop.Persistence.EF.AccountingDocuments;
using OnlineShop.Persistence.EF.InvoiceItems;
using OnlineShop.Persistence.EF.Invoices;
using OnlineShop.Persistence.EF.ProductCategories;
using OnlineShop.Persistence.EF.Products;
using OnlineShop.Persistence.EF.Purchases;
using OnlineShop.Persistence.EF.WarehouseItems;
using OnlineShop.Services.AccountingDocuments.Contracts;
using OnlineShop.Services.InvoiceItems;
using OnlineShop.Services.InvoiceItems.Contracts;
using OnlineShop.Services.Invoices;
using OnlineShop.Services.Invoices.Contracts;
using OnlineShop.Services.ProductCategories;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.Products;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Purchases;
using OnlineShop.Services.Purchases.Contracts;
using OnlineShop.Services.WarehouseItems;
using OnlineShop.Services.WarehouseItems.Contracts;

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

            services.AddScoped<ProductRepository, EFProductRepository>();
            services.AddScoped<ProductService, ProductAppService>();

            services.AddScoped<PurchaseRepository, EFPurchaseRepository>();
            services.AddScoped<PurchaseService, PurchaseAppService>();

            services.AddScoped<InvoiceRepository, EFInvoiceRepository>();
            services.AddScoped<InvoiceService, InvoiceAppService>();

            services.AddScoped<InvoiceItemRepository, EFInvoiceItemRepository>();
            services.AddScoped<InvoiceItemService, InvoiceItemAppService>();

            services.AddScoped<WarehouseItemRepository, EFWarehouseItemRepository>();
            services.AddScoped<WarehouseItemService, WarehouseItemAppService>();
            
            services.AddScoped<AccountingDocumentRepository, EFAccountingDocumentRepository>();

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
