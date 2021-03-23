using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryService
    {
        Task<int> Add(string productCategoryTitle);
        Task<IList<GetProductCategoryDto>> GetProductCategories();
    }
}