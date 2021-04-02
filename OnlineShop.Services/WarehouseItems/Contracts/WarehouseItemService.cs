using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.WarehouseItems.Contracts
{
    public interface WarehouseItemService
    {
        Task<IList<GetWarehouseItemDto>> GetWarehouseItems(FilterModelDto filter);
    }

}