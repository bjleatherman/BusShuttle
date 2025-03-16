namespace BusShuttle;

using Spectre.Console;

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
    }
}