using SatellitesTelemetryDataApi.Models;
using System.Diagnostics;

namespace SatellitesTelemetryDataApi.Services
{
    public interface ITelemetryService
    {
        Task<IEnumerable<TelemetryReport>> GetAllReportsAsync();// returns all reports.
        Task<TelemetryReport?> GetReportByIdAsync(int id);// returns one report or null.
        Task<TelemetryReport> SubmitTelemetryAsync(SubmitTelemetryRequest request);// processes a telemetry submission.
        Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId);
    }
}
