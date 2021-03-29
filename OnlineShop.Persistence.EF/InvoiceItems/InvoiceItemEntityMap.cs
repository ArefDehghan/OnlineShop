using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.InvoiceItems
{
    public class InvoiceItemEntityMap : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(_ => _.Price)
                .IsRequired(true);

            builder.Property(_ => _.Count)
                .IsRequired(true);

            builder.HasOne(_ => _.WarehouseItem)
                .WithMany()
                .HasForeignKey(_ => _.WarehouseItemId);
        }
    }
}