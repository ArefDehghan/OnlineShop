using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.ProductCategories.Exceptions
{
    public class ProductCategoryNotExistsException : BusinessException
    {
        public int ProductCategoryId { get; set; }
    }
}