using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Purchases.Contracts;
using OnlineShop.Services.Purchases.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;
using OnlineShop.Services.WarehouseItems.Exceptions;

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

            var warehouseItem = await _warehouseItemRepository.FindByProductId(addPurchaseDto.ProductId);
            ThrowExceptionIfWarehouseItemNotExists(addPurchaseDto.ProductId, warehouseItem);

            await ThrowExceptionIfInvoiceNumberAlreadyExists(addPurchaseDto.InvoiceNumber);

            warehouseItem.Stock += purchase.Count;

            _repository.Add(purchase);
            await _unitOfWork.CompleteAsync();

            return purchase.Id;
        }

        private async Task ThrowExceptionIfInvoiceNumberAlreadyExists(string invoiceNumber)
        {
            if (await _repository.IsInvoiceNumberExists(invoiceNumber))
            {
                throw new PurchaseInvoiceNumberAlreadyExistsException
                {
                    InvoiceNumber = invoiceNumber
                };
            }
        }

        private void ThrowExceptionIfWarehouseItemNotExists(int productId, WarehouseItem warehouseItem)
        {
            if (warehouseItem == null)
            {
                throw new WarehouseItemNotExistsException
                {
                    ProductId = productId
                };
            }
        }
    }
}