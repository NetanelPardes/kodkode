using SatellitesTelemetryDataApi.Exceptions;
using SatellitesTelemetryDataApi.Models;
using SatellitesTelemetryDataApi.Repositorys;

namespace SatellitesTelemetryDataApi.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly ISatelliteRepository _satelliteRepository;
        private readonly ITelemetryRepository _telemetryRepository;
        
        public TelemetryService(ISatelliteRepository satelliteRepository, ITelemetryRepository telemetryRepository)
        {
            _satelliteRepository = satelliteRepository;
            _telemetryRepository = telemetryRepository;
        }
        public async Task<IEnumerable<TelemetryReport>> GetAllReportsAsync()
        {
            return await _telemetryRepository.GetAllAsync();
        }
        public async Task<TelemetryReport?> GetReportByIdAsync(int id)
        {
            return await _telemetryRepository.GetByIdAsync(id);
        }
        public async Task<TelemetryReport> SubmitTelemetryAsync(SubmitTelemetryRequest request)
        {
            var report = await _satelliteRepository.GetByIdAsync(request.SatelliteId);
            if(report == null)
            {
                throw new SatelliteNotFoundException(request.SatelliteId);
            }
            if(request.BatteryPercent < 20)
            {
                throw new CriticalTelemetryException(request.SatelliteId, "Battery critically low");
            }
            if(request.TemperatureCelsius < -50 || request.TemperatureCelsius >60)
            {
                throw new CriticalTelemetryException(request.SatelliteId, "Temperature out of safe range");
            }
            if(request.SignalStrengthDb < -100)
            {
                throw new CriticalTelemetryException(request.SatelliteId, "Signal strength critically weak");
            }
            var telemetryReport = new TelemetryReport
            {
                SatelliteId = request.SatelliteId,
                BatteryPercent = request.BatteryPercent,
                TemperatureCelsius = request.TemperatureCelsius,
                SignalStrengthDb = request.SignalStrengthDb,
                ReportedAt = DateTime.UtcNow,
                Status = "Normal"
            };

            var createdReport = await _telemetryRepository.CreateAsync(telemetryReport);

            return createdReport;


        }
        public async Task<IEnumerable< TelemetryReport>> GetBySatelliteIdAsync(int satelliteId)
        {
            return await _telemetryRepository.GetBySatelliteIdAsync(satelliteId);
        }
    }
}
    
