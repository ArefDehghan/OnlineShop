using System.Threading.Tasks;

namespace OnlineShop.Services.Invoices.Contracts
{
    public interface InvoiceService
    {
        Task<int> Add(AddInvoiceDto addInvoiceDto);
    }
}