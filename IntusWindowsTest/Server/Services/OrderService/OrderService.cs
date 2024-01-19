using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public OrderService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> result = new();
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.Orders.GetAll().ToListAsync();
            }
            return result;
        }

        public async Task<Order?> GetOrderById(int orderId)
        {
            Order? dbOrder;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbOrder = await uow.Orders.GetByIdAsync(orderId);
            }

            return dbOrder;
        }

        public async Task<Order?> UpdateOrder(int orderId, Order order, CancellationToken ct)
        {
            Order? dbOrder;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbOrder = await uow.Orders.GetByIdAsync(orderId);
                var dbState = await uow.States.GetByIdAsync(order.State.Id, ct);
                if (dbOrder != null && dbState != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.State = dbState;
                }

                await uow.CompleteAsync(ct);
            }

            return dbOrder;
        }
    }
}
