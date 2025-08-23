using EducationalLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Services
{
    public interface IBookIssueService
    {
        Task<string> IssueBookAsync(int userId, int bookId);
        Task<IEnumerable<BorrowedBookViewModel>> GetBorrowedBooksAsync();
        Task<IEnumerable<BorrowedBookViewModel>> GetUnreturnedBooksAsync();
        Task<string> ReturnBookAsync(int id);
    }
}
