using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }

        public IActionResult Flower(ProductRequestParameters parameters)
        {
            var model = _manager.ProductService.GetProductsWithFiltering(parameters, false);
            return View(model);
        }
        public IActionResult Bonnyfood(ProductRequestParameters parameters)
        {
            var model = _manager.ProductService.GetProductsWithFiltering(parameters, false);
            return View(model);
        }
    }
}

