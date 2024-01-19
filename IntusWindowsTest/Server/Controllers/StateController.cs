using DAL.Entities;
using IntusWindowsTest.Server.Services.StateService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/state/")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<List<State>> GetStates()
        {
            return await _stateService.GetStates();
        }
    }
}
