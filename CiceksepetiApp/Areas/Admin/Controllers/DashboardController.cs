using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(IServiceManager manager, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> Companies = _manager.CompanyService.GetCompanies(false) ?? Enumerable.Empty<Company>();
            IEnumerable<Company> PendingCompanies = Companies.Where(cmp => cmp.ApplicationAccepted.Equals(false)).Take(3);
            IEnumerable<IdentityUser> AllUsers = _userManager.Users;
            int productCount = _manager.ProductService.GetAllProducts(false).Count();

            ViewBag.companies = Companies.Where(cmp => cmp.ApplicationAccepted.Equals(true)).OrderByDescending(cmp => cmp.Profit).Take(3);
            ViewBag.companyCount = Companies.Count(cmp => cmp.ApplicationAccepted.Equals(true));
            ViewBag.companiesThisWeek = _manager.CompanyService.GetMostGrossingCompaniesThisWeek();
            ViewBag.pendingCompanies = PendingCompanies;
            ViewBag.users = AllUsers;
            ViewBag.userCount = AllUsers.Count();
            ViewBag.productCount = productCount;
            ViewBag.GrossSum = Companies.Sum(cmp => cmp.Profit);

            return View();
        }
    }
}