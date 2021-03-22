using System.Threading.Tasks;

namespace OnlineShop.Services.Purchases.Contracts
{
    public interface PurchaseService
    {
        Task<int> Add(AddPurchaseDto addPurchaseDto);
    }
}