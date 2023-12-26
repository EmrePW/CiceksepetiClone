using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(RepositoryContext context) : base(context)
        {
        }
    }
}