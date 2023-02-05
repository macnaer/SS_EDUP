using FluentValidation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SS_EDUP.Core.Entities;
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
        public async Task<IActionResult> SignIn()
        {
            var user = HttpContext.User.Identity.IsAuthenticated;
            if (user)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var user = HttpContext.User.Identity.IsAuthenticated;
            if(user)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegisterUserVM model)
        {  
            var validator = new RegisterUserValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.Success)
                {
                    return RedirectToAction("SignIn", "Admin");
                }
                ViewBag.AuthError = result.Message;
                return View(model);
            }
            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _userService.ConfirmEmailAsync(userId, token);

            if (result.Success)
            {
                return RedirectToAction("ConfirmEmailPage", "Admin");
            }
            return View(result);
        }


        [AllowAnonymous]
        public IActionResult ConfirmEmailPage()
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

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var result = await _userService.LogoutUserAsync();
            if(result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Admin");
        }

    }
}
