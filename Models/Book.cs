using System.ComponentModel.DataAnnotations;

namespace EducationalLibraryManagementSystem.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required (ErrorMessage = "Title is required")]
        public required string Title { get; set; }

        [Required (ErrorMessage = "Author is required")]
        public required string Author { get; set; }

        [Required (ErrorMessage = "Category is required")]
        public required string Category { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
