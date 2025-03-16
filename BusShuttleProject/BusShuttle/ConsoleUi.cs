namespace BusShuttle;

public class ConsoleUI
{
    FileSaver fileSaver;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("passenger-data.txt");
    }

    public void Show()
    {
        string mode = AskForInput("Please select mode (driver or manager)");

        if (mode == "driver")
        {
            string command;
            do 
            {
                string stopName = AskForInput("Enter stop name");              
                int boarded= int.Parse(AskForInput("Enter number of passengers boarded"));

                fileSaver.AppendLine(stopName+":"+boarded);

                command = AskForInput("Enter command: (end or continue)");

            } while(command != "end");
        }
    }
    
    public static string AskForInput(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }
}