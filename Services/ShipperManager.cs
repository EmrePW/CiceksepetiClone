using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ShipperManager : IShipperService
    {
        private readonly IRepositoryManager _manager;

        public ShipperManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Shipper> GetAllShippers(bool trackChanges)
        {
            return _manager.Shippers.GetAll(trackChanges);
        }
    }
}