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
                result = await uow.Windows
                    .GetAll()
                    .Include(w => w.Order)
                    .Include(w => w.SubElements)
                    .ThenInclude(s => s.ElementType)
                    .ToListAsync();
            }
            return result;
        }

        public async Task<List<Window>> GetWindowsByOrderId(int orderId)
        {
            List<Window> result = new();
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.Windows.GetWindowsByOrderId(orderId);
            }
            return result;
        }

        public async Task<Window?> GetWindowById(int windowId, CancellationToken cancellationToken)
        {
            Window? dbWindow;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbWindow = await uow.Windows.GetByIdAsync(windowId, cancellationToken);
            }

            return dbWindow;
        }

        public async Task<Window?> UpdateWindow(Window window, CancellationToken ct)
        {
            Window? dbWindow;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbWindow = await uow.Windows.GetByIdAsync(window.Id, ct);
                if (dbWindow != null)
                {
                    dbWindow.Name = window.Name;
                    dbWindow.QuantityOfWindows = window.QuantityOfWindows;

                    await uow.CompleteAsync(ct);
                }
            }

            return dbWindow;
        }

        public async Task<Window?> CreateWindow(Window window, CancellationToken ct)
        {
            Window? dbWindow;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                var dbOrder = await uow.Orders.GetByIdAsync(window.Order.Id, ct);
                if (dbOrder == null)
                {
                    return null;
                }
                var entWindow = new Window()
                {
                    Name = window.Name,
                    QuantityOfWindows = window.QuantityOfWindows,
                    Order = dbOrder
                };

                dbWindow = await uow.Windows.AddAndReturnEntityAsync(entWindow, ct);
                await uow.CompleteAsync(ct);
            }

            return dbWindow;
        }

        public async Task<bool> DeleteWindow(int windowId, CancellationToken ct)
        {
            bool result;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.Windows.DeleteByIdAsync(windowId, ct);
                if (result == false)
                {
                    return false;
                }

                await uow.CompleteAsync(ct);
            }

            return true;
        }
    }
}
