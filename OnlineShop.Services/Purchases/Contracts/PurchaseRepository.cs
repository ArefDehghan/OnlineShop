using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.Services.Purchases.Contracts
{
    public interface PurchaseRepository
    {
        void Add(Purchase purchase);
        Task<Purchase> FindById(int id);
        Task<bool> IsInvoiceNumberExists(string InvoiceNumber);
    }
}