using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Components
{
    public class CompanyProductCountViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CompanyProductCountViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var productCount = _manager.ProductService.getCompanyProducts(id).Count();
            ViewBag.productCOUNT = productCount;
            if (productCount == 0)
            {
                ViewBag.productCOUNT = "NULL";
            }
            return View();
        }
    }
}
