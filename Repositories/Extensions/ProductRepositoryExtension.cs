using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilterByPrice(this IQueryable<Product> products, decimal MinPrice, decimal MaxPrice, bool IsValidPrice)
        {
            if (!IsValidPrice)
            {
                return products;
            }
            return products.Where(prd => prd.UnitPrice > MinPrice && prd.UnitPrice < MaxPrice);
        }

        public static IQueryable<Product> FilterByKeyword(this IQueryable<Product> products, String? keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                return products;
            }
            return products.Where(prd => prd.ProductName.ToLower().Contains(keyword.ToLower()));
        }

        public static IQueryable<Product> FilterBySubCategory(this IQueryable<Product> products, int? categoryID)
        {
            if (categoryID is null)
            {
                return products;
            }
            return products.Where(prd => prd.CategoryID.Equals(categoryID));
        }
    }
}