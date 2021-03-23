using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.ProductCategories.Contracts
{
    public interface ProductCategoryRepository
    {
        Task<IList<GetProductCategoryDto>> GetProductCategories();
        void Add(ProductCategory productCategory);
        Task<bool> IsTitleDuplicate(string title);
    }
}