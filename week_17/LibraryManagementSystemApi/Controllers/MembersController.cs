using LibraryManagementSystemApi.Models;
using LibraryManagementSystemApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryManagementSystemApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository _memberRepository;

    public MembersController(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Member>>> GetAll()
    {
        var members = await _memberRepository.GetAllAsync();
        return Ok(members);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Member?>> GetById(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if(member == null)
        {
            return NotFound();
        }
        return Ok(member);
    }

    [HttpPost]
    public async Task<ActionResult<Member>> create(Member member)
    {
        var created = await _memberRepository.CreateAsync(member);
        return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> update(int id, Member member)
    {
        var updated = await _memberRepository.UpdateAsync(id, member);
        if(!updated)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var deleted = await _memberRepository.DeleteAsync(id);
        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}

