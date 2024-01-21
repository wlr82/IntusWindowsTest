using DAL.Entities;

namespace IntusWindowsTest.Server.Services.WindowsService
{
    public interface IWindowService
    {
        Task<List<Window>> GetWindows();
        Task<List<Window>> GetWindowsByOrderId(int orderId);
        Task<Window?> GetWindowById(int windowId, CancellationToken cancellationToken);
        Task<Window?> UpdateWindow(Window window, CancellationToken cancellationToken);
        Task<Window?> CreateWindow(Window window, CancellationToken cancellationToken);
        Task<bool> DeleteWindow(int windowId, CancellationToken cancellationToken);
    }
}
