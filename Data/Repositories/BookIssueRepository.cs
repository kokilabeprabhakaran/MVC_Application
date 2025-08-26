using EducationalLibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Data.Repositories
{
    public class BookIssueRepository : IBookIssueRepository
    {
        private readonly ApplicationDbContext _context;

        public BookIssueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetBookByIdAsync(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<BookIssue?> GetIssueByIdAsync(int id)
        {
            return await _context.BookIssues
                .Include(bi => bi.Book)
                .FirstOrDefaultAsync(bi => bi.Id == id);
        }

        public async Task<IEnumerable<BookIssue>> GetAllIssuesAsync()
        {
            return await _context.BookIssues
                .Include(bi => bi.Book)
                .Include(bi => bi.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookIssue>> GetUnreturnedIssuesAsync()
        {
            return await _context.BookIssues
                .Where(bi => bi.ReturnedAt == null)
                .Include(bi => bi.Book)
                .Include(bi => bi.User)
                .ToListAsync();
        }

        public async Task AddIssueAsync(BookIssue issue)
        {
            await _context.BookIssues.AddAsync(issue);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
