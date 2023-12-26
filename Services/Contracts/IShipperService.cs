using Entities.Models;

namespace Services.Contracts
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetAllShippers(bool trackChanges);
    }
}