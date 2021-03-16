namespace OnlineShop.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}