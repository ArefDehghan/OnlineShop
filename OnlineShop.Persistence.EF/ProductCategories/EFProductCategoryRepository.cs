using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<GetProductCategoryDto>> GetProductCategories()
        {
            return await _context.ProductCategories.Select(_ => new GetProductCategoryDto
            {
                Id = _.Id,
                Title = _.Title
            }).ToListAsync();
        }

        public async Task<bool> IsProductCategoryExists(int id)
        {
            return await _context.ProductCategories.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> IsTitleDuplicate(string title)
        {
            return await _context.ProductCategories.AnyAsync(_ => _.Title == title);
        }
    }
}