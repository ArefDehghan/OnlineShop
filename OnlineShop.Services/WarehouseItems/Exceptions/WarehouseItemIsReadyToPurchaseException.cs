using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.WarehouseItems.Exceptions
{
    public class WarehouseItemIsReadyToPurchaseException : BusinessException
    {
        public int Id { get; set; }
    }
}