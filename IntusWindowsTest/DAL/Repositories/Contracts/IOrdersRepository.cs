using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IOrdersRepository : IRepository<Order, int>
    {
        Task<Order?> GetByIdAsync(int orderId);
    }
}
