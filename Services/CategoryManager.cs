using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.GetAll(trackChanges);
        }

        public IEnumerable<Category> GetAllSubCategories(int categoryID, bool trackChanges)
        {
            return _manager.Category.GetSubcategories(categoryID, trackChanges);
        }
    }
}