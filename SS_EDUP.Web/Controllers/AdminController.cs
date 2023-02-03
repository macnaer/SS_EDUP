using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SS_EDUP.Core.Services;
using SS_EDUP.Core.Validation.User;
using SS_EDUP.Core.ViewModels.User;
using SS_EDUP.Infrastructure.ViewModels.User;

namespace SS_EDUP.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginUserVM model)
        {
            var valdator = new LoginUserValidation();
            var validationresult = await valdator.ValidateAsync(model);
            if (validationresult.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Admin");
                }
                // write code
                ViewBag.AuthError = result.Message;
                return View(model);
            }
            return View(model);
        }


        [AllowAnonymous]
        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserVM model)
        {
            //var validator = new RegisterUserValidation();
            //var validationResult = await validator.ValidateAsync(model);
            //if(validationResult.IsValid)
            //{
            //    var result = _userService.RegisterUserAsync(model);
            //    return View(result);
            //}
            //else
            //{
            //    return View(model);
            //}
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
