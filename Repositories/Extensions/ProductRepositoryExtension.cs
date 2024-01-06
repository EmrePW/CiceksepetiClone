using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {

        public static IQueryable<Product> FilterBySubCategory(this IQueryable<Product> products, int? categoryID)
        {
            if (categoryID is null)
            {
                return products;
            }
            var result = products.Where(prd => prd.CategoryID.Equals(categoryID));
            return result;
        }
    }
}