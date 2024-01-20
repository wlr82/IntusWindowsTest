using DAL.Entities;

namespace IntusWindowsTest.Client.Services.WindowService
{
    public interface IWindowService
    {
        List<Window> Windows { get; set; }
        Task GetWindowsByOrderId(int orderId);
    }
}
