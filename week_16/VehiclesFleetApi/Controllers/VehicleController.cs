using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using VehiclesFleetApi.Models;
using VehiclesFleetApi.Repositories;

namespace VehiclesFleetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _repository;

    public VehicleController(IVehicleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vehicle>> GetAll()
    {
        var vehicles = _repository.GetAll();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public ActionResult<Vehicle> GetById(int id)
    {
        var vehicle = _repository.GetById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }
    [HttpGet("RegistrationNumber")]
    public ActionResult<Vehicle> GetByRegistrationNumber(string registrationNumber)
    {
        var vehicle = _repository.GetByRegistrationNumber(registrationNumber);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    [HttpGet("Status")]
    public ActionResult<IEnumerable<Vehicle>> GetByStatus(string status)
    {
        var vehicle = _repository.GetByStatus(status);
        return Ok(vehicle);
    }

    [HttpGet("Type")]
    public ActionResult<IEnumerable<Vehicle>> GetByType(string type)
    {
        var vehicle = _repository.GetByType(type);
        return Ok(vehicle);
    }

    [HttpPost]
    public ActionResult<Vehicle> Create(Vehicle vehicle)
    {
        var newVehicle = _repository.Create(vehicle);
        return CreatedAtAction(nameof(GetById), new { id = vehicle.Id }, vehicle);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Vehicle vehicle)
    {
        var updated = _repository.Update(id, vehicle);
        if(updated == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _repository.Delete(id);
        if(!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
