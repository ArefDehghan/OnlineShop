using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Invoices.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _service;
        public InvoicesController(InvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<int> Add(AddInvoiceDto addInvoiceDto)
        {
            return await _service.Add(addInvoiceDto);
        }

        [HttpPut("{id}")]
        public async Task Checkout(int id, [FromBody] DateTime checkoutDate)
        {
            await _service.Checkout(id, checkoutDate);
        }
    }
}