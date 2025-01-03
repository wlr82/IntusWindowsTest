﻿using DAL.Entities.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IStatesRepository States { get; }
        IOrdersRepository Orders { get; }
        IWindowsRepository Windows { get; }
        IElementTypesRepository ElementTypes { get; }
        ISubElementsRepository SubElements { get; }
        
        Task<int> CompleteAsync(CancellationToken cancellationToken);

        IRepository<TEntity, TIdentity> GetRepository<TEntity, TIdentity>()
            where TEntity : class, IEntity<TIdentity>
            where TIdentity : IEquatable<TIdentity>;

        Task UseTransaction(IDbContextTransaction transaction, CancellationToken cancellationToken);

        Task CommitTransaction(CancellationToken cancellationToken);
    }
}
