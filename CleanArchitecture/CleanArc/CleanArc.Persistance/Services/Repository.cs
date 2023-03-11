using Microsoft.EntityFrameworkCore;
using CleanArc.Application.Interfaces;
using CleanArc.Common;
using CleanArc.Persistance.SqlExceptionHandlers;
using System.Linq;

namespace CleanArc.Persistance
{
    [MapServiceDependency(nameof(Repository))]
    internal class Repository : IRepository
    {
        
        private readonly IDbContext context;   
        private ISqlExceptionHandler exceptionHandler;
        public Repository(IDbContext context, ISqlExceptionHandler exceptionHandler)
        {
            this.context = context;
            this.exceptionHandler = exceptionHandler;
        }


        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(context, exceptionHandler);
        }

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return context.Set<T>().AsNoTracking();
        }
    }
}