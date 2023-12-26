namespace Services.Contracts
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
        public ICompanyService CompanyService { get; }
        public IShipperService ShipperService { get; }

        public IOrderService OrderService { get; }

        public IRatingService RatingService { get; }
    }
}