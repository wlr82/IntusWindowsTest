using DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class ApplicationDbContextFactoryInitializer
    {
        public static IApplicationDbContextFactory Create(string dbConnectionString)
        {
            if (string.IsNullOrWhiteSpace(dbConnectionString))
                throw new ArgumentNullException(nameof(dbConnectionString));

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            optionsBuilder
                .UseMySQL(dbConnectionString);

            return new ApplicationDbContextFactory(optionsBuilder.Options);
        }
    }
}
