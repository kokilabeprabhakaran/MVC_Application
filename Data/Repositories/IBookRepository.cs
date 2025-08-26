using EducationalLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Data.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveChangesAsync();
    }
}
