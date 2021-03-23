using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;
using OnlineShop.Services.ProductCategories.Exceptions;

namespace OnlineShop.Services.ProductCategories
{
    public class ProductCategoryAppService : ProductCategoryService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductCategoryRepository _repository;
        public ProductCategoryAppService(ProductCategoryRepository repository, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(string productCategoryTitle)
        {
            ThrowExceptionIfTitleIsDuplicate(productCategoryTitle);

            var productCategory = new ProductCategory
            {
                Title = productCategoryTitle
            };

            _repository.Add(productCategory);
            await _unitOfWork.CompleteAsync();

            return productCategory.Id;
        }

        private async void ThrowExceptionIfTitleIsDuplicate(string title)
        {
            if (await _repository.IsTitleDuplicate(title))
            {
                throw new ProductCategoryTitleIsDuplicateException
                {
                    ProductCategoryTitle = title
                };
            }
        }

        public async Task<IList<GetProductCategoryDto>> GetProductCategories()
        {
            return await _repository.GetProductCategories();
        }
    }
}