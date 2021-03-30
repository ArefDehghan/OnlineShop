using System;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.InvoiceItems.Contracts;
using OnlineShop.Services.InvoiceItems.Exceptions;
using OnlineShop.Services.Invoices.Contracts;
using OnlineShop.Services.Invoices.Exceptions;
using OnlineShop.Services.Products.Contracts;
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
            await ThrowExceptionIfProductNotExists(addInvoiceItemDto.WarehouseItemId);
            await ThrowExceptionIfInvoiceNotExists(addInvoiceItemDto.InvoiceId);
            await ThrowExceptionIfInvoiceItemIsAlreadyInInvoice(addInvoiceItemDto.WarehouseItemId, addInvoiceItemDto.InvoiceId);

            var warehouseItem = await _warehouseItemRepository.FindById(addInvoiceItemDto.WarehouseItemId);

            var invoiceItem = new InvoiceItem
            {
                Price = addInvoiceItemDto.Price,
                Count = addInvoiceItemDto.Count,
                InvoiceId = addInvoiceItemDto.InvoiceId,
                WarehouseItemId = addInvoiceItemDto.WarehouseItemId,
                WarehouseItem = warehouseItem
            };
            await ThrowExceptionIfProductIsNotUpForSale(invoiceItem);

            _repository.Add(invoiceItem);
            await _unitOfWork.CompleteAsync();

            return invoiceItem.Id;
        }

        private async Task ThrowExceptionIfInvoiceItemIsAlreadyInInvoice(int warehouseItemId, int invoiceId)
        {
            if (await _repository.IsInvoiceItemExistsInInvoice(warehouseItemId, invoiceId))
            {
                throw new InvoiceItemIsAlreadyInInvoiceException
                {
                    WarehouseId = warehouseItemId,
                    InvoiceId = invoiceId
                };
            }
        }

        private async Task ThrowExceptionIfProductIsNotUpForSale(InvoiceItem invoiceItem)
        {
            if (!await _repository.IsInvoiceItemUpForSale(invoiceItem))
            {
                throw new ProductIsUnavailableException
                {
                    ProductId = invoiceItem.WarehouseItem.ProductId
                };
            }
        }

        private async Task ThrowExceptionIfInvoiceNotExists(int invoiceId)
        {
            if (!await _invoiceRepository.IsInvoiceExists(invoiceId))
            {
                throw new InvoiceNotExistsException
                {
                    InvoiceId = invoiceId
                };
            }
        }

        private async Task ThrowExceptionIfProductNotExists(int productId)
        {
            if (!await _warehouseItemRepository.IsWarehouseItemExistsById(productId))
            {
                throw new WarehouseItemNotExistsException
                {
                    ProductId = productId
                };
            }
        }

        public async Task Delete(int id)
        {
            var invoiceItem = await _repository.FindById(id);
            ThrowExceptionIfInvoiceItemNotExists(id, invoiceItem);

            _repository.Delete(invoiceItem);
            await _unitOfWork.CompleteAsync();
        }

        private void ThrowExceptionIfInvoiceItemNotExists(int invoiceItemId, InvoiceItem invoiceItem)
        {
            if (invoiceItem == null)
            {
                throw new InvoiceItemNotExistsException
                {
                    InvoiceItemId = invoiceItemId
                };
            }
        }
    }
}