using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly ICompanyService _companyService;
        private readonly IShipperService _shipperService;

        private readonly IOrderService _orderService;

        private readonly IRatingService _ratingService;

        public ServiceManager(IProductService productService, ICategoryService categoryService, ICompanyService companyService, IShipperService shipperService, IOrderService orderService, IRatingService ratingService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _companyService = companyService;
            _shipperService = shipperService;
            _orderService = orderService;
            _ratingService = ratingService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public ICompanyService CompanyService => _companyService;

        public IShipperService ShipperService => _shipperService;

        public IOrderService OrderService => _orderService;

        public IRatingService RatingService => _ratingService;
    }
}