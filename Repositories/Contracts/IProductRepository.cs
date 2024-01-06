using Entities.Models;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> getAllProducts(bool trackChanges);

        IQueryable<Product> getProductsWithFilters(ProductRequestParameters parameters, bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);

        void CreateProduct(Product product);

        void DeleteProduct(Product product);

        void UpdateProduct(Product product);

        public IQueryable<Product> getCompanyProducts(int? id);

        public IQueryable<Product> getMostRatedProducts(ProductRequestParameters parameters);
        public IQueryable<Product> getMostLikedProducts(ProductRequestParameters parameters);

        public IQueryable<Product> getOutOfStockProducts(int? companyID);

        public void decrementStock(int id);
    }
}