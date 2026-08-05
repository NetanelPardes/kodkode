using BlogPlatformApi.Models;

namespace BlogPlatformApi.Repositories
{
    public interface IBlogPlatformRepository
    {
        Task<IEnumerable<Post>> GetAll();
    }
}
