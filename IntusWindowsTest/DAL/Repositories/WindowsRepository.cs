using DAL.Entities;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class WindowsRepository : Repository<Window, int>, IWindowsRepository
    {
        public WindowsRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
