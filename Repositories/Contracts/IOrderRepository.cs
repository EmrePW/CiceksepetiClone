using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        IQueryable<Order> Orders { get; }

        Order? GetOrder(int id);

        Order? GetByTracking(int id);

        void CompleteOrder(int id);

        void SaveOrder(Order order);

        int NumberOfOrdersInProgress { get; }
    }
}