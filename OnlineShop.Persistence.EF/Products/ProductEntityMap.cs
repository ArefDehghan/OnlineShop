using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Products
{
    public class ProductEntityMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(_ => _.Title)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(_ => _.MinimumStock)
                .IsRequired(true);

            builder.Property(_ => _.ProductCode)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(_ => _.ProductCategoryId)
                .IsRequired(true);

            builder.HasMany(_ => _.WarehouseItems)
                .WithOne(_ => _.Product)
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}