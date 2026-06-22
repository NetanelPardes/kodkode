class Track
{
    static List<int> tracks = new List<int>();
    static List<double> speeds = new List<double>();
    static List<int> headings = new List<int>();
    static void AddTrack(int id, double speed,int hesding)
    {
        tracks.Add(id);
        speeds.Add(speed);
        headings.Add(hesding);
    }
    static void RemoveTrack(int id)
    {
        for(int i =0; i <tracks.Count;i++)
        {
            if (tracks[i] == id)
            {
                tracks.Remove(tracks[i]);
                speeds.Remove(speeds[i]);
                headings.Remove(headings[i]);
            }
        }
    }
    static void find_by_id(int id)
    {
        for (int i = 0; i < tracks.Count; i++)
        {
            if (tracks[i] == id)
            {
                to_string(i);
            }
        }
    }
    static void return_all_trancks()
    {
        for (int i = 0; i < tracks.Count; i++)
        {
            to_string(i);
        }
    }
    static void to_string(int index)
    {
        Console.WriteLine($"Track {tracks[index]} with spped {speeds[index]} For direction {headings[index]}");
    }
    static void Main()
    {
        AddTrack(7, 17.8, 13);
        AddTrack(32, 98.3, 43);
        AddTrack(45, 150.4, 57);
        to_string(1);
        RemoveTrack(45);
        find_by_id(32);
        return_all_trancks();

    }
}
