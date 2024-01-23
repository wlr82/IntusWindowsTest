using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SubElementsRepository : Repository<SubElement, int>, ISubElementsRepository
    {
        public SubElementsRepository(ApplicationDBContext context) : base(context)
        {
        }

        public override async Task<SubElement?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {

            return await base.GetAll()
                .Include(s => s.ElementType)
                .Include(s => s.Window)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }
    }
}
