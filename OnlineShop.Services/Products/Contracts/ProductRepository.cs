using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void Add(Product product);
        Task<Product> FindById(int id);
        Task<bool> IsProductExists(int id);
        Task<bool> IsProductCodeExists(string productCode);
        Task<bool> IsProductTitleExistsInProductCategory(string productTitle);
    }
}