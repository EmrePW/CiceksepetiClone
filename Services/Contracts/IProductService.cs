using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);

        IQueryable<Product> GetProductsWithFiltering(ProductRequestParameters parameters, bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);

        IQueryable<Product> getCompanyProducts(int? id);

        IQueryable<Product> getMostRatedWithFiltering(ProductRequestParameters parameters);
        IQueryable<Product> getMostLikedWithFiltering(ProductRequestParameters parameters);

        IQueryable<Product> getOutofStockProducts(int? companyID);

        public void DecrementStock(int id);

        void CreateProduct(ProductDtoForInsertion productDto);

        void UpdateProduct(ProductDtoForUpdate product);

        void DeleteOneProduct(int id);

        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);


    }
}