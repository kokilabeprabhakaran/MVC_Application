using System.ComponentModel.DataAnnotations;

namespace EducationalLibraryManagementSystem.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "User name is required")]
        public required string UserName { get; set; }

        [Required (ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        [Required (ErrorMessage = "Role is required")]
        public required string Role { get; set; }
    }
}
