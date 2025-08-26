using System.ComponentModel.DataAnnotations;

namespace EducationalLibraryManagementSystem.Models
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "UserName is required")]
        public required string UserName { get; set; }
        [Required (ErrorMessage = "Password is required"), DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}