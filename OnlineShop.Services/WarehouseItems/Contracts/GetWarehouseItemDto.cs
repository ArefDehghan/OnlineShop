using OnlineShop.Infrastructure.Application;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class GetWarehouseItemDto
    {
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCode { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public int MinimumStock { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
    }
}