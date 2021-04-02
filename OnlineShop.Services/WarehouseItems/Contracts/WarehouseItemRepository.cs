using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemRepository
    {
        Task<WarehouseItem> FindByProductId(int ProductId);
        Task<WarehouseItem> FindById(int id);
        Task<bool> IsWarehouseItemExistsById(int id);
        Task<IList<GetWarehouseItemDto>> GetWarehouseItems(FilterModelDto filterModel);
    }
}