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

        [HttpPut("{id}")]
        public async Task<Order?> UpdateOrder(int id, Order order, CancellationToken ct)
        {
            return await _orderService.UpdateOrder(id, order, ct);
        }

        [HttpPost]
        public async Task<Order?> CreateOrder(Order order, CancellationToken ct)
        {
            return await _orderService.CreateOrder(order, ct);
        }
    }
}
