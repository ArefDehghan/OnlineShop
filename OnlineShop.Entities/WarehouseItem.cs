namespace OnlineShop.Entities
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}