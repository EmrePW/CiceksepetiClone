using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }

        Order? GetOneOrder(int id);

        Order? GetOrderByTracking(int trackId);

        IQueryable<Order> GetOrdersbyUser(string? userid);

        void CompleteOrder(int id);

        void SaveOrder(Order order);

        int numberOfInProgress { get; }
    }
}