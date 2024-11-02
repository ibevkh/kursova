using courseWork.Dto;
using courseWork.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace courseWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            var orders = await _orderService.GetOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> AddOrder(OrderDto order)
        {
            var createdOrder = await _orderService.AddOrderAsync(order);
            return Ok(createdOrder);
        }
    }

}
