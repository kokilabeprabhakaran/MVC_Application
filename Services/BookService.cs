using EducationalLibraryManagementSystem.Data.Repositories;
using EducationalLibraryManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalLibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return await _bookRepository.GetAvailableBooksAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookAsync(int id, Book updatedBook)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;
            book.Quantity = updatedBook.Quantity;

            await _bookRepository.UpdateAsync(book);
            await _bookRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return false;

            await Task.Run(() => _bookRepository.DeleteAsync(book));
            await _bookRepository.SaveChangesAsync();
            return true;
        }
    }
}
