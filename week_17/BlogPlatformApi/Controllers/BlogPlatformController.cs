using Microsoft.AspNetCore.Mvc;
using BlogPlatformApi.Repositories;

using BlogPlatformApi.Models;

namespace BlogPlatformApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogPlatformController : ControllerBase
{
    private readonly IBlogPlatformRepository _repository;
    public BlogPlatformController(IBlogPlatformRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAll()
    {
        var posts = await _repository.GetAllAsync();
        return Ok(posts);
    }


    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Post>>> Search([FromQuery]int? id, [FromQuery] DateTime? start, [FromQuery] DateTime? end)
    {
        return Ok(await _repository.GetSearchAsync(id, start, end));
    }

    [HttpGet("sotded")]
    public async Task<ActionResult<IEnumerable<Post>>> Sorted([FromQuery] string? title, [FromQuery] DateTime? PublishedDate, [FromQuery] bool descending = true)
    {
        return Ok(await _repository.GetSortedPostsAsync(title, PublishedDate, descending));
    }

    [HttpGet("titleAndComment")]
    public async Task<ActionResult<IEnumerable<object>>> TitleAndComment()
    {
        return Ok(await _repository.GetPostsWithCommentCountAsync());
    }

    [HttpGet("authorAndPosts")]
    public async Task<ActionResult<IEnumerable<object>>> AuthorAndPosts()
    {
        return Ok(await _repository.GetTotalCommentCountPerAuthorAsync());
    }

    [HttpGet("pagination")]
    public async Task<ActionResult> GetPaginatedPosts(int pageNumber = 1,int pageSize = 10)
    {
        var result = await _repository
            .GetPaginatedPostsAsync(pageNumber, pageSize);

        return Ok(result);
    }
}
