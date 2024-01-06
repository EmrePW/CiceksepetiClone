using CiceksepetiApp.Areas.Corporate.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Corporate
{
    [Area("Corporate")]
    [Authorize(Roles = "Corporate")]
    public class DashboardController : Controller

    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            var currentcompany = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(currentUser.Id))?.FirstOrDefault();
            if (currentcompany is null)
            {
                ViewBag.Products = Enumerable.Empty<Product>();
                ViewBag.Orders = Enumerable.Empty<Order>();
                ViewBag.lines_with_orders = new List<OrderLineModel>();
                ViewBag.ProductCount = "NULL";
                ViewBag.PendingOrders = "NULL";
                ViewBag.AverageRating = "NULL";
                ViewBag.TotalProfit = "NULL";

                return View();
            }
            IEnumerable<Product> allProducts = _manager.ProductService.getCompanyProducts(currentcompany.CompanyID);
            IEnumerable<Rating> allRatings = _manager.RatingService.GetAllRatings(false);
            IQueryable<Order> allOrders = _manager.OrderService.Orders;
            List<OrderLineModel> lines_with_orders = new List<OrderLineModel>();
            List<Rating> ratings = new List<Rating>();
            List<CartLine> orders = new List<CartLine>();

            foreach (var Order in allOrders)
            {
                var result = Order.Items.Where(line => line.Product.CompanyID.Equals(currentcompany.CompanyID));
                orders.AddRange(result);
                foreach (var line1 in result)
                {
                    if (!line1.IsCompleted.Equals(true))
                    {
                        lines_with_orders.Add(new OrderLineModel()
                        {
                            line = line1,
                            order = Order
                        });
                    }
                }
            }


            foreach (var prd in allProducts)
            {
                // var result = allRatings.Where(rating => rating.ProductID.Equals(prd.ProductID) && rating.RatingValue is not null);
                var result = _manager.RatingService.GetRatedProducts().Where(rating => rating.ProductID.Equals(prd.ProductID));
                ratings.AddRange(result);
            }
            ViewBag.Orders = orders;
            ViewBag.PendingOrders = orders.Count(line => line.IsCompleted is not true);
            ViewBag.AverageRating = ratings.Count.Equals(0) ? 0.ToString() : ratings.Average(rating => Int16.Parse(rating.RatingValue ?? "0")).ToString("#.##");
            ViewBag.Products = allProducts.OrderByDescending(prd => prd.ProductID).Take(4);
            ViewBag.ProductCount = allProducts.Count();
            ViewBag.lines_with_orders = lines_with_orders;
            ViewBag.TotalProfit = currentcompany.Profit;
            return View();
        }
    }
}