using System.Linq;

namespace CleanArc.Application.Interfaces
{
    public interface IRepository
    {
        public IUnitOfWork CreateUnitOfWork();
        public IQueryable<T> GetEntities<T>() where T : class;
    }
}