using EducationalLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]")]
    [Authorize(Roles = "User")]
    public class ListBooksController : Controller
    {
        private readonly IBookService _bookService;

        public ListBooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("listUserBooks")]
        public async Task<IActionResult> List()
        {
            var books = await _bookService.GetAvailableBooksAsync();
            return View(books);
        }
    }
}