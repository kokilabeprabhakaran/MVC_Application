using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationalLibraryManagementSystem.Models
{
    public class BookIssue
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User? User { get; set; }

        [Required(ErrorMessage = "Book Id is required")]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public Book? Book { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime IssuedAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReturnedAt { get; set; }
    }
}
