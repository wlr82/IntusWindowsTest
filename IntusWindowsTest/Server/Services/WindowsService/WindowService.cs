using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.WindowsService
{
    public class WindowService : IWindowService
    {
        private readonly IUnitOfWork _uow;

        public WindowService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Window>> GetWindows()
        {
            return await _uow.Windows
                .GetAll()
                .Include(w => w.Order)
                .Include(w => w.SubElements)
                .ThenInclude(s => s.ElementType)
                .ToListAsync();
        }

        public async Task<List<Window>> GetWindowsByOrderId(int orderId)
        {
            return await _uow.Windows.GetWindowsByOrderId(orderId);
        }

        public async Task<Window?> GetWindowById(int windowId, CancellationToken cancellationToken)
        {
            return await _uow.Windows.GetByIdAsync(windowId, cancellationToken);
        }

        public async Task<Window?> UpdateWindow(Window window, CancellationToken ct)
        {
            var dbWindow = await _uow.Windows.GetByIdAsync(window.Id, ct);
            if (dbWindow == null)
                return null;

            dbWindow.Name = window.Name;
            dbWindow.QuantityOfWindows = window.QuantityOfWindows;

            await _uow.CompleteAsync(ct);
            return dbWindow;
        }

        public async Task<Window?> CreateWindow(Window window, CancellationToken ct)
        {
            var dbOrder = await _uow.Orders.GetByIdAsync(window.Order.Id, ct);
            if (dbOrder == null)
                return null;

            var entWindow = new Window()
            {
                Name = window.Name,
                QuantityOfWindows = window.QuantityOfWindows,
                Order = dbOrder
            };

            var dbWindow = await _uow.Windows.AddAndReturnEntityAsync(entWindow, ct);
            await _uow.CompleteAsync(ct);
            return dbWindow;
        }

        public async Task<bool> DeleteWindow(int windowId, CancellationToken ct)
        {
            var result = await _uow.Windows.DeleteByIdAsync(windowId, ct);
            if (!result)
                return false;

            await _uow.CompleteAsync(ct);
            return true;
        }
    }
}
