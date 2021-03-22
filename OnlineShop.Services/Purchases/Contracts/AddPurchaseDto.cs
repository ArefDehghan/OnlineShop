using System;

namespace OnlineShop.Services.Purchases.Contracts
{
    public class AddPurchaseDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
    }
}