using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.WindowsService
{
    public class WindowService : IWindowService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public WindowService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<Window>> GetWindows()
        {
            List<Window> result = new();
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.Windows.GetAll().Include(w => w.Order).ToListAsync();
            }
            return result;
        }
    }
}
