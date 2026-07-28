using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using SmartLockerApi.Models;
using SmartLockerApi.Repositories;

namespace SmartLockerApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LockerController : ControllerBase
{
    private readonly ILockerRepository _repository;

    public LockerController(ILockerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Locker>> GetAll()
    {
        var lockers = _repository.GetAll();
        return Ok(lockers);
    }
    [HttpGet("{id}")]
    public ActionResult<Locker> GetById(int id)
    {
        var locker = _repository.GetById(id);
        if (locker == null)
        {
            return NotFound();
        }
        return Ok(locker);
    }

    [HttpGet("number/{lockerNumber}")]
    public ActionResult<Locker> GetByLockerNumber(int lockerNumber)
    {
        var locker = _repository.GetByLockerNumber(lockerNumber);
        if(locker == null)
        {
            return NotFound();
        }
        return Ok(locker);
    }

    [HttpGet("status/{status}")]
    public ActionResult<IEnumerable<Locker>> GetByStatus(string status)
    {
        var lockers = _repository.GetByStatus(status);
        return Ok(lockers);
    }

    [HttpPost]
    public ActionResult<IEnumerable<Locker>> NewLocker(Locker locker)
    {
        var created = _repository.Create(locker);
        return CreatedAtAction(nameof(_repository.GetById), new { id = locker.Id }, locker);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id , Locker locker)
    {
        var updated = _repository.Update(id, locker);
        if (updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Dalete(int id)
    {
        var deleted = _repository.Delete(id);
        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
