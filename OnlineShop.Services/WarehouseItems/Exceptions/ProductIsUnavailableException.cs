using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.WarehouseItems.Exceptions
{
    public class ProductIsUnavailableException : BusinessException
    {
        public int ProductId { get; set; }
    }
}