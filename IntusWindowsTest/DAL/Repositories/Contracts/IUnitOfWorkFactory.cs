using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork MakeUnitOfWork();
        Task<IUnitOfWork> MakeUnitOfWorkUsingTransaction(IDbContextTransaction? transaction, CancellationToken cancellationToken);
    }
}
