using DAL.Entities.Contracts;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<TEntity, TIdentity> : IRepository<TEntity, TIdentity>
      where TEntity : class, IEntity<TIdentity>
      where TIdentity : IEquatable<TIdentity>
    {
        protected ApplicationDBContext Context;
        protected DbSet<TEntity> DbSet;
        private bool _disposed;

        public Repository(ApplicationDBContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual async Task AddAsync(TEntity? entity, CancellationToken cancellationToken)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                Context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> AddAndReturnEntityAsync(TEntity? entity, CancellationToken cancellationToken)
        {
            var entityEntry = await DbSet.AddAsync(entity, cancellationToken);
            return entityEntry.Entity;
        }

        public async Task<TEntity?> GetByIdAsync(TIdentity id, CancellationToken cancellationToken)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public async Task<bool> DeleteByIdAsync(TIdentity id, CancellationToken cancellationToken)
        {
            var dbEntity = await DbSet.FindAsync(id, cancellationToken);
            if (dbEntity == null)
            {
                return false;
            }

            DbSet.Remove(dbEntity);
            return true;
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
