using FluentMigrator;

namespace OnlineShop.Migrations
{
    [Migration(202103291349)]
    public class _202103291349_ChangedInvoiceItemsRelations : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_InvoiceItems_ProductId_Products_Id").OnTable("InvoiceItems");

            Delete.Column("ProductId").FromTable("InvoiceItems");

            Alter.Table("InvoiceItems")
                .AddColumn("WarehouseItemId").AsInt32().NotNullable()
                .ForeignKey("WarehouseItems", "Id");
        }

        public override void Down()
        {
            Alter.Table("InvoiceItems")
                .AddColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("Products", "Id");

            Delete.ForeignKey("FK_InvoiceItems_WarehouseItemId_WarehouseItems_Id").OnTable("InvoiceItems");

            Delete.Column("WarehouseItemId").FromTable("InvoiceItems");
        }
    }
}