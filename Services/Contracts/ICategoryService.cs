using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);

        IEnumerable<Category> GetAllSubCategories(int categoryID, bool trackChanges);
    }
}