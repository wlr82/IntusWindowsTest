using DAL.Entities;

namespace IntusWindowsTest.Server.Services.WindowsService
{
    public interface IWindowService
    {
        Task<List<Window>> GetWindows();
        Task<List<Window>> GetWindowsByOrderId(int orderId);
    }
}
