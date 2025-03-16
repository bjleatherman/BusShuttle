namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests()
    {
        File.WriteAllText("stops.txt", 
            "One"+Environment.NewLine+
            "Two"+Environment.NewLine+
            "Three"+Environment.NewLine+
            "Four"+Environment.NewLine+
            "Five"+Environment.NewLine+
            "Six"+Environment.NewLine
        );

        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop()
    {
        Assert.Equal(6, dataManager.Stops.Count);
        dataManager.AddStop(new Stop("newStop"));
        Assert.Equal(7, dataManager.Stops.Count);
    }
}