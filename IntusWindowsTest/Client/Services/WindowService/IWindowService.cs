using DAL.Entities;

namespace IntusWindowsTest.Client.Services.WindowService
{
    public interface IWindowService
    {
        List<Window> Windows { get; set; }
        Task GetWindowsByOrderId(int orderId);
        Task<Window?> GetWindowById(int id);
        Task UpdateWindow(Window window);
        Task CreateWindow(Window window);
        Task DeleteWindow(int orderId, int windowId);
    }
}
