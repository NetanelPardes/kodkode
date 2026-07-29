namespace SatellitesTelemetryDataApi.Exceptions
{
    public class SatelliteNotFoundException : Exception
    {
        public int SatelliteId { get; }
        public SatelliteNotFoundException(int satelliteId) : base ($"SatelliteId: {satelliteId}")
        {
            SatelliteId = satelliteId;
        }

    }
}
