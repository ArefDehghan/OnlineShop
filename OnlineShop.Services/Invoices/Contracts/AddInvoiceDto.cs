using System;

namespace OnlineShop.Services.Invoices.Contracts
{
    public class AddInvoiceDto
    {
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}