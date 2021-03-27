using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.Invoices
{
    public class InvoiceEntityMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(_ => _.CustomerName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(_ => _.InvoiceNumber)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.Property(_ => _.CheckoutDate)
                .IsRequired(false);

            builder.HasMany(_ => _.InvoiceItems)
                .WithOne(_ => _.Invoice)
                .HasForeignKey(_ => _.InvoiceId);

            builder.HasMany(_ => _.AccountingDocuments)
                .WithOne(_ => _.Invoice)
                .HasForeignKey(_ => _.InvoiceId);
        }
    }
}