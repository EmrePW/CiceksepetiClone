using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}