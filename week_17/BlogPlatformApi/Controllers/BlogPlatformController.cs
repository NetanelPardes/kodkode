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
        var posts = await _repository.GetAll();
        return Ok(posts);
    }

}
