using DutyLogApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DutyLogApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DutysController : ControllerBase
{
    private static readonly List<Dutys> _dutys = new()
    {
        new Dutys
        {
            Id = 1,
            PersonName = "David Cohen",
            StationName = "North Station",
            StationNum = 10,
            ShiftStart = new DateTime(2026, 7, 27, 8, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 27, 16, 0, 0),
            Remarks = "The shift was completed without unusual events."
        },

        new Dutys
        {
            Id = 2,
            PersonName = "Daniel Levi",
            StationName = "South Station",
            StationNum = 20,
            ShiftStart = new DateTime(2026, 7, 27, 14, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 27, 22, 30, 0),
            Remarks = "Checked all station equipment."
        },

        new Dutys
        {
            Id = 3,
            PersonName = "Avi Gross",
            StationName = "East Station",
            StationNum = 30,
            ShiftStart = new DateTime(2026, 7, 28, 6, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 28, 12, 0, 0),
            Remarks = "Morning shift."
        },

        new Dutys
        {
            Id = 4,
            PersonName = "Yoni Levi",
            StationName = "West Station",
            StationNum = 40,
            ShiftStart = new DateTime(2026, 7, 28, 20, 0, 0),
            ShiftEnd = new DateTime(2026, 7, 29, 4, 0, 0),
            Remarks = "Night shift."
        },

        new Dutys
        {
            Id = 5,
            PersonName = "Moshe Israel",
            StationName = "Central Station",
            StationNum = 50,
            ShiftStart = new DateTime(2026, 7, 29, 9, 15, 0),
            ShiftEnd = new DateTime(2026, 7, 29, 17, 45, 0),
            Remarks = null
        }
    };

    private static int _nextId = 6;
    
    [HttpGet]
    public ActionResult<IEnumerable<Dutys>> GetAllDutys()
    {
        return Ok(_dutys);
    }
    [HttpGet("{id}")]
    public ActionResult<Dutys> GetDutyById(int id)
    {
        var Duty = _dutys.FirstOrDefault(d => d.Id == id);
        if (Duty == null)
        {
            return NotFound();
        }
        return Ok(Duty);
    }
    [HttpPost]
    public ActionResult<Dutys> NewDuty(Dutys newDuty)
    {
        newDuty.Id = _nextId++;
        _dutys.Add(newDuty);
        return CreatedAtAction(nameof(GetDutyById), new { id = newDuty.Id }, newDuty);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDuty(int id, Dutys duty)
    {
        var existDuty = _dutys.FirstOrDefault(d => d.Id == id);
        if(existDuty == null)
        {
            return NotFound();
        }
        existDuty.PersonName = duty.PersonName;
        existDuty.StationNum = duty.StationNum;
        existDuty.StationName = duty.StationName;
        existDuty.ShiftStart = duty.ShiftStart;
        existDuty.ShiftEnd = duty.ShiftEnd;
        existDuty.ShiftHours = duty.ShiftHours;
        existDuty.Remarks = duty.Remarks;
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteDuty(int id)
    {
        var existDuty = _dutys.FirstOrDefault(d => d.Id == id);
        if (existDuty == null)
        {
            return NotFound();
        }
        _dutys.Remove(existDuty);
        return NoContent();
    }
}
