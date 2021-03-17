using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.ProductCategories.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/product-categories")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ProductCategoryService _service;
        public ProductCategoriesController(ProductCategoryService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public Task<GetProductCategoryDto> GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public Task<int> Add(AddProductCategoryDto addProductCategoryDto)
        {
            return _service.Add(addProductCategoryDto);
        }
    }
}