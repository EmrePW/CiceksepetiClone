using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Corporate.Controllers
{
    [Area("Corporate")]
    [Authorize(Roles = "Corporate")]
    public class RatingController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public RatingController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            var currentcompany = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(currentUser.Id)).FirstOrDefault();
            if (currentcompany is null)
            {
                var ratings1 = new List<Rating>();
                return View(ratings1);
            }

            var ratings = _manager.RatingService.GetRatedProducts();
            var products = _manager.ProductService.getCompanyProducts(currentcompany.CompanyID);
            if (products is null)
            {
                products = new List<Product>().AsQueryable<Product>();
            }

            var companyRatings = new List<Rating>();
            foreach (var prd in products)
            {
                // var result = allRatings.Where(rating => rating.ProductID.Equals(prd.ProductID) && rating.RatingValue is not null);
                var result = ratings.Where(rating => rating.ProductID.Equals(prd.ProductID));
                companyRatings.AddRange(result);
            }

            return View(companyRatings);
        }
    }
}