using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
        .Include(order => order.Items)
        .ThenInclude(CartLine => CartLine.Product);

        public int NumberOfOrdersInProgress => _context.Orders.Count(order => order.Shipped.Equals(false));

        public void CompleteOrder(int id)
        {
            var order = GetByCondition(order => order.OrderID.Equals(id), true);
            if (order is null) throw new Exception("no orders have been found with this ID");
            order.Shipped = true;
        }

        public Order? GetByTracking(int id)
        {
            return GetByCondition(order => order.trackingNumber.Equals(id), false);
        }

        public Order? GetOrder(int id)
        {
            return GetByCondition(order => order.OrderID.Equals(id), false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Items.Select(line => line.Product));
            if (order.OrderID == 0) _context.Orders.Add(order);
            _context.SaveChanges();

        }
    }
}