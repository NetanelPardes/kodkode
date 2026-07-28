namespace SensorStatusApi.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Zone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime LastContact { get; set; }
    }
}
