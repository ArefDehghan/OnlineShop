using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Purchases.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchasesController : ControllerBase
    {
        private readonly PurchaseService _service;
        public PurchasesController(PurchaseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add(AddPurchaseDto addPurchaseDto)
        {
            return await _service.Add(addPurchaseDto);
        }
    }
}