using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Invoices.Exceptions
{
    public class InvoiceNumberIsAlreadyExistsException : BusinessException
    {
        public string InvoiceNumber { get; set; }
    }
}