using BlogPlatformApi.Models;
using BlogPlatformApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformApi.Repositories
{
    public class BlogPlatformRepository: IBlogPlatformRepository
    {
        private readonly BlogPlatformDbContext _context;
        public BlogPlatformRepository(BlogPlatformDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .ToListAsync();
        }
    }
}
