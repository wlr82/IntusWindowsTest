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
    }
}
