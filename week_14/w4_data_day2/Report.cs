using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w4_data_day2
{
    public class Report
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public string Zone { get; set; }
        public int SignalStrength { get; set; }
        public string Shift { get; set; }

        public Report (int id, string category, int priority, string zone , int signalStrength , string shift)
        {
            Id = id;
            Category = category;
            Priority = priority; 
            Zone = zone;
            SignalStrength = signalStrength;
            Shift = shift;
        }
    }
}
