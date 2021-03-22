using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.Persistence.EF.WarehouseItems
{
    public class EFWarehouseItemRepository : WarehouseItemRepository
    {
        private readonly EFDataContext _context;
        public EFWarehouseItemRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<WarehouseItem> FindByProductId(int id)
        {
            return await _context.WarehouseItems.SingleOrDefaultAsync(_ => _.ProductId == id);
        }
    }
}