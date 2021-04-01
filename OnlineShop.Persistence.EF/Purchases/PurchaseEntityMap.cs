using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Purchases
{
    class PurchaseEntityMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(_ => _.InvoiceNumber)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.Property(_ => _.Count)
                .IsRequired(true);

            builder.Property(_ => _.ProductId)
                .IsRequired(true);

            builder.Property(_ => _.PurchaseDate)
                .IsRequired(true);

            builder.HasOne(_ => _.Product)
                .WithMany()
                .HasForeignKey(_ => _.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}