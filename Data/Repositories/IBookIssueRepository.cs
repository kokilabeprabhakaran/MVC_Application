using EducationalLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Data.Repositories
{
    public interface IBookIssueRepository
    {
        Task<Book?> GetBookByIdAsync(int bookId);
        Task<User?> GetUserByIdAsync(int userId);

        Task<BookIssue?> GetIssueByIdAsync(int id);
        Task<IEnumerable<BookIssue>> GetAllIssuesAsync();
        Task<IEnumerable<BookIssue>> GetUnreturnedIssuesAsync();

        Task AddIssueAsync(BookIssue issue);
        Task SaveChangesAsync();
    }
}
