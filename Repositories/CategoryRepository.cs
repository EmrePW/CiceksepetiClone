using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Category> GetSubcategories(int id, bool trackChanges)
        {
            return GetAll(trackChanges).Where(cat => cat.SuperCategory.Equals(id));
        }
    }
}