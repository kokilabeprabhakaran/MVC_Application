
using EducationalLibraryManagementSystem.Models;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
