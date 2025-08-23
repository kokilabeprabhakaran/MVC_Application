using EducationalLibraryManagementSystem.Models;
using EducationalLibraryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("admin/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.AddBookAsync(book);
                TempData["Success"] = "Book added successfully!";
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(book);
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var books = await _bookService.GetAvailableBooksAsync();
            return View(books);
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Book updatedBook)
        {
            if (!ModelState.IsValid)
                return View(updatedBook);

            var success = await _bookService.UpdateBookAsync(id, updatedBook);
            if (!success) return NotFound();

            TempData["Success"] = "Book updated successfully!";
            return RedirectToAction("List");
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost("delete/{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _bookService.DeleteBookAsync(id);
            if (!success) return NotFound();

            TempData["Success"] = "Book deleted successfully!";
            return RedirectToAction("List");
        }
    }
}
