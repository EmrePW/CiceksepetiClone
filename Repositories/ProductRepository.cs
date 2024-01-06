using Entities.Models;
using Entities.RequestParameters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateProduct(Product product)
        {
            CreateEntity(product);
        }

        public void DeleteProduct(Product product)
        {
            DeleteEntity(product);
        }
        public void UpdateProduct(Product product)
        {
            UpdateEntity(product);
        }

        public IQueryable<Product> getAllProducts(bool trackChanges) => GetAll(trackChanges);


        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return GetByCondition(product => product.ProductID.Equals(id), trackChanges);
        }

        public IQueryable<Product> getProductsWithFilters(ProductRequestParameters parameters, bool trackChanges)
        {
            var sql_result = _context.Products
            .FromSqlInterpolated($"exec up_GetProductsWithFiltering {parameters.searchKeyword}, {parameters.MinPrice}, {parameters.MaxPrice}").ToList();

            var result = parameters.subCategory is not null ? sql_result.Where(prd => prd.CategoryID.Equals(parameters.subCategory)) : sql_result;

            return result.AsQueryable();
        }

        public IQueryable<Product> getCompanyProducts(int? id)
        {
            if (id is null)
            {
                return GetAll(false);
            }
            var sql_result = _context.Products.FromSqlInterpolated($"select * from dbo.getProductsByCompany({id})");

            return sql_result;
        }

        public IQueryable<Product> getMostRatedProducts(ProductRequestParameters parameters)
        {
            var sql_result = _context.Products.FromSqlInterpolated($"select * from dbo.getMostRatedProducts()")
            .Where(prd => prd.ProductName.Contains(parameters.searchKeyword ?? ""))
            .Where(prd => (prd.DiscountedPrice ?? prd.UnitPrice) < parameters.MaxPrice)
            .Where(prd => (prd.DiscountedPrice ?? prd.UnitPrice) >= parameters.MinPrice);

            return sql_result;
        }

        public IQueryable<Product> getMostLikedProducts(ProductRequestParameters parameters)
        {
            var sql_result = _context.Products.FromSqlInterpolated($"select * from dbo.getMostLikedProducts()")
            .Where(prd => prd.ProductName.Contains(parameters.searchKeyword ?? ""))
            .Where(prd => (prd.DiscountedPrice ?? prd.UnitPrice) < parameters.MaxPrice)
            .Where(prd => (prd.DiscountedPrice ?? prd.UnitPrice) >= parameters.MinPrice);
            return sql_result;
        }

        public IQueryable<Product> getOutOfStockProducts(int? companyID)
        {
            if (companyID is null)
            {
                return GetAll(false);
            }
            var sql_result = _context.Products.FromSqlInterpolated($"exec up_GetOutOfStockProducts {companyID}");

            return sql_result;
        }

        public void decrementStock(int id)
        {
            _context.Database.ExecuteSqlInterpolated($"exec up_DecrementProductCount {id}");
        }
    }
}