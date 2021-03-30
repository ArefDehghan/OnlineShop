using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.InvoiceItems.Contracts
{
    public interface InvoiceItemRepository
    {
        void Add(InvoiceItem invoiceItem);
        void Delete(InvoiceItem invoiceItem);
        Task<InvoiceItem> FindById(int id);
        Task<bool> IsInvoiceItemUpForSale(InvoiceItem invoiceItem);
        Task<bool> IsInvoiceItemExistsInInvoice(int warehouseItemId, int invoiceId);
    }
}