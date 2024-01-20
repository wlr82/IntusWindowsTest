using DAL.Entities;

namespace IntusWindowsTest.Client.Services.OrderService
{
    public interface IOrderService
    {
        List<Order> Orders { get; set; }
        Task GetOrders();
        Task<Order?> GetOrderById(int id);
        Task CreateOrder(Order order);
        Task UpdateOrder(int id, Order order);
        Task DeleteOrder(int id);
    }
}
