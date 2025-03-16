namespace BusShuttle;

using Spectre.Console;
using Spectre.Console.Cli;

public class ConsoleUI
{
    DataManager dataManager;

    public ConsoleUI()
    {
        dataManager = new DataManager();
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
                .AddChoices(dataManager.Drivers)
            );
            Console.WriteLine("Hello, "+selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                .Title("Select Loop")
                .AddChoices(dataManager.Loops)
            );
            Console.WriteLine("you selected "+selectedLoop.Name+" loop.");

            string command;
            do 
            {
                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                    .Title("Select a stop")
                    .AddChoices(selectedLoop.Stops)
                );
                Console.WriteLine("you selected "+selectedStop.Name+" stop.");
                            
                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of passengers:"));

                PassengerData data = new PassengerData(
                    boarded, 
                    selectedStop, 
                    selectedLoop, 
                    selectedDriver
                );

                dataManager.AddNewPassengerData(data);

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("continue or end?")
                    .AddChoices(new [] {
                        "continue", "end"
                    })
                );

            } while(command != "end");
        }
        else if (mode == "manager")
        {
            string command;
            do
            {
                List<string> options = new List<string>
                {
                    "add stop",
                    "delete stop",
                    "list stops",
                    "show busiest stop",
                    "end"
                };

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Enter a command, or end to end")
                    .AddChoices(options)
                );

                switch (command)
                {
                    case "add stop":
                        var newStopName = AnsiConsole.Prompt(new TextPrompt<string>("Enter new stop name:"));
                        dataManager.AddStop(new Stop(newStopName));
                        break;
                    case "delete stop":
                        Stop selectedStop = AnsiConsole.Prompt(
                            new SelectionPrompt<Stop>()
                            .Title("Delete which stop")
                            .AddChoices(dataManager.Stops)
                        );
                        dataManager.RemoveStop(selectedStop);
                        dataManager.SynchronizeStops();
                        break;
                    case "list stops":
                        var table = new Table();
                        table.AddColumn("Stop Name");
                        foreach(var stop in dataManager.Stops)
                        {
                            table.AddRow(stop.Name);
                        }
                        AnsiConsole.Write(table);
                        break;
                    case "show busiest stop":
                        var result = Reporter.FindBusiestStop(dataManager.PassengerData);
                        Console.WriteLine("the busiest stop is: "+result.Name);
                        break;
                    default:
                        break;
                }

            } while (command != "end");
        }
    }
}