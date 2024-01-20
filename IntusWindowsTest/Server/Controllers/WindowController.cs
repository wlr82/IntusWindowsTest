using DAL.Entities;
using IntusWindowsTest.Server.Services.WindowsService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/window/")]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet]
        public async Task<List<Window>> GetWindows()
        {
            return await _windowService.GetWindows();
        }
    }
}
