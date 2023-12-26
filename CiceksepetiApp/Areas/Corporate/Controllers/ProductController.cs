using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace CiceksepetiApp.Areas.Corporate
{
    [Area("Corporate")]
    [Authorize(Roles = "Corporate")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(IServiceManager manager, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        // private SelectList GetSuperCategoriesSelectList()
        // {
        //     return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryID", "CategoryName", "1");
        // }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.FindByNameAsync(HttpContext.User?.Identity?.Name);
            var companyID = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(currentUser.Id))?.FirstOrDefault()?.CompanyID;
            IEnumerable<Product> allProducts = _manager.ProductService.GetAllProducts(false).Where(prd => prd.CompanyID.Equals(companyID));

            return View(allProducts);
        }

        public IActionResult Get([FromRoute] int id)
        {
            Product? product = _manager.ProductService.GetOneProduct(id, false);
            return View(product);
        }

        public IActionResult Create()
        {
            var categories = _manager.CategoryService.GetAllCategories(false);
            ViewBag.Categories = categories;
            return View(new ProductDtoForInsertion());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file, String? UserName)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            String PATH = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot",
                                        "images", file.FileName);
            using (var stream = new FileStream(PATH, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }
            var user = await _userManager.FindByNameAsync(UserName);
            int companyID = _manager.CompanyService.GetCompanies(false).Where(comp => comp.UserID.Equals(user.Id)).FirstOrDefault().CompanyID;
            int superCategory = _manager.CategoryService.GetAllCategories(false).Where(cat => cat.CategoryID.Equals(productDto.CategoryID)).FirstOrDefault().SuperCategory;

            productDto.CompanyID = companyID;
            productDto.SuperCategory = superCategory;
            productDto.ImageURL = String.Concat("/images/", file.FileName);
            _manager.ProductService.CreateProduct(productDto);
            return RedirectToAction("Index");
        }

        public IActionResult Update([FromRoute] int id)
        {
            Product? product = _manager.ProductService.GetOneProduct(id, false);
            ProductDtoForUpdate productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return View(productDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (file is not null)
            {
                String PATH = Path.Combine(Directory.GetCurrentDirectory(),
                                            "wwwroot",
                                            "images", file.FileName);
                using (var stream = new FileStream(PATH, FileMode.Create))
                {
                    await file.CopyToAsync(stream);

                }
                productDto.ImageURL = String.Concat("/images/", file.FileName);

            }
            _manager.ProductService.UpdateProduct(productDto);
            return Redirect("/Corporate/Product/Index"); ;
        }

        public IActionResult Delete([FromRoute] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return Redirect("/Corporate/Product/Index");
        }
    }
}