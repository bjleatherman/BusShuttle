namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{

    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-doc.txt";
        File.Delete(testFileName);
        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        string testText = "Hello, World!";

        fileSaver.AppendLine(testText);
        var contentsFromFile = File.ReadAllText(testFileName);

        Assert.Equal(contentsFromFile, testText+Environment.NewLine);
    }

    [Fact]
    public void Test_FileSaver_AppendData()
    {

        char sep = ':';

        string stopName = "stop";
        string loopName = "loop";
        string driverName = "driver";

        int boarded = 1;
        Stop stop = new Stop(stopName);
        Loop loop = new Loop(loopName);
        Driver driver = new Driver(driverName);

        string testString = String.Join(sep,
            driver.Name, 
            loop.Name, 
            stop.Name, 
            boarded.ToString()
            )
            + Environment.NewLine;

        PassengerData data = new PassengerData(
            boarded, 
            stop,
            loop,
            driver
        );

        fileSaver.AppendData(data);

        var contentsFromFile = File.ReadAllText(testFileName);

        Assert.Equal(testString, contentsFromFile);

    }
}