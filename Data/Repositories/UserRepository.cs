using EducationalLibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace EducationalLibraryManagementSystem.Data.Repositories
{ 
    public class UserRepository : IUserRepository 
    { 
        private readonly ApplicationDbContext _context; 
        public UserRepository(ApplicationDbContext context) 
        { 
            _context = context; 
        } 
        public async Task<User> GetByUsernameAsync(string username) 
        {
             return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username); 
        }
    }
}