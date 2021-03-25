using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Infrastructure.Application;
using OnlineShop.Services.Invoices.Contracts;
using OnlineShop.Services.Invoices.Exceptions;

namespace OnlineShop.Services.Invoices
{
    public class InvoiceAppService : InvoiceService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly InvoiceRepository _repository;
        public InvoiceAppService(InvoiceRepository repository, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(AddInvoiceDto addInvoiceDto)
        {
            var invoice = new Invoice
            {
                CustomerName = addInvoiceDto.CustomerName,
                InvoiceNumber = addInvoiceDto.InvoiceNumber,
                CheckoutDate = addInvoiceDto.CheckoutDate
            };

            ThrowExceptionIfInvoiceNumberIsAlreadyExists(addInvoiceDto.InvoiceNumber);

            _repository.Add(invoice);
            await _unitOfWork.CompleteAsync();

            return invoice.Id;
        }

        private async void ThrowExceptionIfInvoiceNumberIsAlreadyExists(string invoiceNumber)
        {
            if (await _repository.IsInvoiceNumberExists(invoiceNumber))
            {
                throw new InvoiceNumberIsAlreadyExistsException
                {
                    InvoiceNumber = invoiceNumber
                };
            }
        }
    }
}