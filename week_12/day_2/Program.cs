using System;
using System.Security.Cryptography;
namespace day2
{
    abstract class Platform
    {
        private int _trackId;
        public int TrackId
        {
            get => _trackId;

        }
        private double _speedKnots;
        public double SpeedKnots
        {
            get => _speedKnots;
            set
            {
                if (value < 0)
                {
                    _speedKnots = 0;
                }
                else
                {
                    _speedKnots = value;
                }
            }
        }
        private double _heading;
        public double Heading
        {
            get => _heading;
            set
            {
                if (value < 0 || value > 359)
                {
                    _heading = 0;
                }
                else
                {
                    _heading = value;
                }
            }
        }
        protected Platform(int TrackId, double SpeedKnots, double Heading)
        {
            _trackId = TrackId;
            _speedKnots = SpeedKnots;
            _heading = Heading;
        }
        public abstract string StatusLine();
        public abstract bool IsTrackable();
        public override string ToString()
        {
            return $"TrackId: {TrackId}, SpeedKnots {SpeedKnots}, Heading {Heading}";
        }
    }
    class AirPlatform : Platform
    {
        private double _altitudeFeet;
        public double AltitudeFeet
        {
            get => _altitudeFeet;
            set
            {
                if (value < 0)
                {
                    _altitudeFeet = 0;
                }
                else
                {
                    _altitudeFeet = value;
                }
            }
        }
        public AirPlatform(int TrackId, double SpeedKnots, double Heading, double AltitudeFeet) : base(TrackId, SpeedKnots, Heading)
        {
            _altitudeFeet = AltitudeFeet;
        }
        public override string StatusLine() => $"Air platform: {TrackId}, speed {SpeedKnots} knots, heading {Heading}, altitude {AltitudeFeet} feet";
        public override bool IsTrackable()
        {
            if ((AltitudeFeet >= 100 && AltitudeFeet <= 60000) && SpeedKnots > 0)
            {
                return true;
            }
            return false;
        }
    }
    class SeaPlatform : Platform
    {
        private double _depthMeters;
        public double DepthMeters
        {
            get => _depthMeters;
            set
            {
                if (value < 0)
                {
                    _depthMeters = 0;
                }
                else
                {
                    _depthMeters = value;
                }
            }
        }
        public SeaPlatform(int TrackId, double SpeedKnots, double Heading, double DepthMeters) : base(TrackId, SpeedKnots, Heading)
        {
            _depthMeters = DepthMeters;
        }
        public override string StatusLine() => $"Sea platform: {TrackId}, speed {SpeedKnots} knots, heading {Heading}, depth {DepthMeters} meters";
        public override bool IsTrackable()
        {
            if (DepthMeters >= 0 && DepthMeters <= 300)
            {
                return true;
            }
            return false;
        }
    }
    class GroundPlatform : Platform
    {
        private string _terrainType;
        public string TerrainType
        {
            get => _terrainType;
            set
            {
                _terrainType = value;
            }
        }
        public GroundPlatform(int TrackId, double SpeedKnots, double Heading, string TerrainType) : base(TrackId, SpeedKnots, Heading)
        {
            _terrainType = TerrainType;
        }
        public override string StatusLine() => $"Ground platform: {TrackId}, speed {SpeedKnots} knots, heading {Heading}, terrain {TerrainType}";
        public override bool IsTrackable()
        {
            if (TerrainType != "tunnel")
            {
                return true;
            }
            return false;
        }
    }
    class program
    {
        static void Main()
        {
            List <Platform> PlatformList = new List<Platform>();
            AirPlatform a1 = new AirPlatform(1, 5, 60, 70);
            AirPlatform a2 = new AirPlatform(2, 99, -32, 101);
            SeaPlatform s1 = new SeaPlatform(3, 66, 97, 12);
            SeaPlatform s2 = new SeaPlatform(4, 77, 96, -12);
            GroundPlatform g1 = new GroundPlatform(5, 645, 37, "blabla");
            GroundPlatform g2 = new GroundPlatform(6, 5, -35, "tunnel");
            PlatformList.Add(a1);
            PlatformList.Add(a2);
            PlatformList.Add(s1);
            PlatformList.Add(s2);
            PlatformList.Add(g1);
            PlatformList.Add(g2);

            foreach(Platform item in PlatformList)
            {
                Console.WriteLine(item.StatusLine());
                Console.WriteLine(item.IsTrackable());

            }
        }
    }
}

