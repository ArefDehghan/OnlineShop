using System.Threading.Tasks;

namespace OnlineShop.Services.InvoiceItems.Contracts
{
    public interface InvoiceItemService
    {
        Task<int> Add(AddInvoiceItemDto addInvoiceItemDto);
        Task Delete(int id);
    }
}