
using EducationalLibraryManagementSystem.Models;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Services
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
        string GenerateJwtToken(string username, string role);
    }
}
