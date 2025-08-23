using EducationalLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class BookIssuesController : Controller
    {
        private readonly IBookIssueService _bookIssueService;

        public BookIssuesController(IBookIssueService bookIssueService)
        {
            _bookIssueService = bookIssueService;
        }

        [HttpGet("Issue")]
        public IActionResult Issue() => View();

        [HttpPost("Issue")]
        public async Task<IActionResult> Issue(int userId, int bookId)
        {
            var result = await _bookIssueService.IssueBookAsync(userId, bookId);
            TempData[result.Contains("successfully") ? "Success" : "Error"] = result;
            return RedirectToAction("Issue");
        }

        [HttpGet("BorrowedBooks")]
        public async Task<IActionResult> BorrowedBooks()
        {
            var borrowed = await _bookIssueService.GetBorrowedBooksAsync();
            return View(borrowed);
        }

        [HttpGet("return")]
        public async Task<IActionResult> Return()
        {
            var borrowedBooks = await _bookIssueService.GetUnreturnedBooksAsync();
            return View(borrowedBooks);
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> ReturnConfirmed(int id)
        {
            var result = await _bookIssueService.ReturnBookAsync(id);
            if (result == "Issue not found") return NotFound();

            TempData["Success"] = result;
            return RedirectToAction("BorrowedBooks");
        }
    }
}
