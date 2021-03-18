using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void Add(Product product);
        Task<Product> FindById(int id);
        bool IsProductCodeExists(string productCode);
        bool IsProductTitleExistsInProductCategory(string productTitle);
    }
}