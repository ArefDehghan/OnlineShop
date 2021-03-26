using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Invoices.Exceptions
{
    public class InvoiceNotExistsException : BusinessException
    {
        public int Id { get; set; }
    }
}