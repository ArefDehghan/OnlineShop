using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.ProductCategories.Contracts;

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

        public async Task<int> Add(AddProductCategoryDto addProductCategoryDto)
        {
            var productCategory = new ProductCategory
            {
                Title = addProductCategoryDto.Title
            };

            _repository.Add(productCategory);
            await _unitOfWork.CompleteAsync();

            return productCategory.Id;
        }

        public async Task<GetProductCategoryDto> GetById(int id)
        {
            var productCategory = await _repository.GetById(id);

            return productCategory;
        }
    }
}