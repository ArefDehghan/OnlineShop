using OnlineShop.Infrastructure.Domain;

namespace OnlineShop.Services.Products.Exceptions
{
    public class ProductCodeAlreadyExistsException : BusinessException
    {
        public string ProductCode { get; set; }
    }
}