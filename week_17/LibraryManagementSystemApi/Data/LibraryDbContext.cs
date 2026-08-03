using Microsoft.EntityFrameworkCore;
using LibraryManagementSystemApi.Models;

namespace LibraryManagementSystemApi.Data
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :base(options)
        {

        }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Member> Members => Set<Member>();
    }
}
