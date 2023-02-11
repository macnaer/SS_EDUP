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

        public async Task< IActionResult> Index()
        {
            /*List<CategoryDto> */
            var categories = await _categoriesService.GetAll();
            categories.Insert(0, new CategoryDto { Id = 0, Name = "All", Description = "All" });
            ViewBag.ListCategories = categories;
            return View(await _coursesService.GetAll());
        }
 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}