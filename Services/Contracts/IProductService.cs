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

        void CreateProduct(ProductDtoForInsertion productDto);

        void UpdateProduct(ProductDtoForUpdate product);

        void DeleteOneProduct(int id);

        ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges);
    }
}