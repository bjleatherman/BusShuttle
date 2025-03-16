namespace BusShuttle;

using Spectre.Console;

public class ConsoleUI
{
    FileSaver fileSaver;
    List<Loop> loops;
    List<Stop> stops;
    List<Driver> drivers;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("passenger-data.txt");

        loops = new List<Loop>();
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Green"));
        loops.Add(new Loop("Blue"));

        stops = new List<Stop>();
        stops.Add(new Stop("Bango"));
        stops.Add(new Stop("Bengo"));
        stops.Add(new Stop("Bingo"));
        stops.Add(new Stop("Bongo"));
        stops.Add(new Stop("Bungo"));
        stops.Add(new Stop("Byngo"));

        loops[0].Stops.AddRange(stops.GetRange(0, 2));
        loops[1].Stops.AddRange(stops.GetRange(2, 2));
        loops[2].Stops.AddRange(stops.GetRange(4, 2));

        drivers = new List<Driver>();
        drivers.Add(new Driver("Mark"));
        drivers.Add(new Driver("Mecky"));
        drivers.Add(new Driver("Mike"));
        drivers.Add(new Driver("Momo"));
        drivers.Add(new Driver("Mum"));
        drivers.Add(new Driver("Myanmar"));

    }

    public void Show()
    {
        string mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a mode")
            .AddChoices(new [] {
                "driver", "manager"
            })
        );

        if (mode == "driver")
        {

            Driver selectedDriver = AnsiConsole.Prompt(
                new SelectionPrompt<Driver>()
                .Title("Select a driver")
                .AddChoices(drivers)
            );
            System.Console.WriteLine("Hello, "+selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                .Title("Select Loop")
                .AddChoices(loops)
            );
            System.Console.WriteLine("you selected "+selectedLoop.Name+" loop.");

            string command;
            do 
            {
                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop")
                    .AddChoices(selectedLoop.Stops)
                );
                System.Console.WriteLine("you selected "+selectedStop.Name+" stop.");
                            
                int boarded= int.Parse(AskForInput("Enter number of passengers boarded"));
                PassengerData data = new PassengerData(
                    boarded, 
                    selectedStop, 
                    selectedLoop, 
                    selectedDriver
                );

                fileSaver.AppendData(data);

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("continue or end?")
                    .AddChoices(new [] {
                        "continue", "end"
                    })
                );

            } while(command != "end");
        }
    }
    
    public static string AskForInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine() ?? String.Empty;
    }
}