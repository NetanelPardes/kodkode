using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace w4_data_day2
{
    class Program
    {
        static List<Report> LoadReports(string myFile)
        {
            string json = File.ReadAllText(myFile);
            List<Report> loaded = JsonSerializer.Deserialize<List<Report>>(json) ?? new();
            return loaded;
        }
        static void Main()
        {
            try
            {
                List<Report> reports = LoadReports("W4D2_reports.json");

                //1
                var count = reports.Count();
                Console.WriteLine(count);
                Console.WriteLine();

                //2
                var signalId = reports
                    .Where(w => w.Category == "SIGNAL")
                    .Select(r => r.Id);
                foreach (var item in signalId)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //3
                var priorityHigherId = reports
                    .Where(w => w.Priority >= 4)
                    .Select(r => r.Id);
                foreach (var item in priorityHigherId)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //4
                var NightNorrthId = reports
                    .Where(w => w.Zone == "North")
                    .Where(w => w.Shift == "Night")
                    .Select(r => r.Id);
                foreach (var item in NightNorrthId)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //5
                var COMMSIdAndPriority = reports
                    .Where(w => w.Category == "COMMS")
                    .Select(r => new { r.Id, r.Priority });
                foreach (var item in COMMSIdAndPriority)
                {
                    Console.WriteLine($"{item.Id} and {item.Priority}");
                }
                Console.WriteLine();

                //6
                var SignalStrengthBetween = reports
                    .Where(r => r.SignalStrength > 70 && r.SignalStrength < 90)
                    .Select(s => s.Id);
                foreach (var item in SignalStrengthBetween)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //7
                var NotWest = reports
                    .Where(w => w.Zone != "West")
                    .Select(r => r.Id);
                foreach (var item in NotWest)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //8
                var OrderByPriority = reports
                    .OrderByDescending(o => o.Priority)
                    .Select(r => r.Id);
                foreach (var item in OrderByPriority)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //9
                var OrderByZone = reports
                    .OrderBy(o => o.Zone)
                    .ThenByDescending(t => t.Priority)
                    .Select(r => r.Id);
                foreach (var item in OrderByZone)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //10
                var Strongest_3_Id = reports
                    .OrderByDescending(o => o.SignalStrength)
                    .Take(3)
                    .Select(r => r.Id);
                foreach (var item in Strongest_3_Id)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //11
                var Weakest_2_Id = reports
                    .OrderBy(o => o.SignalStrength)
                    .Take(2)
                    .Select(r => r.Id);
                foreach (var item in Weakest_2_Id)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //12
                var Skip_2_Id = reports
                    .OrderByDescending(o => o.Priority)
                    .Skip(5)
                    .Select(r => r.Id);
                foreach (var item in Skip_2_Id)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //13
                var IMAGERYWeakest = reports
                    .Where(r => r.Category ==  "IMAGERY")
                    .OrderBy(o => o.SignalStrength)
                    .Select(r => r.Id);
                foreach (var item in IMAGERYWeakest)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //14
                var countPriority = reports
                    .Count(r => r.Priority == 5);
                Console.WriteLine(countPriority);
                Console.WriteLine();

                //15
                var averageSignal = reports
                    .Average(r => r.SignalStrength);
                Console.WriteLine(averageSignal);
                Console.WriteLine();

                //16
                var StongestSignal = reports
                    .Max(r => r.SignalStrength);
                Console.WriteLine(StongestSignal);
                Console.WriteLine();

                //17
                var weakestSignalNight = reports
                    .Where(r => r.Shift == "Night")
                    .Min(r => r.SignalStrength);
                Console.WriteLine(weakestSignalNight);
                Console.WriteLine();

                //18
                var sum_signal = reports
                    .Where(r => r.Category == "SIGNAL")
                    .Sum(r => r.Priority);
                Console.WriteLine(sum_signal);
                Console.WriteLine();

                //19
                var averageSouth = reports
                    .Where(r => r.Zone == "South")
                    .Average(r => r.Priority);
                Console.WriteLine(averageSouth);
                Console.WriteLine();

                //20
                var distinctZones = reports
                    .Select(r => r.Zone)
                    .Distinct()
                    .Count();
                Console.WriteLine(distinctZones);
                Console.WriteLine();

                //21
                var distinctCategories = reports
                    .OrderBy(r => r.Category)
                    .Select(r => r.Category)
                    .Distinct();
                foreach (var item in distinctCategories)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //22
                var countCategory = reports
                    .GroupBy(r => r.Category)
                    .Select(r => r.Count());
                foreach (var item in countCategory)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //23
                var SignalAverageZone = reports
                    .GroupBy(r => r.Zone)
                    .Select(a => a.Average(s => s.SignalStrength));
                foreach (var item in SignalAverageZone)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //24
                var averagePriorityCategory = reports
                    .GroupBy(g => g.Category)
                    .Select(a => a.Average(p => p.Priority));
                foreach (var item in averagePriorityCategory)
                {
                    Console.WriteLine(item.ToString("F2"));
                }
                Console.WriteLine();

                //25
                var SignalMaximumZone = reports
                    .GroupBy(r => r.Zone)
                    .Select(a => a.Max(s => s.SignalStrength));
                foreach (var item in SignalMaximumZone)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                //26
                var countNightCategory = reports
                    .Where(s => s.Shift == "Night")
                    .GroupBy(s => s.Category)
                    .Select(n => new { count = n.Count(), key = n.Key });
                foreach (var item in countNightCategory)
                {
                    Console.WriteLine(item.key + " are " + item.count);
                }
                Console.WriteLine();

                //27
                var zonesBusiestFirst = reports
                    .GroupBy(g => g.Zone)
                    .Select(b => new {zone = b.Key, count = b.Count()})
                    .OrderByDescending(o => o.count);
                foreach (var item in zonesBusiestFirst)
                {
                    Console.WriteLine(item.zone + " are " + item.count);
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file not exist");
            }



        }
    }
}
