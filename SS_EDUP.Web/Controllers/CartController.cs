using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Web.Helpers;

namespace SS_EDUP.Web.Controllers
{
    public class CartController:Controller
    {
        private readonly ICoursesService coursesService;

        public CartController(ICoursesService coursesService)
        {
            this.coursesService = coursesService;
        }

        public async Task<IActionResult> Index()
        {
            var courseIds = HttpContext.Session.Get<List<int>>("cart-list");

            List<CourseDto> courses = new();
            if (courseIds != null)
                courses = await coursesService.Get(courseIds.ToArray());

            return View(courses);
        }

        public IActionResult Add(int courseId)
        {
            //if (coursesService.Get(courseId) == null) return NotFound();
            var courseIds = HttpContext.Session.Get<List<int>>("cart-list");
            courseIds ??= new List<int>();

           
             courseIds.Add(courseId);
             HttpContext.Session.Set("cart-list", courseIds);
          
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int courseId)
        {
            var courseIds = HttpContext.Session.Get<List<int>>("cart-list");
            //if (courseIds.Find(courseId) == null) return NotFound();
            courseIds.Remove(courseId);
            HttpContext.Session.Set("cart-list", courseIds);
            return RedirectToAction("Index", "Home");
        }
    }
}
