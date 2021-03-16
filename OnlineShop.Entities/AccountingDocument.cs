using System;

namespace OnlineShop.Entities
{
    public class AccountingDocument
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public DateTime DocumentRegistrationDate { get; set; }
    }
}