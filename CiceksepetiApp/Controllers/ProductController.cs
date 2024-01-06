using CiceksepetiApp.Models;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace CiceksepetiApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            IEnumerable<Rating> ratings = _manager.RatingService.GetByProduct(id, false) ?? Enumerable.Empty<Rating>();

            foreach (var rating in ratings)
            {
                var user = await _userManager.FindByIdAsync(rating.UserID);
                rating.UserID = user.UserName;
            }

            var fav_count = ratings.Count(rating => rating.IsFavourite.Equals(true));
            var rating_count = ratings.Count(rating => rating.RatingValue is not null);

            // Check to see if the user has already liked the item
            bool? isFavouriteItem = false;
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var current_user = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
                foreach (var rating in ratings)
                {
                    if (rating.UserID.Equals(current_user.UserName) && rating.IsFavourite is true) isFavouriteItem = true;
                }
            }

            ViewBag.Ratings = ratings;
            ViewBag.rating_count = rating_count;
            ViewBag.AverageRating = !ratings.Count(rating => rating.RatingValue is not null).Equals(0) ? ratings.Where(rating => rating.RatingValue is not null).Average(rating => Int64.Parse(rating.RatingValue)) : 0;
            ViewBag.favouiteCount = fav_count;
            ViewBag.FavouriteItem = isFavouriteItem;

            return View(product);
        }
    }
}
