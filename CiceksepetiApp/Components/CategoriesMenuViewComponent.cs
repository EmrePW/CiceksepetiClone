using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(int superCategory)
        {
            var categories = _manager.CategoryService.GetAllSubCategories(superCategory, false);
            return View(categories);
        }
    }
}