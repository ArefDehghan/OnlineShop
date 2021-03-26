using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Services.InvoiceItems.Contracts;

namespace OnlineShop.Persistence.EF.InvoiceItems
{
    public class EFInvoiceItemRepository : InvoiceItemRepository
    {
        private readonly EFDataContext _context;
        public EFInvoiceItemRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Add(invoiceItem);
        }

        public void Delete(InvoiceItem invoiceItem)
        {
            _context.InvoiceItems.Remove(invoiceItem);
        }

        public async Task<InvoiceItem> FindById(int id)
        {
            return await _context.InvoiceItems.FindAsync(id);
        }
    }
}