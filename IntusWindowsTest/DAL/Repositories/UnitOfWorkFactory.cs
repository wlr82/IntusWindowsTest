using DAL.Contracts;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IApplicationDbContextFactory _dbContextFactory;

        public UnitOfWorkFactory(IApplicationDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork MakeUnitOfWork()
        {
            return new UnitOfWork(_dbContextFactory.Create());
        }

        public async Task<IUnitOfWork> MakeUnitOfWorkUsingTransaction(IDbContextTransaction? transaction, CancellationToken cancellationToken)
        {
            var uow = MakeUnitOfWork();

            if (transaction != null) await uow.UseTransaction(transaction, cancellationToken);

            return uow;
        }
    }
}
