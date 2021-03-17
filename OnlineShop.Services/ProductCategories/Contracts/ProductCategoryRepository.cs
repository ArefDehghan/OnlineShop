using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        Task<GetProductCategoryDto> GetById(int id);
        void Add(ProductCategory productCategory);
    }
}