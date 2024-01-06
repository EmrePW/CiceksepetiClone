using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.CreateEntity(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product product = GetOneProduct(id, false) ?? new Product();
            _manager.Product.DeleteProduct(product);
            _manager.Save();
        }
        public void UpdateProduct(ProductDtoForUpdate productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateProduct(product);
            _manager.Save();
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.getAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            return (product is null) ? throw new Exception("product with this id not found!") : product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackChanges)
        {
            var product = GetOneProduct(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IQueryable<Product> GetProductsWithFiltering(ProductRequestParameters parameters, bool trackChanges)
        {
            return _manager.Product.getProductsWithFilters(parameters, trackChanges);
        }

        public IQueryable<Product> getCompanyProducts(int? id)
        {
            return _manager.Product.getCompanyProducts(id);
        }

        public IQueryable<Product> getMostRatedWithFiltering(ProductRequestParameters parameters)
        {
            return _manager.Product.getMostRatedProducts(parameters);
        }

        public IQueryable<Product> getMostLikedWithFiltering(ProductRequestParameters parameters)
        {
            return _manager.Product.getMostLikedProducts(parameters);
        }

        public IQueryable<Product> getOutofStockProducts(int? companyID)
        {
            return _manager.Product.getOutOfStockProducts(companyID);
        }

        public void DecrementStock(int id)
        {
            _manager.Product.decrementStock(id);
        }
    }
}