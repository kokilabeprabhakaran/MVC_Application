using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationalLibraryManagementSystem.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    [Route("user/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}