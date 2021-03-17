using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Services.ProductCategories.Contracts;

namespace OnlineShop.Persistence.EF.ProductCategories
{
    public class EFProductCategoryRepository : ProductCategoryRepository
    {
        private readonly EFDataContext _context;
        public EFProductCategoryRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
        }

        public async Task<GetProductCategoryDto> GetById(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);

            var getProductCategoryDto = new GetProductCategoryDto
            {
                Id = productCategory.Id,
                Title = productCategory.Title
            };

            return getProductCategoryDto;
        }
    }
}