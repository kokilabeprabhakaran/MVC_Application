using System;

namespace EducationalLibraryManagementSystem.Models
{
    public class BorrowedBookViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? BookTitle { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
    }
}
