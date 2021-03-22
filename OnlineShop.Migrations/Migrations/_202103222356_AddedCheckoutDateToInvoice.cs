using FluentMigrator;

namespace OnlineShop.Migrations
{
    [Migration(202103222356)]
    public class _202103222356_AddedCheckoutDateToInvoice : Migration
    {
        public override void Up()
        {
            Alter.Table("Invoices")
                .AddColumn("CheckoutDate").AsDateTime().NotNullable();
        }

        public override void Down()
        {
           Delete.Column("CheckoutDate").FromTable("Invoices");
        }
    }
}