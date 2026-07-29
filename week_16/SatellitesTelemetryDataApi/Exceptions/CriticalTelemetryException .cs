namespace SatellitesTelemetryDataApi.Exceptions
{
    public class CriticalTelemetryException : Exception
    {
        public int SatelliteId{ get;  }
        public string Reason { get;  }
        public CriticalTelemetryException(int satelliteId , string reason) : base($"SatelliteId: {satelliteId}, Reason: {reason}")
        {
            SatelliteId = satelliteId;
            Reason = reason;
        }
    }
}
