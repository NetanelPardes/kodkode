using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Repositorys
{
    public class TelemetryRepository : ITelemetryRepository
    {
        private readonly List<TelemetryReport> _telemetryReports;
        private int _nextId;

        public TelemetryRepository()
        {
            _nextId = 4;

            _telemetryReports = new List<TelemetryReport>
            {
                new TelemetryReport
                {
                    Id = 1,
                    SatelliteId = 1,
                    BatteryPercent = 85,
                    TemperatureCelsius = 22,
                    SignalStrengthDb = -35,
                    ReportedAt = DateTime.UtcNow.AddMinutes(-30),
                    Status = "Normal"
                },
                new TelemetryReport
                {
                    Id = 2,
                    SatelliteId = 2,
                    BatteryPercent = 45,
                    TemperatureCelsius = -15,
                    SignalStrengthDb = -70,
                    ReportedAt = DateTime.UtcNow.AddMinutes(-20),
                    Status = "Warning"
                },
                new TelemetryReport
                {
                    Id = 3,
                    SatelliteId = 3,
                    BatteryPercent = 10,
                    TemperatureCelsius = 75,
                    SignalStrengthDb = -110,
                    ReportedAt = DateTime.UtcNow.AddMinutes(-10),
                    Status = "Critical"
                }
            };
        }
        public async Task<IEnumerable<TelemetryReport>> GetAllAsync()
        {
            await Task.Delay(10);
            return _telemetryReports;
        }
        public async Task<TelemetryReport?> GetByIdAsync(int id)
        {
            await Task.Delay(10);
            return _telemetryReports.FirstOrDefault(t => t.Id == id);
        }
        public async Task<IEnumerable<TelemetryReport>> GetBySatelliteIdAsync(int satelliteId)
        {
            await Task.Delay(10);
            return _telemetryReports.Where(t => t.SatelliteId == satelliteId);
        }
        public async Task<TelemetryReport> CreateAsync(TelemetryReport report)
        {
            await Task.Delay(10);

            report.Id = _nextId++;

            _telemetryReports.Add(report);

            return report;
        }
    }
}
