using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.WarehouseItems.Contracts;

namespace OnlineShop.RestApi.Controllers
{
    [ApiController]
    [Route("api/warehouse-items")]
    public class WarehouseItemsController : ControllerBase
    {
        private readonly WarehouseItemService _service;
        public WarehouseItemsController(WarehouseItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IList<GetWarehouseItemDto>> GetWarehouseItems([FromQuery] FilterModelDto filter)
        {
            return await _service.GetWarehouseItems(filter);
        }
    }
}