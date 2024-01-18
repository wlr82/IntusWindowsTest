using DAL.Entities;
using IntusWindowsTest.Server.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/order/")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order?> GetOrderById(int id)
        {
            return await _orderService.GetOrderById(id);
        }
    }
}
