using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _uow.Orders.GetAll().ToListAsync();
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            return await _uow.Orders.GetByIdAsync(orderId);
        }

        public async Task<Order?> UpdateOrder(int orderId, Order order, CancellationToken ct)
        {
            var dbOrder = await _uow.Orders.GetByIdAsync(orderId);
            var dbState = await _uow.States.GetByIdAsync(order.State.Id, ct);
            if (dbOrder == null || dbState == null)
                return null;

            dbOrder.Name = order.Name;
            dbOrder.State = dbState;

            await _uow.CompleteAsync(ct);
            return dbOrder;
        }

        public async Task<Order?> CreateOrder(Order order, CancellationToken ct)
        {
            var dbState = await _uow.States.GetByIdAsync(order.State.Id, ct);
            var entOrder = new Order()
            {
                Name = order.Name,
                State = dbState
            };

            var dbOrder = await _uow.Orders.AddAndReturnEntityAsync(entOrder, ct);
            await _uow.CompleteAsync(ct);
            return dbOrder;
        }

        public async Task<bool> DeleteOrder(int orderId, CancellationToken ct)
        {
            var result = await _uow.Orders.DeleteByIdAsync(orderId, ct);
            if (!result)
                return false;

            await _uow.CompleteAsync(ct);
            return true;
        }
    }
}
