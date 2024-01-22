using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class WindowsRepository : Repository<Window, int>, IWindowsRepository
    {
        private readonly ApplicationDBContext _context;

        public WindowsRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Window>> GetWindowsByOrderId(int orderId)
        {
            return await base
                .GetAll()
                .Include(w => w.Order)
                .Where(w => w.Order.Id == orderId)
                .Include(w => w.SubElements)
                .ToListAsync();
        }
    }
}
