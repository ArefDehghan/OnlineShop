using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.InvoiceItems.Exceptions
{
    public class InvoiceItemNotExistsException : BusinessException
    {
        public int Id { get; set; }
    }
}