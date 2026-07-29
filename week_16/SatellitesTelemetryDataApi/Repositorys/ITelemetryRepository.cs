using Microsoft.AspNetCore.Http.HttpResults;
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Repositorys
{
    public interface ITelemetryRepository
    {
        Task<IEnumerable<TelemetryReport>> GetAllAsync();// returns all telemetry reports.
        Task<TelemetryReport?> GetByIdAsync(int id);// returns one report or null.
        Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId); // returns all reports for a satellite.
        Task<TelemetryReport> CreateAsync(TelemetryReport report);// creates a report.

    }
}
