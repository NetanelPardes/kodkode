using System.ComponentModel.DataAnnotations;

namespace SatellitesTelemetryDataApi.Models
{
    public class SubmitTelemetryRequest
    {
        [Required(ErrorMessage = " ")]
        public int SatelliteId { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(0,100,ErrorMessage = " ")]
        public int BatteryPercent { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(-100, 100, ErrorMessage = " ")]
        public int TemperatureCelsius { get; set; }

        [Required(ErrorMessage = " ")]
        [Range(-100, 100, ErrorMessage = " ")]
        public int SignalStrengthDb { get; set; }
    }
}
