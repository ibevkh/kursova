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
        public ActionResult<List<OrderDto>> GetOrders()
        {
            return Ok(_orderService.GetOrdersAsync());
        }

        [HttpPost]
        public ActionResult<OrderDto> AddOrder(OrderDto order)
        {
            return Ok(_orderService.AddOrderAsync(order));
        }
    }
}
