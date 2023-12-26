using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace CiceksepetiApp.Pages
{
    public class CartModel : PageModel
    {
        public readonly IServiceManager _manager;
        public Cart cart { get; set; }
        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            cart = cartService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost([FromForm] CartLineDetailsParameters parameters)
        {

            if (parameters.deliverDateCalendar is null && parameters.deliverDate is null)
            {
                ModelState.AddModelError("", "Lütfen bir tarih seçiniz!");
                return Redirect($"/Product/Get/{parameters.ProductID}");
            }
            if (parameters.deliverDateCalendar is not null)
            {
                parameters.deliverDate = parameters.deliverDateCalendar;
            }
            Product? product = _manager.ProductService.GetOneProduct(parameters.ProductID, false);
            if (product is not null) cart.AddItem(product, parameters.deliverDate, parameters.deliverTime, parameters.deliverCity);
            return Page();
        }

        public IActionResult OnPostRemove(int id)
        {
            cart.RemoveLine(cart.CartLines.First(line => line.Product.ProductID.Equals(id)).Product);
            return RedirectToPage("/cart");
        }

    }
}