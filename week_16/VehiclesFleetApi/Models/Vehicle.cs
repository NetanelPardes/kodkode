using System.ComponentModel.DataAnnotations;

namespace VehiclesFleetApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Registration Number must be")]
        [StringLength(15,MinimumLength = 5, ErrorMessage = "teh number must be between 5 to 15")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vehicle type must be")]
        [StringLength(50,ErrorMessage = "Vehicle type maximum 50")]
        public string VehicleType { get; set; } = string.Empty;

        [Required(ErrorMessage = "status is requared")]
        [RegularExpression("^Available|In-Use|Maintenance|Decommissioned$")]
        public string Status { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Assigned Driver maximum 100")]
        public string AssignedDriver { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Current Location maximum 200")]
        public string CurrentLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mileage is requared")]
        [Range(0, 500000, ErrorMessage = "Mileage have to be beween 0 to 500000")]
        public int Mileage { get; set; }

    }
}
