using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using VehiclesFleetApi.Models;

namespace VehiclesFleetApi.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles;
        private int nextId;
        public VehicleRepository()
        {
            nextId = 9;
            _vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1,
                    RegistrationNumber = "IL-12-ABC-45",
                    VehicleType = "Car",
                    Status = "Available",
                    AssignedDriver = "No Driver Assigned",
                    CurrentLocation = "Main Parking Lot",
                    Mileage = 45200
                },
                new Vehicle
                {
                    Id = 2,
                    RegistrationNumber = "TR-78-KLM-21",
                    VehicleType = "Truck",
                    Status = "In-Use",
                    AssignedDriver = "David Cohen",
                    CurrentLocation = "Tel Aviv",
                    Mileage = 128500
                },
                new Vehicle
                {
                    Id = 3,
                    RegistrationNumber = "MC-34-ZXP-89",
                    VehicleType = "Motorcycle",
                    Status = "Maintenance",
                    AssignedDriver = "Garage Technician",
                    CurrentLocation = "Central Garage",
                    Mileage = 32100
                },
                new Vehicle
                {
                    Id = 4,
                    RegistrationNumber = "VN-56-QRS-90",
                    VehicleType = "Van",
                    Status = "Available",
                    AssignedDriver = "No Driver Assigned",
                    CurrentLocation = "Jerusalem Depot",
                    Mileage = 87300
                },
                new Vehicle
                {
                    Id = 5,
                    RegistrationNumber = "BS-91-DEF-33",
                    VehicleType = "Bus",
                    Status = "In-Use",
                    AssignedDriver = "Moshe Levi",
                    CurrentLocation = "Haifa",
                    Mileage = 245000
                },
                new Vehicle
                {
                    Id = 6,
                    RegistrationNumber = "SV-63-TUV-17",
                    VehicleType = "SUV",
                    Status = "Decommissioned",
                    AssignedDriver = "Fleet Manager",
                    CurrentLocation = "Old Vehicle Yard",
                    Mileage = 499000
                },
                new Vehicle
                {
                    Id = 7,
                    RegistrationNumber = "AM-22-HJK-74",
                    VehicleType = "Ambulance",
                    Status = "Maintenance",
                    AssignedDriver = "Daniel Israel",
                    CurrentLocation = "Service Center",
                    Mileage = 176400
                },
                new Vehicle
                {
                    Id = 8,
                    RegistrationNumber = "PK-85-NBC-42",
                    VehicleType = "Pickup Truck",
                    Status = "Available",
                    AssignedDriver = "No Driver Assigned",
                    CurrentLocation = "Beer Sheva Depot",
                    Mileage = 63400
                }
            };
        }
        public IEnumerable<Vehicle> GetAll()
        {
            return _vehicles;
        }
        public Vehicle? GetById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.Id == id);
        }
        public Vehicle? GetByRegistrationNumber(string regNumber)
        {
            return _vehicles.FirstOrDefault(v => v.RegistrationNumber == regNumber);
        }
        public IEnumerable<Vehicle> GetByStatus(string status)
        {
            return _vehicles.Where(v => v.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Vehicle> GetByType(string type)
        {
            return _vehicles.Where(v => v.VehicleType.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
        public Vehicle Create(Vehicle vehicle)
        {
            vehicle.Id = nextId++;
            _vehicles.Add(vehicle);
            return vehicle;
        }
        public Vehicle? Update(int id, Vehicle vehicle)
        {
            var existing = _vehicles.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return null;
            }

            existing.RegistrationNumber = vehicle.RegistrationNumber;
            existing.VehicleType = vehicle.VehicleType;
            existing.Status = vehicle.Status;
            existing.AssignedDriver = vehicle.AssignedDriver;
            existing.CurrentLocation = vehicle.CurrentLocation;
            existing.Mileage = vehicle.Mileage;

            return vehicle;
        }
        public bool Delete(int id)
        {
            var existing = _vehicles.FirstOrDefault(v => v.Id == id);
            if (existing == null)
            {
                return false;
            }

            _vehicles.Remove(existing);
            return true;
        }
    }
}
