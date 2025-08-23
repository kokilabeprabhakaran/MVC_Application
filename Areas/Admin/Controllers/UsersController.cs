using EducationalLibraryManagementSystem.Data;
using EducationalLibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace EducationalLibraryManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("admin/[controller]")] 
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(EducationalLibraryManagementSystem.Models.User user)
        {
            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<EducationalLibraryManagementSystem.Models.User>();
                user.Password = hasher.HashPassword(user, user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["Success"] = "User added successfully!";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(user);
        }

    }
}
