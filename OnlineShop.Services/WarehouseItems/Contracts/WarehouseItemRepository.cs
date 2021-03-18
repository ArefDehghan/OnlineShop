using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemRepository
    {
        void Add(WarehouseItem warehouseItem);
        Task<WarehouseItem> FindById(int id);
        Task<GetWarehouseItemDto> GetById(int id);
    }
}