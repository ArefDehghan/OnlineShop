namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public class GetWarehouseItemDto
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
    }
}