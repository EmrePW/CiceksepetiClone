using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackChanges);

        T? GetByCondition(Expression<Func<T, bool>> condition, bool trackChanges);

        void CreateEntity(T entity);

        void UpdateEntity(T entity);

        void DeleteEntity(T entity);

    }
}