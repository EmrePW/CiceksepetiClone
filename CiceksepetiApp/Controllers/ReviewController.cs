using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Services.Contracts;

namespace CiceksepetiApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] RatingDtoForInsertion ratingDto)
        {
            var user = await _userManager.FindByNameAsync(ratingDto.username);
            ratingDto.UserID = user.Id;
            var rating = _manager.RatingService.GetOneRating(ratingDto.UserID, ratingDto.ProductID, false);
            if (rating is null)
            {
                _manager.RatingService.CreateRating(ratingDto);
                _manager.ProductService.GetOneProduct(ratingDto.ProductID, false).RatingCount++;
            }
            else
            {
                RatingDtoForUpdate updateDto = new RatingDtoForUpdate()
                {
                    RatingID = rating.RatingID,
                    ProductID = ratingDto.ProductID,
                    UserID = ratingDto.UserID,
                    Opinion = ratingDto.Opinion,
                    RatingValue = ratingDto.RatingValue,
                    IsFavourite = rating.IsFavourite

                };
                _manager.RatingService.UpdateRating(updateDto);
            }

            return Redirect($"/Product/Get/{ratingDto.ProductID}");
        }

        public async Task<IActionResult> FavouriteItem(int productId)
        {
            if (productId.Equals(0)) throw new Exception("Product ID is zero!");
            var product_id = productId;
            var user = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            var rating = _manager.RatingService.GetOneRating(user.Id, product_id, false);
            if (rating is null)
            {
                var ratingDto = new RatingDtoForInsertion()
                {
                    ProductID = productId,
                    UserID = user.Id,
                    IsFavourite = true
                };

                _manager.RatingService.CreateRating(ratingDto);
            }
            else
            {
                if (rating.IsFavourite is false || rating.IsFavourite is null)
                {

                    var ratingDto = new RatingDtoForUpdate()
                    {
                        RatingID = rating.RatingID,
                        UserID = rating.UserID,
                        ProductID = rating.ProductID,
                        IsFavourite = true,
                        RatingValue = rating.RatingValue,
                        Opinion = rating.Opinion
                    };
                    _manager.RatingService.UpdateRating(ratingDto);
                }
                else
                {
                    var ratingDto = new RatingDtoForUpdate()
                    {
                        RatingID = rating.RatingID,
                        UserID = rating.UserID,
                        ProductID = rating.ProductID,
                        IsFavourite = false,
                        RatingValue = rating.RatingValue,
                        Opinion = rating.Opinion
                    };
                    _manager.RatingService.UpdateRating(ratingDto);
                }
            }
            return Redirect($"/Product/get/{product_id}");
        }
    }
}