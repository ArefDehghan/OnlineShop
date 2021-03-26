using OnlineShop.Infrastructure.Application;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class GetWarehouseItemDto
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCode { get; set; }
        public int Stock { get; set; }
        public int MinimumStock { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public WarehouseItemStatus WarehouseItemStatus 
        {
            get
            {
                if (Stock == 0)
                    return WarehouseItemStatus.OutOfStock;
                if (Stock == MinimumStock)
                    return WarehouseItemStatus.ReadyToPurchase;
                else
                    return WarehouseItemStatus.UpForSale;
            }
        }
    }
}