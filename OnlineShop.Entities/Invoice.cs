using System;
using System.Collections.Generic;

namespace OnlineShop.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNumer { get; set; }
        public HashSet<InvoiceItem> InvoiceItems { get; set; }
        public HashSet<AccountingDocument> AccountingDocuments { get; set; }
        public DateTime CheckoutDate { get; set; }

        public Invoice()
        {
            InvoiceItems = new HashSet<InvoiceItem>();
        }
    }
}