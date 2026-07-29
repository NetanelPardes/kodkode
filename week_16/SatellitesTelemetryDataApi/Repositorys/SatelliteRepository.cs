using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Repositorys
{
    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly List<Satellite> _satellites;
        private int _nextId;

        public SatelliteRepository()
        {
            _nextId = 4;

            _satellites = new List<Satellite>
            {
                new Satellite
                {
                    Id = 1,
                    Name = "Horizon Observer",
                    OrbitAltitudeKm = 550,
                    Status = "Active"
                },
                new Satellite
                {
                    Id = 2,
                    Name = "Sky Guardian",
                    OrbitAltitudeKm = 1200,
                    Status = "Standby"
                },
                new Satellite
                {
                    Id = 3,
                    Name = "Legacy Explorer",
                    OrbitAltitudeKm = 35786,
                    Status = "Decommissioned"
                }
            };
        }
        public async Task<IEnumerable<Satellite>> GetAllAsync()
        {
            await Task.Delay(10);
            return _satellites;

        }
        public async Task<Satellite?> GetByIdAsync(int id)
        {
            await Task.Delay(10);
            return _satellites.FirstOrDefault(s => s.Id == id);
        }
        public async Task<Satellite> CreateAsync(Satellite satellite)
        {
            await Task.Delay(10);

            satellite.Id = _nextId++;
            _satellites.Add(satellite);

            return satellite;
        }
        public async Task<Satellite?> UpdateAsync(int id, Satellite satellite)
        {
            await Task.Delay(10);

            var exist = _satellites.FirstOrDefault(s => s.Id == id);
            if(exist == null)
            {
                return null;
            }
            exist.Name = satellite.Name;
            exist.OrbitAltitudeKm = satellite.OrbitAltitudeKm;
            exist.Status = satellite.Status;

            return exist;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await Task.Delay(10);
            var exist = _satellites.FirstOrDefault(s => s.Id == id);
            if (exist == null)
            {
                return false;
            }
            _satellites.Remove(exist);

            return true;

        }
    }
}
