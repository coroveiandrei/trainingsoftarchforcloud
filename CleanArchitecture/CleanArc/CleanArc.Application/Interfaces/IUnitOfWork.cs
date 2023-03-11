using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Interfaces
{
  
    public interface IUnitOfWork : IRepository, IDisposable
    {
        void SaveChanges();
      
        Task SaveChangesAsync(CancellationToken cancellationToken);

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void BeginTransactionScope();
    }
}