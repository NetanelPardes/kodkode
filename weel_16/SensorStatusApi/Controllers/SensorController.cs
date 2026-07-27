using Microsoft.AspNetCore.Mvc;
using SensorStatusApi.Models;

namespace SensorStatusApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorController : ControllerBase
{
    private static readonly List<Sensor> _sensors = new()
    {
        new Sensor
        {
            Id = 1,
            Name = "Northern Border Site",
            Zone = "North",
            Status = "Active",
            LastContact = DateTime.UtcNow.AddMinutes(-5)
        },
        new Sensor
        {
            Id = 2,
            Name = "Coastal Site",
            Zone = "West",
            Status = "Silent",
            LastContact = DateTime.UtcNow.AddHours(-2)
        },
        new Sensor
        {
            Id = 3,
            Name = "Desert Site",
            Zone = "South",
            Status = "Maintenance",
            LastContact = DateTime.UtcNow.AddDays(-1)
        },
        new Sensor
        {
            Id = 4,
            Name = "Valley Site",
            Zone = "East",
            Status = "Active",
            LastContact = DateTime.UtcNow.AddMinutes(-12)
        },
        new Sensor
        {
            Id = 5,
            Name = "Mountain Site",
            Zone = "North",
            Status = "Maintenance",
            LastContact = DateTime.UtcNow.AddHours(-4)
        },
        new Sensor
        {
            Id = 6,
            Name = "Central Command Site",
            Zone = "Central",
            Status = "Active",
            LastContact = DateTime.UtcNow.AddMinutes(-1)
        },
        new Sensor
        {
            Id = 7,
            Name = "Southern Border Site",
            Zone = "South",
            Status = "Silent",
            LastContact = DateTime.UtcNow.AddHours(-8)
        },
        new Sensor
        {
            Id = 8,
            Name = "Eastern Ridge Site",
            Zone = "East",
            Status = "Active",
            LastContact = DateTime.UtcNow.AddMinutes(-30)
        }

    };
    [HttpGet]
    public ActionResult<IEnumerable<Sensor>> GetAllSensors()
    {
        return Ok(_sensors);
    }

    [HttpGet("{id}")]
    public ActionResult<Sensor> GetSensorById(int id)
    {
        var sensor = _sensors.FirstOrDefault(s => s.Id == id);
        if (sensor == null)
        {
            return NotFound();
        }
        return Ok(sensor);
    }

    [HttpGet("location")]
    public ActionResult<IEnumerable<Sensor>> GetSensorByZone(string zone)
    {
        var sensor = _sensors.Where(s => s.Zone == zone);
        if (sensor == null)
        {
            return NotFound();
        }
        return Ok(sensor);
    }

}
