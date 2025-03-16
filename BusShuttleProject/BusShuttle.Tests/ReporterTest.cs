namespace BusShuttle.Tests;

using BusShuttle;

public class ReporterTests
{
    List<PassengerData> sampleData;

    public ReporterTests()
    {
        sampleData = new List<PassengerData>();
    }

    [Fact]
    public void Test_FindBusiestStop_Just2Stops()
    {
        Stop stop1 = new Stop("stop 1");
        Loop loop = new Loop("loop 1");
        Driver driver = new Driver("driver 1");

        PassengerData data = new PassengerData(1,stop1,loop,driver);
        sampleData.Add(data);

        Stop stop2 = new Stop("stop 2");
        data = new PassengerData(10,stop2,loop,driver);
        sampleData.Add(data);

        Stop busiestStop = Reporter.FindBusiestStop(sampleData);

        Assert.Equal(stop2.Name, busiestStop.Name);
    }

    [Fact]
    public void Test_FindBusiestStop_Just2Stops_MoreData()
    {
        Stop stop1 = new Stop("stop 1");
        Stop stop2 = new Stop("stop 2");
        Loop loop = new Loop("loop 1");
        Driver driver = new Driver("driver 1");

        PassengerData data = new PassengerData(1,stop1,loop,driver);
        sampleData.Add(data);

        data = new PassengerData(10,stop2,loop,driver);
        sampleData.Add(data);
        
        data = new PassengerData(10,stop1,loop,driver);
        sampleData.Add(data);

        System.Console.WriteLine(sampleData);

        Stop busiestStop = Reporter.FindBusiestStop(sampleData);

        Assert.Equal(stop1.Name, busiestStop.Name);
    }
}