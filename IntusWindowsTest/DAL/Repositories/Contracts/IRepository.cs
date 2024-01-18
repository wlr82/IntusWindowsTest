using DAL.Entities.Contracts;

namespace DAL.Repositories.Contracts
{
    public interface IRepository<TEntity, in TIdentity> : IDisposable
        where TEntity : class, IEntity<TIdentity>
        where TIdentity : IEquatable<TIdentity>
    {
        IQueryable<TEntity> GetAll();
        Task AddAsync(TEntity? entity, CancellationToken cancellationToken);
        Task<TEntity> AddAndReturnEntityAsync(TEntity? entity, CancellationToken cancellationToken);
        Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken);
    }
}
