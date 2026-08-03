using LibraryManagementSystemApi.Models;

namespace LibraryManagementSystemApi.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task<bool> UpdateAsync(int id, Book book);
        Task<bool> DeleteAsync(int id);

    }
}
