using DAL.Entities.Contracts;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        private bool _disposed;

        public IStatesRepository States { get; }

        public IOrdersRepository Orders { get; }

        public IDbContextTransaction Transaction { get; private set; }

        public IWindowsRepository Windows { get; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<Type, object>();

            States = new StatesRepository(context);
            Orders = new OrdersRepository(context);
            Windows = new WindowsRepository(context);
        }

        public Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _context.Dispose();

            _disposed = true;
        }

        public IRepository<TEntity, TIdentity> GetRepository<TEntity, TIdentity>()
            where TEntity : class, IEntity<TIdentity>
            where TIdentity : IEquatable<TIdentity>
        {
            return _repositories.GetOrAdd(typeof(TEntity), new Repository<TEntity, TIdentity>(_context)) as IRepository<TEntity, TIdentity>;
        }

        public async Task UseTransaction(IDbContextTransaction transaction, CancellationToken cancellationToken)
        {
            var dbTransaction = transaction.GetDbTransaction();
            _context.Database.SetDbConnection(dbTransaction.Connection);
            await _context.Database.UseTransactionAsync(dbTransaction, cancellationToken);
            Transaction = transaction;
        }

        public async Task CommitTransaction(CancellationToken cancellationToken)
        {
            if (Transaction == null) return;

            await Transaction.CommitAsync(cancellationToken);
            await Transaction.DisposeAsync();

            Transaction = null;
        }
    }
}
