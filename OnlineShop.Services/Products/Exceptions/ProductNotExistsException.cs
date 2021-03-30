using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Products.Exceptions
{
    public class ProductNotExistsException : BusinessException
    {
        public int ProductId { get; set; }
    }
}