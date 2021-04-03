using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Entities;
using OnlineShop.Services.Invoices.Contracts;

namespace OnlineShop.Persistence.EF.Invoices
{
    public class EFInvoiceRepository : InvoiceRepository
    {
        private readonly EFDataContext _context;
        public EFInvoiceRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
        }

        public async Task<Invoice> FindById(int id)
        {
            return await _context.Invoices.Include(invoice => invoice.InvoiceItems)
                .ThenInclude(invoiceItem => invoiceItem.WarehouseItem)
                .ThenInclude(_ => _.Product)
                .SingleOrDefaultAsync(invoice => invoice.Id == id);
        }

        public Task<decimal> GetTotalPrice(Invoice invoice)
        {
            return new TaskFactory().StartNew(() =>
                invoice.InvoiceItems.Sum(invoiceItem => invoiceItem.Price));
        }

        public Task<bool> AreInvoiceItemsUpForSale(Invoice invoice)
        {
            return new TaskFactory().StartNew(() =>
                (invoice.InvoiceItems.All(_ => 
                    (_.WarehouseItem.Stock - _.WarehouseItem.Product.MinimumStock) >= _.Count)));
        }

        public async Task<bool> IsInvoiceExists(int id)
        {
            return await _context.Invoices.AnyAsync(invoice => invoice.Id == id);
        }

        public async Task<bool> IsInvoiceNumberExists(string invoiceNumber)
        {
            return await _context.Invoices.AnyAsync(invoice => invoice.InvoiceNumber == invoiceNumber);
        }
    }
}