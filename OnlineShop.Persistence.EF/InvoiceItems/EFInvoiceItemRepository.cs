using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await _context.InvoiceItems.Include(_ => _.Invoice)
                .Include(_ => _.WarehouseItem)
                .ThenInclude(_ => _.Product)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<bool> IsInvoiceItemExistsInInvoice(int warehouseItemId, int invoiceId)
        {
            return await _context.InvoiceItems.AnyAsync(_ => _.WarehouseItemId == warehouseItemId && _.InvoiceId == invoiceId);
        }

        public Task<bool> IsInvoiceItemUpForSale(InvoiceItem invoiceItem)
        {
            return new TaskFactory().StartNew(() =>
                ((invoiceItem.WarehouseItem.Stock - 
                    invoiceItem.WarehouseItem.Product.MinimumStock)
                    >= invoiceItem.Count));
        }
    }
}