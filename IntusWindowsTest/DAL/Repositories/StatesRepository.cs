using DAL.Entities;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class StatesRepository : Repository<State, int>, IStatesRepository
    {
        public StatesRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
