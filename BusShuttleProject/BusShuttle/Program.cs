namespace BusShuttle;

using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please select mode (driver or manager)");
        string mode = Console.ReadLine();

        if (mode == "driver")
        {

            string command;

            do 
            {
                System.Console.WriteLine("Enter stop name");
                string stopName = Console.ReadLine();

                System.Console.WriteLine("Enter number of passengers boarded");
                int boarded= int.Parse(Console.ReadLine());

                File.AppendAllText("passenger-data.txt", stopName+":"+boarded+Environment.NewLine);

                System.Console.WriteLine("Enter command: (end or continue)");
                command = Console.ReadLine();

            } while(command != "end");
        }
    }
}
