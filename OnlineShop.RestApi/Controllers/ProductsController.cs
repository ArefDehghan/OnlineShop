using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Products;
using OnlineShop.Services.Products.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<GetProductDto> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<int> Add(AddProductDto addProductDto)
        {
            return await _service.Add(addProductDto);
        }
    }
}