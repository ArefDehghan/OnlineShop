using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Invoices.Exceptions
{
    public class InvoiceItemsAreNotUpForSaleException : BusinessException
    {
        public int InvoiceId { get; set; }
    }
}