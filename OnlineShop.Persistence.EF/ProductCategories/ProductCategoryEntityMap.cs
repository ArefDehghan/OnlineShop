using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.ProductCategories
{
    public class ProductCategoryEntityMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .UseIdentityColumn();

            builder.Property(_ => _.Title)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.HasMany(_ => _.Products)
                .WithOne(_ => _.ProductCategory)
                .HasForeignKey(_ => _.ProductCategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}