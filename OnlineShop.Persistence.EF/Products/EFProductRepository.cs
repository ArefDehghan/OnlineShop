using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Products.Contracts;

namespace OnlineShop.Persistence.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        public EFProductRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _context.Products.Include(_ => _.WarehouseItems).SingleOrDefaultAsync(_ => _.Id == id);
        }

        public bool IsProductCodeExists(string productCode)
        {
            return _context.Products.Any(_ => _.ProductCode == productCode);
        }

        public async Task<bool> IsProductExists(int id)
        {
            return await _context.Products.AnyAsync(_ => _.Id == id);
        }

        public bool IsProductTitleExistsInProductCategory(string productTitle)
        {
            return _context.Products.Any(_ => _.Title == productTitle);
        }
    }
}