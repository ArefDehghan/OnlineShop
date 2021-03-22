using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemRepository
    {
        Task<WarehouseItem> FindByProductId(int ProductId);
    }
}