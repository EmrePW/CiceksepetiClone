using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CiceksepetiApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IServiceManager _manager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IServiceManager manager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _manager = manager;
        }

        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.userName);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.userPassword, false, false)).Succeeded)
                    {
                        return Redirect("/");
                    }
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home");
        }

        public IActionResult Register()
        {
            return View(new RegisterDto());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register([FromForm] RegisterDto newUser)
        {
            var user = new IdentityUser()
            {
                UserName = newUser.username,
                Email = newUser.Email
            };

            var createResult = await _userManager.CreateAsync(user, newUser.Password);

            if (createResult.Succeeded)
            {
                var assignRoleResult = await _userManager.AddToRoleAsync(user, "User");
                if (assignRoleResult.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var ErrorMessage in createResult.Errors)
                    {
                        ModelState.AddModelError("", ErrorMessage.Description);
                    }
                }

            }

            return View();
        }

        public IActionResult CorporateRegister()
        {
            return View(new CompanyDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CorporateRegister([FromForm] CompanyDto company)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = company.username,
                    Email = company.Email,
                    PhoneNumber = company.PhoneNumber,
                };

                var createResult = await _userManager.CreateAsync(user, company.Password);

                if (createResult.Succeeded)
                {
                    var assignRoleResult = await _userManager.AddToRoleAsync(user, "User");
                    var assignRoleResult2 = await _userManager.AddToRoleAsync(user, "Corporate");
                    company.UserID = user.Id;
                    if (assignRoleResult.Succeeded && assignRoleResult2.Succeeded)
                    {
                        _manager.CompanyService.CreateCompany(company);
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    foreach (var ErrorMessage in createResult.Errors)
                    {
                        ModelState.AddModelError("", ErrorMessage.Description);
                    }
                }

            }

            return View();
        }
    }
}