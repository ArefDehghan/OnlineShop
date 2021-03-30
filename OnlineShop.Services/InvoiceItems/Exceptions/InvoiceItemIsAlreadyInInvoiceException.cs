using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.InvoiceItems.Exceptions
{
    public class InvoiceItemIsAlreadyInInvoiceException : BusinessException
    {
        public int InvoiceId { get; set; }
        public int WarehouseId { get; set; }
    }
}