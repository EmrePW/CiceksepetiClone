using CiceksepetiApp.Areas.Corporate.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Corporate.Controllers
{
    [Area("Corporate")]
    [Authorize(Roles = "Corporate")]
    public class OrderController : Controller

    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Order> allOrders = _manager.OrderService.Orders;
            List<CartLine> orders = new List<CartLine>();
            List<OrderLineModel> lines_with_orders = new List<OrderLineModel>();
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            var companyID = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(currentUser.Id))?.FirstOrDefault()?.CompanyID;

            foreach (var Order in allOrders)
            {
                var result = Order.Items.Where(line => line.Product.CompanyID.Equals(companyID));
                orders.AddRange(result);
                foreach (var line1 in result)
                {
                    lines_with_orders.Add(new OrderLineModel()
                    {
                        line = line1,
                        order = Order
                    });
                }
            }
            return View(lines_with_orders);
        }
        public async Task<IActionResult> Update([FromQuery] String? operation, [FromRoute] int id)
        {
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            Company? currentcompany = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(currentUser.Id)).FirstOrDefault();
            var orders = _manager.OrderService.Orders;

            CartLine? line = new CartLine();
            Order? line_order = new Order();
            foreach (var order in orders)
            {
                var result = order.Items.Where(line => line.CartlineID.Equals(id)).FirstOrDefault();
                if (result is not null)
                {
                    line = result;
                    line_order = order;
                    break;
                }
            }
            if (operation.Equals("ready"))
            {
                if (line.IsReady is true) { return RedirectToAction("Index"); }
                line.IsReady = true;
                if (line_order.Items.Count(line => line.IsReady.Equals(true)).Equals(line_order.Items.Count()))
                {
                    line_order.Accepted = true;
                }
                _manager.OrderService.SaveOrder(line_order);
            }
            else if (operation.Equals("ship"))
            {
                if (line.IsShipped is true) { return RedirectToAction("Index"); }
                line.IsReady = true;
                line.IsShipped = true;
                if (line_order.Items.Count(line => line.IsShipped.Equals(true)).Equals(line_order.Items.Count()))
                {
                    line_order.Shipped = true;
                }
                _manager.OrderService.SaveOrder(line_order);
            }
            else if (operation.Equals("complete"))
            {
                if (line.IsCompleted is true) { return RedirectToAction("Index"); }
                line.IsReady = true;
                line.IsShipped = true;
                line.IsCompleted = true;
                if (line_order.Items.Count(line => line.IsCompleted.Equals(true)).Equals(line_order.Items.Count()))
                {
                    line_order.Completed = true;
                }

                currentcompany.Profit += line.Product.DiscountedPrice ?? line.Product.UnitPrice;
                currentcompany.weeklyProfit += line.Product.DiscountedPrice ?? line.Product.UnitPrice;

                _manager.OrderService.SaveOrder(line_order);
                _manager.CompanyService.SaveCompany(currentcompany);

            }
            return RedirectToAction("Index");
        }
    }
}