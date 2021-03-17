using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryService
    {
        Task<int> Add(AddProductCategoryDto productCategory);

        Task<GetProductCategoryDto> GetById(int id);

    }
}