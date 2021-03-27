using FluentMigrator;

namespace OnlineShop.Migrations
{
    [Migration(202103170820)]
    public class _202103170820_TablesSchemaCreated : Migration
    {
        public override void Up()
        {
            Create.Table("ProductCategories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable().Unique();

            Create.Table("Products")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("ProductCode").AsString(10).NotNullable()
                .WithColumn("MinimumStock").AsInt32().NotNullable()
                .WithColumn("ProductCategoryId").AsInt32().NotNullable()
                .ForeignKey("ProductCategories", "Id");

            Create.Table("WarehouseItems")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Stock").AsInt32().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("Products", "Id");

            Create.Table("Purchases")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("InvoiceNumber").AsString(20).NotNullable()
                .WithColumn("PurchaseDate").AsDateTime().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("Products", "Id");

            Create.Table("Invoices")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("CustomerName").AsString(50).NotNullable()
                .WithColumn("InvoiceNumber").AsString(20).NotNullable();

            Create.Table("InvoiceItems")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("ProductId").AsInt32().NotNullable()
                .ForeignKey("Products", "Id")
                .WithColumn("InvoiceId").AsInt32().NotNullable()
                .ForeignKey("Invoices", "Id");

            Create.Table("AccountingDocuments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DocumentNumber").AsString(20).NotNullable()
                .WithColumn("TotalPrice").AsDecimal().NotNullable()
                .WithColumn("DocumentRegistrationDate").AsDateTime().NotNullable()
                .WithColumn("InvoiceId").AsInt32().NotNullable()
                .ForeignKey("Invoices", "Id");
        }

        public override void Down()
        {
            Delete.Table("AccountingDocuments");
            Delete.Table("InvoiceItems");
            Delete.Table("Invoices");
            Delete.Table("Purchases");
            Delete.Table("WarehouseItems");
            Delete.Table("Products");
            Delete.Table("ProductCategories");
        }
    }
}