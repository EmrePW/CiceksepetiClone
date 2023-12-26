using Microsoft.AspNetCore.Mvc;

namespace CiceksepetiApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}