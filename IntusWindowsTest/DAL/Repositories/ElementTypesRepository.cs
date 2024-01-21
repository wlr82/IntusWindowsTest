using DAL.Entities;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class ElementTypesRepository : Repository<ElementType, int>, IElementTypesRepository
    {
        public ElementTypesRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
