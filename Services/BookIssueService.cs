using EducationalLibraryManagementSystem.Data.Repositories;
using EducationalLibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Services
{
    public class BookIssueService : IBookIssueService
    {
        private readonly IBookIssueRepository _repository;

        public BookIssueService(IBookIssueRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> IssueBookAsync(int userId, int bookId)
        {
            var book = await _repository.GetBookByIdAsync(bookId);
            var user = await _repository.GetUserByIdAsync(userId);

            if (book == null || user == null)
                return "Invalid Book or User ID";

            if (book.Quantity <= 0)
                return "Book not available";

            var issue = new BookIssue
            {
                UserId = userId,
                BookId = bookId,
                IssuedAt = DateTime.Now
            };

            await _repository.AddIssueAsync(issue);
            book.Quantity -= 1;
            await _repository.SaveChangesAsync();

            return "Book issued successfully!";
        }

        public async Task<IEnumerable<BorrowedBookViewModel>> GetBorrowedBooksAsync()
        {
            var issues = await _repository.GetAllIssuesAsync();

            return issues.Select(bi => new BorrowedBookViewModel
            {
                Id = bi.Id,
                UserName = bi.User.UserName,
                BookTitle = bi.Book.Title,
                IssuedAt = bi.IssuedAt,
                ReturnedAt = bi.ReturnedAt
            });
        }

        public async Task<IEnumerable<BorrowedBookViewModel>> GetUnreturnedBooksAsync()
        {
            var issues = await _repository.GetUnreturnedIssuesAsync();

            return issues.Select(bi => new BorrowedBookViewModel
            {
                Id = bi.Id,
                UserName = bi.User.UserName,
                BookTitle = bi.Book.Title,
                IssuedAt = bi.IssuedAt,
                ReturnedAt = bi.ReturnedAt
            });
        }

        public async Task<string> ReturnBookAsync(int id)
        {
            var issue = await _repository.GetIssueByIdAsync(id);
            if (issue == null) return "Issue not found";

            issue.ReturnedAt = DateTime.Now;
            issue.Book!.Quantity += 1;

            await _repository.SaveChangesAsync();

            return "Book returned successfully!";
        }
    }
}
