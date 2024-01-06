using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;
        public int numberOfInProgress => _manager.Order.NumberOfOrdersInProgress;

        public void CompleteOrder(int id)
        {
            _manager.Order.CompleteOrder(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.Order.Orders.Where(order => order.OrderID.Equals(id)).FirstOrDefault();
        }

        public Order? GetOrderByTracking(int trackId)
        {
            return _manager.Order.Orders.Where(order => order.trackingNumber.Equals(trackId)).FirstOrDefault();
        }

        public IQueryable<Order> GetOrdersbyUser(string? userid)
        {
            return _manager.Order.Orders.Where(order => order.Customer.Id.Equals(userid));
        }

        public void SaveOrder(Order order)
        {
            _manager.Order.SaveOrder(order);
        }
    }
}