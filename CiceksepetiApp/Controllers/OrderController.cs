using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly IServiceManager _manager;

        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(Cart cart, IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _cart = cart;
            _manager = manager;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(new Order());
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index([FromForm] Order order)
        {
            var current_user = await _userManager.FindByNameAsync(HttpContext?.User?.Identity?.Name);
            order.Customer = current_user;
            order.Customer.Id = current_user.Id;

            if (order.InvoiceAddress is null)
            {
                order.InvoiceAddress = order.City + " " + order.Line1;
            }
            if ((Int16.Parse(order.CardExpirationMonth) < DateTime.Now.Month) && (Int32.Parse(order.CardExpirationYear) == DateTime.Now.Year))
            {
                ModelState.AddModelError("", "Please enter a valid date.");
            }

            if (ModelState.IsValid)
            {
                order.Items = _cart.CartLines.ToArray();
                foreach (var item in order.Items)
                {
                    _manager.ProductService.DecrementStock(item.Product.ProductID);
                }
                _manager.OrderService.SaveOrder(order);

                _cart.ClearCart();
                return RedirectToPage("/OrderComplete",
                new
                {
                    track = order.trackingNumber
                });
            }

            return View();
        }


        public IActionResult Track()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TrackResult([FromForm] int trackingNumber)
        {
            var order = _manager.OrderService.GetOrderByTracking(trackingNumber);
            if (order is null)
            {
                throw new Exception("Order not found.");
            }
            var sum = order.Items.Sum(line => line.Product.DiscountedPrice ?? line.Product.UnitPrice);
            return View(order);
        }
    }
}