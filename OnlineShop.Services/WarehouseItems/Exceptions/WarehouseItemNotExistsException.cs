using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.WarehouseItems.Exceptions
{
    public class WarehouseItemNotExistsException : BusinessException
    {
        public int WarehouseItemId { get; set; }
        public int ProductId { get; set; }
    }
}