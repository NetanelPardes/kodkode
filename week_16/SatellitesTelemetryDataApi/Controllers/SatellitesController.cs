using Microsoft.AspNetCore.Mvc;
using SatellitesTelemetryDataApi.Models;
using SatellitesTelemetryDataApi.Repositorys;

namespace SatellitesTelemetryDataApi.Controllers;

[ApiController]
[Route("[controller]")]

public class SatellitesController : ControllerBase
{
    private readonly ISatelliteRepository _satelliteRepository;

    public SatellitesController(ISatelliteRepository satelliteRepository)
    {
        _satelliteRepository = satelliteRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Satellite>>> GetAll()
    {
        var satellites = await _satelliteRepository.GetAllAsync();
        return Ok(satellites);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Satellite>> GetById(int id)
    {
        var satellite = await _satelliteRepository.GetByIdAsync(id);
        if(satellite == null)
        {
            return NotFound();
        }
        return Ok(satellite);
    }
    [HttpPost]
    public async Task<ActionResult<Satellite>> CreateSatellite(Satellite satellite)
    {
        var newSatellite = await _satelliteRepository.CreateAsync(satellite);
        return CreatedAtAction(nameof(GetById), new { id = satellite.Id }, satellite);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Satellite>> UpdateSatellite(int id, Satellite satellite)
    {
        var newSatellite = await _satelliteRepository.UpdateAsync(id, satellite);
        if (newSatellite == null)
        {
            return NotFound();
        }
        return Ok(newSatellite);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSatellite(int id)
    {
        var deletedSatellite = await _satelliteRepository.DeleteAsync(id);
        if (!deletedSatellite)
        {
            return NotFound();
        }
        return NoContent();
    }
}

