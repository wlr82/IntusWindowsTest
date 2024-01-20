using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IWindowsRepository : IRepository<Window, int>
    {
        Task<List<Window>> GetWindowsByOrderId(int orderId);
    }
}
