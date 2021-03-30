using System;
using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.AccountingDocuments.Contracts;
using OnlineShop.Services.Invoices.Contracts;
using OnlineShop.Services.Invoices.Exceptions;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.Services.Invoices
{
    public class InvoiceAppService : InvoiceService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly InvoiceRepository _repository;
        private readonly AccountingDocumentRepository _accountingDocumentRepository;
        private readonly WarehouseItemRepository _warehouseItemRepository;
        public InvoiceAppService(UnitOfWork unitOfWork,
                                 InvoiceRepository repository,
                                 AccountingDocumentRepository accountingDocumentRepository,
                                 WarehouseItemRepository warehouseItemRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _accountingDocumentRepository = accountingDocumentRepository;
            _warehouseItemRepository = warehouseItemRepository;
        }

        public async Task<int> Add(AddInvoiceDto addInvoiceDto)
        {
            var invoice = new Invoice
            {
                CustomerName = addInvoiceDto.CustomerName,
                InvoiceNumber = addInvoiceDto.InvoiceNumber,
            };

            await ThrowExceptionIfInvoiceNumberIsAlreadyExists(addInvoiceDto.InvoiceNumber);

            _repository.Add(invoice);
            await _unitOfWork.CompleteAsync();

            return invoice.Id;
        }

        private async Task ThrowExceptionIfInvoiceNumberIsAlreadyExists(string invoiceNumber)
        {
            if (await _repository.IsInvoiceNumberExists(invoiceNumber))
            {
                throw new InvoiceNumberIsAlreadyExistsException
                {
                    InvoiceNumber = invoiceNumber
                };
            }
        }

        public async Task Checkout(int id, DateTime checkoutDate)
        {
            var invoice = await _repository.FindById(id);
            await ThrowExceptionIfInvoiceItemsAreNotUpForSale(invoice);

            var totalPrice = await _repository.GetTotalPrice(invoice);

            invoice.CheckoutDate = checkoutDate;

            AddAccountingDocument(invoice, totalPrice);
            DecreaseWarehouseItemsStock(invoice);

            await _unitOfWork.CompleteAsync();
        }

        private void AddAccountingDocument(Invoice invoice, decimal totalPrice)
        {
            var accountingDocument = new AccountingDocument
            {
                InvoiceId = invoice.Id,
                DocumentRegistrationDate = (DateTime)invoice.CheckoutDate,
                DocumentNumber = DateTime.UtcNow.ToShortDateString(),
                TotalPrice = totalPrice
            };
            _accountingDocumentRepository.Add(accountingDocument);
        }

        private void DecreaseWarehouseItemsStock(Invoice invoice)
        {
            foreach (var invoiceItem in invoice.InvoiceItems)
                invoiceItem.WarehouseItem.Stock -= invoiceItem.Count;
        }

        private async Task ThrowExceptionIfInvoiceItemsAreNotUpForSale(Invoice invoice)
        {
            if (!await _repository.AreInvoiceItemsUpForSale(invoice))
            {
                throw new InvoiceItemsAreNotUpForSaleException
                {
                    InvoiceId = invoice.Id
                };
            }
        }
    }
}