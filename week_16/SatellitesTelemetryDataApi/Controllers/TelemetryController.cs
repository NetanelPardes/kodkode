using Microsoft.AspNetCore.Mvc;
using SatellitesTelemetryDataApi.Models;
using SatellitesTelemetryDataApi.Repositorys;
using SatellitesTelemetryDataApi.Services;

namespace SatellitesTelemetryDataApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TelemetryController : ControllerBase
{
    private readonly ITelemetryService _telemetryService;

    public TelemetryController(ITelemetryService telemetryService)
    {
        _telemetryService = telemetryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TelemetryRepository>>> GetAll()
    {
        var telemetryRepositorys = await _telemetryService.GetAllReportsAsync();
        return Ok(telemetryRepositorys);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TelemetryRepository>> GetById(int id)
    {
        var telemetryRepository = await _telemetryService.GetReportByIdAsync(id);
        if(telemetryRepository == null)
        {
            return NotFound();
        }
        return Ok(telemetryRepository);
    }

    [HttpGet("satellite/{satelliteId}")]
    public async Task<ActionResult<IEnumerable<TelemetryRepository>>> GetBySatelliteId(int satelliteId)
    {
        var telemetryRepositorys = await _telemetryService.GetBySatelliteIdAsync(satelliteId);
        return Ok(telemetryRepositorys);
    }

    [HttpPost]
    public async Task<ActionResult<TelemetryRepository>> CreateTelemetryRepository(SubmitTelemetryRequest request)
    {
        var telemetryRepository = await _telemetryService.SubmitTelemetryAsync(request);
        return CreatedAtAction(nameof(GetBySatelliteId), new { id = request.SatelliteId }, request);
    }
}
