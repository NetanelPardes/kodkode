using System;
using System.Diagnostics;
using System.Xml.Serialization;
namespace day3;
enum Status { Friendly, Hostile, Unidentified }
class IntellIgence
{
   
    static void Main()
    {
        
        List<int> id = new List<int>();
        List<Status> status = new List<Status>();
        List<double?> signal = new List<double?>();
        string choice = "-1";
       
        while(choice != "4")
        {
            Console.WriteLine("=== Signal Intercept Log ===");
            Console.WriteLine("1. Add new transmission");
            Console.WriteLine("2. Calibrate existing signal");
            Console.WriteLine("3. List all transmissions");
            Console.WriteLine("4. Quit");
            Console.Write("Choose option: ");

            choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    addMessage(id, status, signal);
                    break;
                case "2":
                    update(id, status, signal);
                    break;
                case "3":
                    printAll(id, status, signal);
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("There is no such option, try again.");
                    break;
            }
        }
       
    }
    static void addMessage( List<int> id , List<Status> status , List<double?> signal)
    {
        Console.WriteLine("enter the new id");
        string myID = Console.ReadLine();
        int newId;
        if (!int.TryParse(myID, out newId))
        {
            Console.WriteLine("this is not a number");
            return;
        }
        if(id.Contains(newId))
        {
            Console.WriteLine("this id exixts");
            return;
        }
        Console.WriteLine("enter the new status (Friendly, Hostile, Unidentified)");
        string myStatus = Console.ReadLine();
        Status newStatus;
        if (!Status.TryParse(myStatus, out newStatus))
        {
            Console.WriteLine("this is not a status");
            return;
        }
        Console.WriteLine("enter the new signal");
        string mySignal = Console.ReadLine();
        double? newSignal;

        newSignal = null;
        if (!string.IsNullOrWhiteSpace(mySignal))
        {
            if (!double.TryParse(mySignal, out double newSignal2))
            {
                Console.WriteLine("this is not a number");
                return;
            }
            newSignal = newSignal2;
        }
        id.Add(newId);
        status.Add(newStatus);
        signal.Add(newSignal);
    }
    static void update(List<int> id, List<Status> status, List<double?> signal)
    {
        Console.WriteLine("enter the new id");
        string myID = Console.ReadLine();
        int newId;
        if (!int.TryParse(myID, out newId))
        {
            Console.WriteLine("this is not a number");
            return;
        }
        if (!id.Contains(newId))
        {
            Console.WriteLine("this id not exixts");
            return;
        }
        int index = findIndex(id, newId);

        Console.WriteLine("enter the new signal");
        string mySignal = Console.ReadLine();
        double? newSignal;

        newSignal = null;
        if (!string.IsNullOrWhiteSpace(mySignal))
        {
            if (!double.TryParse(mySignal, out double newSignal2))
            {
                Console.WriteLine("this is not a number");
                return;
            }
            newSignal = newSignal2;
        }
        signal[index] = newSignal;
        
    }
    static int findIndex(List<int> id , int my_id)
    {
        for (int i = 0; i < id.Count; i++)
        {
            if (id[i] == my_id)
            {
                return i;
            }
        }
        return -1;
    }
    static void printAll(List<int> id, List<Status> status, List<double?> signal)
    {
        for(int i = 0; i < id.Count; i++)
        {
            Console.WriteLine($"Under radio number {id[i]} with status {status[i]} transmitting at frequency strength {signal[i]}");
        }
    }
}