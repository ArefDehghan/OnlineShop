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

        public async Task<bool> IsInvoiceExists(int id)
        {
            return await _context.Invoices.AnyAsync(_ => _.Id == id);
        }

        public async Task<bool> IsInvoiceNumberExists(string invoiceNumber)
        {
            return await _context.Invoices.AnyAsync(_ => _.InvoiceNumber == invoiceNumber);
        }
    }
}