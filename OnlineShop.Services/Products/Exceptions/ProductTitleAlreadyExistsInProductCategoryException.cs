using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Products.Exceptions
{
    public class ProductTitleAlreadyExistsInProductCategory : BusinessException
    {
        public string ProductTitle { get; set; }
    }
}