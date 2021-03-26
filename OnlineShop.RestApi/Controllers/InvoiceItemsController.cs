using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.InvoiceItems.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/invoice-items")]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly InvoiceItemService _service;
        public InvoiceItemsController(InvoiceItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add(AddInvoiceItemDto addInvoiceItemDto)
        {
            return await _service.Add(addInvoiceItemDto);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}