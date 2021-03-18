using System.Threading.Tasks;

namespace OnlineShop.Services.Products.Contracts
{
    public interface ProductService
    {
        Task<int> Add(AddProductDto addProductDto);
        Task<GetProductDto> GetById(int id);
    }
}