using System;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.InvoiceItems.Contracts;
using OnlineShop.Services.InvoiceItems.Exceptions;
using OnlineShop.Services.Invoices.Contracts;
using OnlineShop.Services.Invoices.Exceptions;
using OnlineShop.Services.Products.Contracts;
using OnlineShop.Services.Products.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;
using OnlineShop.Services.WarehouseItems.Exceptions;

namespace OnlineShop.Services.InvoiceItems
{
    public class InvoiceItemAppService : InvoiceItemService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly InvoiceItemRepository _repository;
        private readonly WarehouseItemRepository _warehouseItemRepository;
        private readonly ProductRepository _productRepository;
        private readonly InvoiceRepository _invoiceRepository;
        public InvoiceItemAppService(UnitOfWork unitOfWork,
                                     InvoiceItemRepository repository,
                                     WarehouseItemRepository warehouseItemRepository,
                                     ProductRepository productRepository,
                                     InvoiceRepository invoiceRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _warehouseItemRepository = warehouseItemRepository;
            _productRepository = productRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> Add(AddInvoiceItemDto addInvoiceItemDto)
        {
            var invoiceItem = new InvoiceItem
            {
                Price = addInvoiceItemDto.Price,
                Count = addInvoiceItemDto.Count,
                InvoiceId = addInvoiceItemDto.InvoiceId,
                ProductId = addInvoiceItemDto.ProductId
            };

            ThrowExceptionIfProductNotExists(addInvoiceItemDto.ProductId);
            ThrowExceptionIfInvoiceNotExists(addInvoiceItemDto.InvoiceId);
            ThrowExceptionIfProductIsNotUpForSale(addInvoiceItemDto.ProductId);

            _repository.Add(invoiceItem);
            await _unitOfWork.CompleteAsync();

            return invoiceItem.Id;
        }

        private async void ThrowExceptionIfInvoiceNotExists(int invoiceId)
        {
            if (await _invoiceRepository.IsInvoiceExists(invoiceId))
            {
                throw new InvoiceNotExistsException
                {
                    Id = invoiceId
                };
            }
        }

        private async void ThrowExceptionIfProductNotExists(int productId)
        {
            if (await _productRepository.IsProductExists(productId))
            {
                throw new ProductNotExistsException
                {
                    Id = productId
                };
            }
        }

        private async void ThrowExceptionIfProductIsNotUpForSale(int productId)
        {
            var getWarehouseItemDto = await GetWarehouseItem(productId);

            if (getWarehouseItemDto.WarehouseItemStatus == WarehouseItemStatus.OutOfStock)
            {
                throw new WarehouseItemIsOutOfStockException
                {
                    Id = getWarehouseItemDto.Id
                };
            }

            if (getWarehouseItemDto.WarehouseItemStatus == WarehouseItemStatus.ReadyToPurchase)
            {
                throw new WarehouseItemIsReadyToPurchaseException
                {
                    Id = getWarehouseItemDto.Id
                };
            }
        }

        private async Task<GetWarehouseItemDto> GetWarehouseItem(int productId)
        {
            var warehouseItem = await _warehouseItemRepository.FindByProductId(productId);
            var getWarehouseItemDto = new GetWarehouseItemDto
            {
                Id = warehouseItem.Id,
                Stock = warehouseItem.Stock,
                MinimumStock = warehouseItem.Product.MinimumStock,
                ProductTitle = warehouseItem.Product.Title,
                ProductCode = warehouseItem.Product.ProductCode,
                ProductCategoryId = warehouseItem.Product.ProductCategoryId,
                ProductId = warehouseItem.ProductId
            };

            return getWarehouseItemDto;
        }

        public async Task Delete(int id)
        {
            var invoiceItem = await GetInvoiceItemById(id);

            _repository.Delete(invoiceItem);
            await _unitOfWork.CompleteAsync();
        }

        private async Task<InvoiceItem> GetInvoiceItemById(int id)
        {
            var invoiceItem = await _repository.FindById(id);

            if (invoiceItem == null)
            {
                throw new InvoiceItemNotExistsException
                {
                    Id = id
                };
            }

            return invoiceItem;
        }
    }
}