using System.ComponentModel.DataAnnotations;

namespace DutyLogApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Dutys
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the person is required.")]
        public string PersonName { get; set; } = string.Empty;

        [Required(ErrorMessage = "The name of the station is required.")]
        public string StationName { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Station number must be between 1 and 100.")]
        public int StationNum { get; set; }

        public DateTime ShiftStart { get; set; }

        public DateTime ShiftEnd { get; set; }

        [Range(0, 24, ErrorMessage = "Shift Hours must to be maximum 24 hours.")]
        public double ShiftHours
        {
            get
            {
                return (ShiftEnd - ShiftStart).TotalHours;
            }
            set;
        }
        [StringLength(500, ErrorMessage = "Remarks cannot exceed 500 characters.")]
        public string? Remarks { get; set; }
    }
}
