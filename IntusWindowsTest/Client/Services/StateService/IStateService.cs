using DAL.Entities;

namespace IntusWindowsTest.Client.Services.StateService
{
    public interface IStateService
    {
        List<State> States { get; set; }

        Task GetStates();
    }
}
