using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        private readonly IOrderRepository _orderRepo;

        private readonly ICompanyRepository _companyRepo;

        private readonly IShipperRepository _shipperRepo;

        private readonly IRatingRepository _ratingsRepo;

        public RepositoryManager(RepositoryContext context, IProductRepository productRepo, ICategoryRepository categoryRepo, IOrderRepository orderRepo, ICompanyRepository companyRepo, IShipperRepository shipperRepo, IRatingRepository ratingsRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _orderRepo = orderRepo;
            _companyRepo = companyRepo;
            _shipperRepo = shipperRepo;
            _ratingsRepo = ratingsRepo;
        }

        public IProductRepository Product => _productRepo;

        public ICategoryRepository Category => _categoryRepo;

        public IOrderRepository Order => _orderRepo;

        public ICompanyRepository Company => _companyRepo;

        public IShipperRepository Shippers => _shipperRepo;

        public IRatingRepository Ratings => _ratingsRepo;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}