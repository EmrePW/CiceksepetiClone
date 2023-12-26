using Entities.Models;
using Entities.RequestParameters;
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
            return _context
            .Products
            .FilterBySubCategory(parameters.subCategory)
            .FilterByKeyword(parameters.searchKeyword)
            .FilterByPrice(parameters.MinPrice, parameters.MaxPrice, parameters.IsValidPrice);
        }
    }
}