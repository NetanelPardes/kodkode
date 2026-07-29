using System.ComponentModel.DataAnnotations;

namespace SatellitesTelemetryDataApi.Models
{
    public class TelemetryReport
    {
        public int Id { get; set; }

        [Required(ErrorMessage = " ")]
        public int SatelliteId { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(0, 100, ErrorMessage = " ")]
        public int BatteryPercent { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(-100, 100, ErrorMessage = " ")]
        public int TemperatureCelsius { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(-120, 0, ErrorMessage = " ")]
        public int SignalStrengthDb { get; set; }

        public DateTime ReportedAt { get; set; }

        public string Status { get; set; } = "Normal";
    }
}
