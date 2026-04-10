using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.StateService
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _uow;

        public StateService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<State>> GetStates()
        {
            return await _uow.States.GetAll().ToListAsync();
        }
    }
}
