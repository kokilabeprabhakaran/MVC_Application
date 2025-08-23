using EducationalLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<bool> AddBookAsync(Book book);
        Task<bool> UpdateBookAsync(int id, Book updatedBook);
        Task<bool> DeleteBookAsync(int id);
    }
}
