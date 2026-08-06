using BlogPlatformApi.Models;
using BlogPlatformApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformApi.Repositories
{
    public class BlogPlatformRepository : IBlogPlatformRepository
    {
        private readonly BlogPlatformDbContext _context;
        public BlogPlatformRepository(BlogPlatformDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Comments)
                .ToListAsync();
        }
        public async Task<IEnumerable<Post>> GetSearchAsync(int? authorId, DateTime? timeStart, DateTime? timeEnd)
        {
            var posts = _context.Posts.Include(p => p.Author).AsQueryable();

            posts = posts.Where(p => p.IsPublished == true);

            if (authorId.HasValue)
            {
                posts = posts.Where(p => p.AuthorId == authorId.Value);
            }
            if (timeStart.HasValue)
            {
                posts = posts.Where(p => p.PublishedDate > timeStart.Value);
            }
            if (timeEnd.HasValue)
            {
                posts = posts.Where(p => p.PublishedDate < timeEnd.Value);
            }
            return await posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetSortedPostsAsync(string? title, DateTime? PublishedDate, bool descending = true)
        {
            var posts = _context.Posts.Include(p => p.Author).AsQueryable();
            if (!string.IsNullOrWhiteSpace(title))
            {
                if(descending)
                {
                    posts = posts.OrderByDescending(p => p.Title);
                }
                else
                {
                    posts = posts.OrderBy(p => p.Title);
                }
            }
            if(PublishedDate.HasValue)
            {
                if (descending)
                {
                    posts = posts.OrderByDescending(p => p.PublishedDate);
                }
                else
                {
                    posts = posts.OrderBy(p => p.PublishedDate);
                }
            }
            return await posts.ToListAsync();
            
        }
        public async Task<IEnumerable<object>> GetPostsWithCommentCountAsync() 
        {
            var posts = _context.Posts.Include(p => p.Author).AsQueryable();
            return await posts.Select(p => new
            {
                Title = p.Title,
                count = p.Comments.Count()
            }).ToListAsync();
        }
        public async Task<IEnumerable<object>> GetTotalCommentCountPerAuthorAsync()
        {
            return await _context.Posts
                .GroupBy(p => new
                {
                    p.AuthorId,
                    p.Author.FullName
                })
                .Select(group => new
                {
                    AuthorId = group.Key.AuthorId,
                    AuthorName = group.Key.FullName,
                    TotalCommentCount = group
                        .SelectMany(p => p.Comments)
                        .Count()
                })
                .ToListAsync();
        }
        public async Task<object> GetPaginatedPostsAsync(int pageNumber,int pageSize)
        {
            var query = _context.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.PublishedDate)
                .ThenBy(p => p.Id);

            var totalCount = await query.CountAsync();

            var posts = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Posts = posts
            };
        }
    }
}
