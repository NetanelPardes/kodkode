using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VehiclesFleetApi.Models;

namespace VehiclesFleetApi.Repositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();
        Vehicle? GetById(int id);//returns one vehicle or null.
        Vehicle? GetByRegistrationNumber(string regNumber);// returns one vehicle or null.
        IEnumerable<Vehicle> GetByStatus(string status);//  returns vehicles with matching status.
        IEnumerable<Vehicle> GetByType(string type);//  returns vehicles with matching type.
        Vehicle Create(Vehicle vehicle);// adds a new vehicle, assigns an ID, returns the created vehicle.
        Vehicle? Update(int id, Vehicle vehicle);// updates an existing vehicle, returns the updated vehicle or null if not found.
        bool Delete(int id);// removes a vehicle, returns true if successful, false if not found.

    }
}
