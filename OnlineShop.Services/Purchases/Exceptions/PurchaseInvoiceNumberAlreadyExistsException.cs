using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Purchases.Exceptions
{
    public class PurchaseInvoiceNumberAlreadyExistsException : BusinessException
    {
        public string InvoiceNumber { get; set; }
    }
}