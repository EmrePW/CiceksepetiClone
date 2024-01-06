using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CompanyController(IServiceManager manager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Company> companies = _manager.CompanyService.GetCompanies(false).Where(cmp => cmp.ApplicationAccepted.Equals(true));
            return View(companies);
        }

        public IActionResult Applications()
        {
            IEnumerable<Company> companies = _manager.CompanyService.GetCompanies(false).Where(cmp => cmp.ApplicationAccepted.Equals(false));
            return View(companies);
        }

        public async Task<IActionResult> Accept([FromRoute] int id)
        {
            var company = _manager.CompanyService.GetOneCompany(id, false);
            if (company is null)
            {
                throw new Exception("Şirket bulunamadı!");
            }
            var user = await _userManager.FindByIdAsync(company.UserID);
            if (user is null)
            {
                throw new Exception("Kullanıcı Bulunamadı!");
            }
            var assignRoleResult = await _userManager.AddToRoleAsync(user, "Corporate");
            if (!assignRoleResult.Succeeded)
            {
                throw new Exception("Failed to assign Corporate role.");
            }
            _manager.CompanyService.AcceptApplication(company);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reject([FromRoute] int id)
        {
            var company = _manager.CompanyService.GetOneCompany(id, false);
            if (company is null)
            {
                throw new Exception("Şirket bulunamadı!");
            }
            _manager.CompanyService.RejectApplication(company);

            var user = await _userManager.FindByIdAsync(company.UserID);
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user!");
            }
            return RedirectToAction("Index");
        }
    }
}