namespace OnlineShop.Services.InvoiceItems.Contracts
{
    public class AddInvoiceItemDto
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
    }
}