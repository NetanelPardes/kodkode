using BlogPlatformApi.Models;

namespace BlogPlatformApi.Repositories
{
    public interface IBlogPlatformRepository
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<IEnumerable<Post>> GetSearchAsync(int? authorId, DateTime? timeStart, DateTime? timeEnd);
        Task<IEnumerable<Post>> GetSortedPostsAsync(string? title, DateTime? PublishedDate, bool descending);
        Task<IEnumerable<object>> GetPostsWithCommentCountAsync();
        Task<IEnumerable<object>> GetTotalCommentCountPerAuthorAsync();
        Task<object> GetPaginatedPostsAsync(int pageNumber, int pageSize);
    }
}
