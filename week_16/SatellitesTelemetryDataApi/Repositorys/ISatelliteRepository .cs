using Microsoft.AspNetCore.Http.HttpResults;
using SatellitesTelemetryDataApi.Models;

namespace SatellitesTelemetryDataApi.Repositorys
{
    public interface ISatelliteRepository
    {
        Task<IEnumerable<Satellite>> GetAllAsync(); // returns all satellites.
        Task<Satellite?> GetByIdAsync(int id);// returns one satellite or null.
        Task<Satellite> CreateAsync(Satellite satellite);// creates a satellite.
        Task<Satellite?> UpdateAsync(int id, Satellite satellite);// updates a satellite.
        Task<bool> DeleteAsync(int id);// deletes a satellite.
    }
}
