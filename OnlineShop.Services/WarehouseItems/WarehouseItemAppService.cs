using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.Services.WarehouseItems
{
    public class WarehouseItemAppService : WarehouseItemService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly WarehouseItemRepository _repository;
        public WarehouseItemAppService(UnitOfWork unitOfWork, WarehouseItemRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IList<GetWarehouseItemDto>> GetWarehouseItems(FilterModelDto filter)
        {
            var warehouseItems = await _repository.GetWarehouseItems(filter);

            return warehouseItems;
        }
    }
}