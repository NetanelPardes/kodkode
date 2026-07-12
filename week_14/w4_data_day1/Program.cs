using System;
using System.Text.Json;

namespace w4_data_day1
{
    public class NegativPpriorityException : Exception
    {
        public NegativPpriorityException(string message) : base(message) { }
    }
    public class InvalidReportException: Exception
    {
        public InvalidReportException(string message) :base(message) { }
    }
    public class Report
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public Report(int id, string category, int priority)
        {
            Id = id;
            Category = category;
            Priority = priority;
        }
    }
    class Program
    {
        static List<string> readFromFile(string filename)
        {
            List<string> reports = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    reports.Add(line);
                }
            }
            return reports;
        }

        static List<Report> ConvertLinesToReports(ref int rejected, ref int accepted, List<string> lines)
        {
            List<Report> reports = new List<Report>();
            foreach (string line in lines)
            {
                try
                {
                    string[] my_line = line.Split(' ');
                    if(my_line.Length != 3)
                    {
                        rejected++;
                        throw new InvalidReportException("Missing data or too much");
                    }
                    int id;
                    if (!int.TryParse(my_line[0], out id))
                    {
                        rejected++;
                        throw new FormatException("Invalid id");
                        
                    }
                    int priority;
                    if (!int.TryParse(my_line[2], out priority))
                    {
                        rejected++;
                        throw new FormatException("Invalid priority");
                        
                    }
                    if (priority < 0)
                    {
                        rejected++;
                        throw new NegativPpriorityException("negative priority");
                       
                    }
                    else
                    {
                        Report report = new Report(id, my_line[1], priority);
                        reports.Add(report);
                        accepted++;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NegativPpriorityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidReportException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return reports;
        }

        static void WriteToJson(List<Report> reports)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(reports, opts);
            File.WriteAllText("reports.json", json);
        }

        static void Main()
        {
            int rejected = 0;
            int accepted = 0;
            try
            {
                List<string> stringReports = readFromFile("W4d1_field_reports_input.txt");
                List<Report> reports = ConvertLinesToReports(ref rejected, ref accepted, stringReports);
                WriteToJson(reports);

                string back = File.ReadAllText("reports.json");
                List<Report> loaded = JsonSerializer.Deserialize<List<Report>>(back) ?? new();
                foreach (var rep in loaded)
                {
                    Console.WriteLine($"id: {rep.Id} || category: {rep.Category} || priority: {rep.Priority}");
                }
                string b = File.ReadAllText("w4d1_reports_corrupted1.json");
                string a = File.ReadAllText("w4d1_reports_corrupted.json");
                List<Report> loaded1 = JsonSerializer.Deserialize<List<Report>>(a) ?? new();


            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"file {Path.GetFileName(ex.FileName)} not exist");
            }
            catch(JsonException)
            {
                Console.WriteLine("file json Corrupted");
            }
            finally
            {
                Console.WriteLine($"Number of reports rejected: {rejected}\nNumber of reports received: {accepted}");
            }
        }
    }
}