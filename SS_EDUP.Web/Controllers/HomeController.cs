using Microsoft.AspNetCore.Mvc;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Web.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using SS_EDUP.Core.Services;

namespace SS_EDUP.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriesService _categoriesService;
        private readonly ICoursesService _coursesService;
        public HomeController(ILogger<HomeController> logger, 
                             ICategoriesService categoriesService,
                             ICoursesService coursesService)
        {
            _logger = logger;
            _categoriesService = categoriesService;
            _coursesService = coursesService;
        }

        private void LoadCategories()// ??
        {
            ViewBag.CategoriesList = new SelectList(
                _categoriesService.GetAll(),
                nameof(CategoryDto.Id),
                nameof(CategoryDto.Name)
                );

        }
        public IActionResult Index()
        {
            LoadCategories();
            List<CategoryDto> categories = _categoriesService.GetAll();
            categories.Insert(0, new CategoryDto { Id = 0, Name = "All", Description = "All" });
            ViewData["ListCategories"] = categories;
            ViewBag.ListCategories = categories;
            return View(_coursesService.GetAll());
        }
        //public ActionResult Index(int? category_id, int? page)
        //{
        //    int PageSize = 10;
        //    List<CategoryDTO> categories = _categoriesService.GetAll();
        //    categories.Insert(0, new Category { Id = 0, Name = "All", Description = "All" });
        //    ViewData["listCategory"] = categories;
        //    ViewBag.listCategory = categories;


        //    //var products = _context.Products.Include(product => product.Category).ToList();
        //    var products = _context.Products.Include(p => p.Category).Select(
        //        p => new ProductCardViewModel()
        //        {
        //            Product = p,
        //        }
        //        ).ToList();

        //    int pageIndex = 1;
        //    pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

        //    foreach (var item in products)
        //    {
        //        item.IsInCart = IsProductInCart(item.Product.Id);
        //    }

        //    if (category_id != null && category_id > 0)
        //    {
        //        products = products.Where(p => p.Product.CategoryId == category_id).ToList();
        //    }

        //    IPagedList<Product> productsToReturn = null;
        //    productsToReturn = (IPagedList<Product>)products.OrderBy
        //                  (c => c.Product.Category.Name).ToPagedList(pageIndex, PageSize);


        //    return View(productsToReturn);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}