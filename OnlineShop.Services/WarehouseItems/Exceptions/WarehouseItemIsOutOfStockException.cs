using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.WarehouseItems.Exceptions
{
    public class WarehouseItemIsOutOfStockException : BusinessException
    {
        public int Id { get; set; }
    }
}