using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.ProductCategories.Exceptions
{
    public class ProductCategoryTitleIsDuplicateException : BusinessException
    {
        public string ProductCategoryTitle { get; set; }
    }
}