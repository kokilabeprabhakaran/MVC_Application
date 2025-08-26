using EducationalLibraryManagementSystem.Models;
using EducationalLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EducationalLibraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("~/")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userService.ValidateUserAsync(model.UserName, model.Password);

            if (user != null)
            {
                var token = _userService.GenerateJwtToken(user.UserName, user.Role);

                Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true
                });

                return user.Role == "Admin"
                    ? RedirectToAction("Index", "Home", new { area = "Admin" })
                    : RedirectToAction("Index", "Home", new { area = "User" });
            }

            ViewBag.Error = "Invalid username or password";
            return View(model);
        }

        [HttpGet]
        [Route("Account/Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return Redirect("~/");
        }
    }
}
