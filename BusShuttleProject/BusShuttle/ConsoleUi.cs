namespace BusShuttle;

using Spectre.Console;

public class ConsoleUI
{
    FileSaver fileSaver;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("passenger-data.txt");
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
            string command;
            do 
            {
                string stopName = AskForInput("Enter stop name");              
                int boarded= int.Parse(AskForInput("Enter number of passengers boarded"));

                fileSaver.AppendLine(stopName+":"+boarded);

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
        return Console.ReadLine();
    }
}