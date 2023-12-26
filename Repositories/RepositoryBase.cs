using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void CreateEntity(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
        }

        public T? GetByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
        {
            return trackChanges ? _context.Set<T>().Where(condition).SingleOrDefault()
                                : _context.Set<T>().Where(condition).AsNoTracking().SingleOrDefault();
        }

    }
}

