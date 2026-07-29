using System.ComponentModel.DataAnnotations;

namespace SatellitesTelemetryDataApi.Models
{
    public class Satellite
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " ")]
        [StringLength(100, ErrorMessage = " ")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = " ")]
        [Range(200, 40000, ErrorMessage = " ")]
        public int OrbitAltitudeKm { get; set; } 

        [Required(ErrorMessage =" ")]
        [RegularExpression("^Active|Standby|Decommissioned$")]
        public string Status { get; set; } = string.Empty;
    }
}
