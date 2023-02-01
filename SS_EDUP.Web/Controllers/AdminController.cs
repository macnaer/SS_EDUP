using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SS_EDUP.Web.Controllers
{
    
    public class AdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Profile() { 
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
