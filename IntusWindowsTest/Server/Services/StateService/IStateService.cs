using DAL.Entities;

namespace IntusWindowsTest.Server.Services.StateService
{
    public interface IStateService
    {
        Task<List<State>> GetStates();
    }
}
