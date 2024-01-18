using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class OrdersRepository : Repository<Order, int>, IOrdersRepository
    {
        private readonly ApplicationDBContext _context;

        public OrdersRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Order> GetAll()
        {
            return base.GetAll().Include(o => o.State);
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders.Include(o => o.State).FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
