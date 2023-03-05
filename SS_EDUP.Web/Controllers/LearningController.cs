using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS_EDUP.Core.DTO_s;
using SS_EDUP.Core.Interfaces;
using SS_EDUP.Core.Services;
using SS_EDUP.Web.Helpers;

namespace SS_EDUP.Web.Controllers
{
    [Authorize(Roles = "Students")]
    public class LearningController : Controller
    {
        private readonly ILearningService _learningService;
        private readonly UserService _userService;
        private readonly ICategoriesService _categoriesService;
        private readonly ICoursesService _coursesService;
        public LearningController(ILearningService learningService, ICoursesService coursesService, UserService userService, ICategoriesService categoriesService)
        {
            this._learningService = learningService;
            _userService = userService;
            _categoriesService = categoriesService;
            _coursesService = coursesService;
        }

        // GET: LearningController
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var learning =await _learningService.GetByStudentId(userId);
                      
            return View(learning);
        }

        // GET: LearningController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Learning/Add
        public async Task<IActionResult> Add()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            List<int> ids = HttpContext.Session.Get<List<int>>("cart-list");
            if (ids == null) return BadRequest();
            var studentLearningIds =(await _learningService.GetByStudentId(userId)).Select(x=>x.CourseID);
            int[] confirmIds = ids.Where(x => !studentLearningIds.Contains(x)).ToArray();
       
            _learningService.Add(userId, confirmIds);
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        // POST: LearningController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LearningController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LearningController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
