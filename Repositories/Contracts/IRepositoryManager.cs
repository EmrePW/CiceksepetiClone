namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        ICompanyRepository Company { get; }
        IShipperRepository Shippers { get; }

        IRatingRepository Ratings { get; }

        public void Save();


    }
}