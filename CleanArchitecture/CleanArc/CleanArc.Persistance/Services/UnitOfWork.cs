using CleanArc.Application.Interfaces;
using CleanArc.Persistance.SqlExceptionHandlers;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CleanArc.Persistance
{
    internal class UnitOfWork : IUnitOfWork
    {
        private TransactionScope transactionScope;
        private IDbContext dbContext;
        private ISqlExceptionHandler exceptionHandler;

        internal UnitOfWork(IDbContext dbContext, ISqlExceptionHandler exceptionHandler)
        {
            this.dbContext = dbContext;
            this.exceptionHandler = exceptionHandler;
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return this;
        }

        public void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
                if (transactionScope != null)
                    transactionScope.Complete();
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        private void Handle(Exception exception)
        {
            exceptionHandler.Handle(exception);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);

                if (transactionScope != null)
                {
                    transactionScope.Complete();
                }
            }
            catch (Exception e)
            {
                Handle(e);
            }
        }

        public void Add<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void BeginTransactionScope()
        {
            if (transactionScope != null)
                throw new InvalidOperationException("Cannot begin another transaction scope");

            transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled);
        }
  
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (transactionScope != null)
                    transactionScope.Dispose();
            }
        }
    }
}