using System.Collections.Generic;
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
        public async Task<IList<GetProductCategoryDto>> GetProductCategories(int id)
        {
            return await _service.GetProductCategories();
        }

        [HttpPost]
        public async Task<int> Add([FromBody] string title)
        {
            return await _service.Add(title);
        }
    }
}