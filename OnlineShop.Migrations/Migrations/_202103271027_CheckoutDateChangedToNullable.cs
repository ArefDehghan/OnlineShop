using FluentMigrator;

namespace OnlineShop.Migrations
{
    [Migration(202103271027)]
    public class _202103271027_CheckoutDateChangedToNullable : Migration
    {
        public override void Up()
        {
            Alter.Column("CheckoutDate")
                .OnTable("Invoices")
                .AsDateTime()
                .Nullable();
        }

        public override void Down()
        {
            Alter.Column("CheckoutDate")
                .OnTable("Invoices")
                .AsDateTime()
                .NotNullable();
        }
    }
}