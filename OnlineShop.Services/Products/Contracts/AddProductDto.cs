namespace OnlineShop.Services.Products.Contracts
{
    public class AddProductDto
    {
        public string Title { get; set; }
        public string ProductCode { get; set; }
        public int MinimumStock { get; set; }
        public int ProductCategoryId { get; set; }
    }
}