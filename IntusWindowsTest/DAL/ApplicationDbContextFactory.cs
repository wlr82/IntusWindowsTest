using DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ApplicationDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ApplicationDBContext Create()
        {
            return new ApplicationDBContext(_options);
        }
    }
}
