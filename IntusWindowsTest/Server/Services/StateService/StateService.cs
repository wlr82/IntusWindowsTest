using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.StateService
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public StateService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<State>> GetStates()
        {
            List<State> result = new();
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.States.GetAll().ToListAsync();
            }
            return result;
        }
    }
}
