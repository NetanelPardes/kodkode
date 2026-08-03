using LibraryManagementSystemApi.Models;
using LibraryManagementSystemApi.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        public async Task<bool> UpdateAsync(int id, Book book)
        {
            var exist = await _context.Books.FindAsync(id);
            if (exist == null)
            {
                return false;
            }
            exist.Title = book.Title;
            exist.Author = book.Author;
            exist.ISBN = book.ISBN;
            exist.PublishedYear = book.PublishedYear;
            exist.AvailableCopies = book.AvailableCopies;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _context.Books.FindAsync(id);
            if (exist == null)
            {
                return false;
            }
            _context.Books.Remove(exist);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
