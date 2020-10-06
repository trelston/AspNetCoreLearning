using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleWebApiService.Models;

namespace SampleWebApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        
        private readonly ILogger<OrderDetailsController> _logger;

        public OrderDetailsController(ILogger<OrderDetailsController> logger)
        {
            _logger = logger;
        }
        
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.OrderDetailsDto>>> Get(
            [FromQuery] string name)
        {
            var result = await Task.FromResult(new OrderDetailsDto()
            {
                DeliveryDate = null,
                Discount = null,
                Name = name,
                OrderAmount = 100,
                OrderDate = DateTime.Now,
                OrderId = Guid.NewGuid(),
                OrderNo = "ABC1234",
                Quantity = 2
            });
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDetailsDto>> GetById(int orderId)
        {
            var result = await Task.FromResult(new OrderDetailsDto()
            {
                DeliveryDate = null,
                Discount = null,
                Name = "TestGetById",
                OrderAmount = 1000,
                OrderDate = DateTime.Now,
                OrderId = Guid.NewGuid(),
                OrderNo = "ABC1234_" + orderId,
                Quantity = 2
            });
            return Ok(result);
        }
    }
}