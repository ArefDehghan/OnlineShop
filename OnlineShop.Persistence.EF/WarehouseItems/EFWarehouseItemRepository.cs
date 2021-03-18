using System.Threading.Tasks;
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

        public void Add(WarehouseItem warehouseItem)
        {
            _context.Add(warehouseItem);
        }

        public async Task<WarehouseItem> FindById(int id)
        {
            return await _context.WarehouseItems.FindAsync(id);
        }

        public async Task<GetWarehouseItemDto> GetById(int id)
        {
            var warehouseItem = await _context.WarehouseItems.FindAsync(id);

            var getWarehouseItemDto = new GetWarehouseItemDto
            {
                Id = warehouseItem.Id,
                Stock = warehouseItem.Stock,
                ProductId = warehouseItem.ProductId 
            };

            return getWarehouseItemDto;
        }
    }
}