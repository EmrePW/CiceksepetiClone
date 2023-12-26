using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
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
            var currentUser = await _userManager.FindByNameAsync(HttpContext?.User?.Identity?.Name);
            var currentUserId = currentUser.Id;
            ICollection<Order> orders = _manager.OrderService.GetOrdersbyUser(currentUserId).ToList();

            return View(orders);
        }

        public async Task<IActionResult> Favourites()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            IEnumerable<Rating>? ratings = _manager.RatingService.GetByUser(user.Id, false);
            List<Product> fav_products = new List<Product>();
            foreach (var rating in ratings)
            {
                if (rating.IsFavourite is true)
                {
                    Product? prd = _manager.ProductService.GetOneProduct(rating.ProductID, false);
                    if (prd is null)
                    {
                        throw new Exception($"Product not found");
                    }
                    fav_products.Add(prd);
                }
            }
            return View(fav_products);
        }

        public async Task<IActionResult> Ratings()
        {
            var user = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            IEnumerable<Rating>? ratings = _manager.RatingService.GetByUser(user.Id, false).Where(rating => rating.RatingValue is not null);
            List<Product> fav_products = new List<Product>();
            foreach (var rating in ratings)
            {
                Product? prd = _manager.ProductService.GetOneProduct(rating.ProductID, false);
                if (prd is null)
                {
                    throw new Exception($"Product not found");
                }
                fav_products.Add(prd);
            }
            ViewBag.Products = fav_products;
            return View(ratings);
        }

        public IActionResult ChangePassword()
        {
            return View(new ResetPassword());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ChangePassword(ResetPassword resetPasswordDto)
        {
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _userManager.CheckPasswordAsync(currentUser, resetPasswordDto.OldPassword);
            if (!result)
            {
                return View();
            }
            await _userManager.RemovePasswordAsync(currentUser);
            var reset_result = await _userManager.AddPasswordAsync(currentUser, resetPasswordDto.NewPassword);
            if (!reset_result.Succeeded)
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}