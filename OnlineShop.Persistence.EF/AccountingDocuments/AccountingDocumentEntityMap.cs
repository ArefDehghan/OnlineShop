using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Entities;

namespace OnlineShop.Persistence.EF.AccountingDocuments
{
    class AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
    {
        public void Configure(EntityTypeBuilder<AccountingDocument> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .IsRequired(true)
                .UseIdentityColumn();

            builder.Property(_ => _.DocumentNumber)
                .IsRequired(true)
                .HasMaxLength(20);

            builder.Property(_ => _.DocumentRegistrationDate)
                .IsRequired(true);

            builder.Property(_ => _.TotalPrice)
                .IsRequired(true);

            builder.Property(_ => _.InvoiceId)
                .IsRequired(true);
        }
    }
}