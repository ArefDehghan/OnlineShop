using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.Invoices.Contracts
{
    public interface InvoiceRepository
    {
        void Add(Invoice invoice);    
        Task<Invoice> FindById(int id);
        Task<decimal> GetTotalPrice(Invoice invoice);
        Task<bool> AreInvoiceItemsUpForSale(Invoice invoice);
        Task<bool> IsInvoiceNumberExists(string invoiceNumber);
        Task<bool> IsInvoiceExists(int id);
    }
}