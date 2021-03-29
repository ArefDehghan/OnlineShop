namespace OnlineShop.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int WarehouseItemId { get; set; }
        public WarehouseItem WarehouseItem { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}