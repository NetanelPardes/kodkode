using System;
namespace start;

class Program
{
    static void Main()
    {
        Console.WriteLine("please enter a id");
        string id = Console.ReadLine();
        int newId;
        while (!int.TryParse(id, out newId))
        {
            Console.WriteLine("it's not a number, please enter a id number");
            id = Console.ReadLine();
        }

        Console.WriteLine("please enter the speed");
        string speed = Console.ReadLine();
        double newSpeed;
        while (!double.TryParse(speed, out newSpeed))
        {
            Console.WriteLine("it's not a number, please enter a speed number");
            speed = Console.ReadLine();
        }
        string speedStatus;
        if (newSpeed < 100.0)
        {
            speedStatus = "slow";
        }
        else if (newSpeed < 300.0)
        {
            speedStatus = "medium";
        }
        else
        {
            speedStatus = "fast";
        }

        //Console.WriteLine(speedStatus);

        Console.WriteLine("please enter the heading");
        string heading = Console.ReadLine();
        double newHeading;
        while (!double.TryParse(heading, out newHeading))
        {
            Console.WriteLine("it's not a number, please enter a heading number");
            heading = Console.ReadLine();
        }
        if (newHeading < 0 || newHeading > 359)
        {
            Console.WriteLine($"warning heading invalid");
        }

        Console.WriteLine("please enter the status");
        string status = Console.ReadLine();

        int resulta = (int)newHeading / 30;
        double resultb = newHeading / 30;

        int resultc = (int)newSpeed / 60;
        double resultd = newSpeed / 60;
        //Console.WriteLine(resultA);
        //Console.WriteLine(resultb);
        Console.WriteLine($"===Track Report===\nTrack ID: {newId}\nSpeed: {newSpeed}\nHeading: {newHeading} degrees\nStatus: {status}\n" +
            $"Division Demo 1: {newHeading}/30 = {resulta} (int) | {resultb} (double)\nDivision Demo 2: {newSpeed}/60 = {resultc} (int) | {resultd} (double)");
    }
}