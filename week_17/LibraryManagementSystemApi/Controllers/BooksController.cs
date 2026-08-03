using LibraryManagementSystemApi.Models;
using LibraryManagementSystemApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementSystemApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController :ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll()
    {
        var books = await _bookRepository.GetAllAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book?>> GetById(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> create(Book book)
    {
        var created = await _bookRepository.CreateAsync(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> update(int id, Book book)
    {
        var updated = await _bookRepository.UpdateAsync(id, book);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var deleted = await _bookRepository.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}

