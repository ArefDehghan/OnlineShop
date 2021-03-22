using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.Purchases.Contracts;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.Services.Purchases
{
    public class PurchaseAppService : PurchaseService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly PurchaseRepository _repository;
        private readonly WarehouseItemRepository _warehouseItemRepository;
        public PurchaseAppService(UnitOfWork unitOfWork, PurchaseRepository repository, WarehouseItemRepository warehouseItemRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _warehouseItemRepository = warehouseItemRepository;
        }

        public async Task<int> Add(AddPurchaseDto addPurchaseDto)
        {
            var purchase = new Purchase
            {
                Count = addPurchaseDto.Count,
                InvoiceNumber = addPurchaseDto.InvoiceNumber,
                PurchaseDate = addPurchaseDto.PurchaseDate,
                ProductId = addPurchaseDto.ProductId
            };

            var warehouseItem = await GetWarehouseItemByProductId(purchase.ProductId);
            warehouseItem.Stock += purchase.Count;

            _repository.Add(purchase);
            await _unitOfWork.CompleteAsync();

            return purchase.Id;
        }

        private async Task<WarehouseItem> GetWarehouseItemByProductId(int productId)
        {
            var warehouseItem = await _warehouseItemRepository.FindByProductId(productId); 

            if (warehouseItem == null)
            {
                throw new ProductNotExistsException
                {
                    Id = productId
                };
            }

            return warehouseItem;
        }
    }
}