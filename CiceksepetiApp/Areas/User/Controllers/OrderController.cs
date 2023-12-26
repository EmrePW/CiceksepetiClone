using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]

    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;

        public OrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Get([FromRoute] int id)
        {
            Order? order = _manager.OrderService.GetOneOrder(id);
            foreach (var line in order.Items)
            {
                line.Company = _manager.CompanyService.GetOneCompany(line.Product.CompanyID, false);
            }
            return View(order);
        }

        public IActionResult Update([FromRoute] int id)
        {
            return View();
        }
    }
}