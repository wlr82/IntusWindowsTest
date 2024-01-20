using DAL.Entities;

namespace IntusWindowsTest.Server.Services.WindowsService
{
    public interface IWindowService
    {
        Task<List<Window>> GetWindows();
    }
}
