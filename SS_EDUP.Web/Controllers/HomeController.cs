using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SS_EDUP.Core.Entities;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Web.Models;
using System.Diagnostics;

namespace SS_EDUP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICoursesService coursesService;
        private readonly ICategoriesService categoriesService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICoursesService coursesService, ICategoriesService categoriesService)
        {
            _logger = logger;
            this.coursesService = coursesService;
            this.categoriesService = categoriesService;
        }

        private void LoadCategories()
        {
            //ViewData["CategoryList"] = null;
            List<Category> categories = categoriesService.GetAll();
            
            ViewBag.CategoryList = categories;
        }

        public IActionResult Index()
        {
            LoadCategories();

            return View(coursesService.GetAll());
        }

               

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}