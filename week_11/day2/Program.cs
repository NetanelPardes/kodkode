using System.Diagnostics;
using System.Runtime.InteropServices;

class Track
{

    static void AddTrack(int id, double speed, int hesding, List<int> tracks, List<double> speeds, List<int> headings)
    {
        if (tracks.Contains(id))
        {
            Console.WriteLine("This track already exists.\n");
        }
        else
        {
            tracks.Add(id);
            speeds.Add(speed);
            headings.Add(hesding);
            Console.WriteLine("track create successfully\n");
        }

    }
    static void RemoveTrack(int id, List<int> tracks, List<double> speeds, List<int> headings)
    {
        if (!tracks.Contains(id))
        {
            Console.WriteLine("This track not exists.\n");
        }
        else
        {
            for (int i = 0; i < tracks.Count; i++)
            {
                if (tracks[i] == id)
                {
                    tracks.Remove(tracks[i]);
                    speeds.Remove(speeds[i]);
                    headings.Remove(headings[i]);
                }
            }
            Console.WriteLine("track deleted successfully\n");
        }

    }
    static void find_by_id(int id, List<int> tracks, List<double> speeds, List<int> headings)
    {
        if (!tracks.Contains(id))
        {
            Console.WriteLine("This track not exists.\n");
        }
        else
        {
            for (int i = 0; i < tracks.Count; i++)
            {
                if (tracks[i] == id)
                {
                    to_string(i, tracks, speeds, headings);
                }
            }
        }

    }
    static void return_all_trancks(List<int> tracks, List<double> speeds, List<int> headings)
    {
        for (int i = 0; i < tracks.Count; i++)
        {
            to_string(i, tracks, speeds, headings);
        }
    }
    static void to_string(int index, List<int> tracks, List<double> speeds, List<int> headings)
    {
        Console.WriteLine($"Track {tracks[index]} with spped {speeds[index]} For direction {headings[index]}");
    }

    static List<int> byFilter(double speed, List<int> tracks, List<double> speeds)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < tracks.Count; i++)
        {
            if (speeds[i] < speed)
            {
                result.Add(tracks[i]);
            }
        }
        return result;
    }

    static List<int> byFilter(int heading, int heading2, List<int> tracks, List<int> headings)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < tracks.Count; i++)
        {
            if (headings[i] > heading && headings[i] < heading2)
            {
                result.Add(tracks[i]);
            }
        }
        return result;
    }
    static void summarize(List<int> tracks, List<double> speeds)
    {
        double sum = 0;
        double maxfast = speeds[0];
        for (int i = 0; i < tracks.Count; i++)
        {
            sum += speeds[i];
            if (speeds[i] > maxfast)
            {
                maxfast = speeds[i];
            }
        }
        Console.WriteLine($"the count off tracks is {tracks.Count} \nThe average of speed is {sum / speeds.Count}\nthe fastest track is {maxfast}");
    }
    static void Main()
    {
        List<int> tracks = new List<int>();
        List<double> speeds = new List<double>();
        List<int> headings = new List<int>();
        AddTrack(7, 17.8, 13, tracks, speeds, headings);
        AddTrack(85, 98.3, 359, tracks, speeds, headings);
        AddTrack(32, 107.8, 200, tracks, speeds, headings);
        AddTrack(96, 200.2, 233, tracks, speeds, headings);
        AddTrack(132, 168.2, 240, tracks, speeds, headings);
        AddTrack(152, 235.9, 67, tracks, speeds, headings);
        AddTrack(160, 95.6, 53, tracks, speeds, headings);
        AddTrack(333, 75.6, 13, tracks, speeds, headings);
        AddTrack(45, 150.4, 57, tracks, speeds, headings);
        string choice = "-1";
        while (choice != "0")
        {
            Console.WriteLine("\n===== Track Manager Menu =====");
            Console.WriteLine("1. Add track");
            Console.WriteLine("2. Remove track by ID");
            Console.WriteLine("3. Find track by ID");
            Console.WriteLine("4. List all tracks");
            Console.WriteLine("5. Filter tracks by speed threshold");
            Console.WriteLine("6. Filter tracks by heading sector");
            Console.WriteLine("7. Summarize fleet");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");
            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("enter the id:");
                    string input = Console.ReadLine();
                    int myId;
                    if (!int.TryParse(input, out myId))
                    {
                        Console.WriteLine("This is not a number, start from the beginning!!!");
                        break;
                    }

                    Console.WriteLine("enter the speed:");
                    input = Console.ReadLine();
                    double mySpeed;
                    if (!double.TryParse(input, out mySpeed))
                    {
                        Console.WriteLine("This is not a number, start from the beginning!!!");
                        break;
                    }

                    Console.WriteLine("enter the heading:");
                    input = Console.ReadLine();
                    int myHeading;
                    if (!int.TryParse(input, out myHeading))
                    {
                        Console.WriteLine("This is not a number, start from the beginning!!!");
                        break;
                    }

                    AddTrack(myId, mySpeed, myHeading, tracks, speeds, headings);

                    break;

                case "2":
                    Console.WriteLine("Which ID do you want to delete?");
                    string inputId = Console.ReadLine();
                    int deleteId;
                    if (!int.TryParse(inputId, out deleteId))
                    {
                        Console.WriteLine("This is not a number, start from the beginning!!!");
                        break;
                    }
                    RemoveTrack(deleteId, tracks, speeds, headings);
                    break;

                case "3":
                    Console.WriteLine("enter the id:");
                    string input3 = Console.ReadLine();
                    int myId3;
                    if(!int.TryParse(input3, out myId3))
                    {
                        Console.WriteLine("This is not a number, start from the beginning!!!");
                        break;
                    }
                    find_by_id(myId3, tracks, speeds, headings);
                    break;

                case "4":
                    return_all_trancks(tracks, speeds, headings);
                    break;

                case "5":
                    List<int> filterBySpeed = byFilter(100.0, tracks, speeds);
                    foreach (int i in filterBySpeed)
                    {
                        Console.WriteLine($"id - {i}");
                    }
                    break;

                case "6":
                    List<int> filterByHeading = byFilter(100, 300, tracks, headings);
                    foreach (int i in filterByHeading)
                    {
                        Console.WriteLine($"id - {i}");
                    }
                    break;

                case "7":
                    summarize(tracks, speeds);
                    break;




            }
        }
    }
}
