using System.Threading.Tasks;
using OnlineShop.Entities;
using OnlineShop.Services.Purchases.Contracts;

namespace OnlineShop.Persistence.EF.Purchases
{
    public class EFPurchaseRepository : PurchaseRepository
    {
        private readonly EFDataContext _context;
        public EFPurchaseRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Purchase purchase)
        {
            _context.Purchases.Add(purchase);
        }

        public async Task<Purchase> FindById(int id)
        {
            return await _context.Purchases.FindAsync(id);
        }
    }
}