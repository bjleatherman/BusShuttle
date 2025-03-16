using System.Xml.Schema;

namespace BusShuttle;

public class DataManager
{
    string passengerDataFileName = "passenger-data.txt";
    string stopsFileName = "stops.txt";
    FileSaver fileSaver;
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }

    public DataManager()
    {
        fileSaver = new FileSaver(passengerDataFileName);

        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();
        var stopsFileContent = File.ReadAllLines(stopsFileName);

        foreach(var stopName in stopsFileContent)
        {
            Stops.Add(new Stop(stopName));
        }

        Loops[0].Stops.AddRange(Stops.GetRange(0, 2));
        Loops[1].Stops.AddRange(Stops.GetRange(2, 2));
        Loops[2].Stops.AddRange(Stops.GetRange(4, 2));

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Mark"));
        Drivers.Add(new Driver("Mecky"));
        Drivers.Add(new Driver("Mike"));
        Drivers.Add(new Driver("Momo"));
        Drivers.Add(new Driver("Mum"));
        Drivers.Add(new Driver("Myanmar"));

        PassengerData = new List<PassengerData>();

        if(File.Exists(passengerDataFileName))
        {
            var passengerFileContent = File.ReadAllLines(passengerDataFileName);
            foreach (var line in passengerFileContent)
            {
                var split = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
                var driver = new Driver(split[0]);
                var loop = new Loop(split[1]);
                var stop = new Stop(split[2]);
                int boarded = int.Parse(split[3]);

                PassengerData.Add(new PassengerData(boarded, stop, loop, driver));
            }
        }
    }

    public void AddNewPassengerData(PassengerData data)
    {
        this.PassengerData.Add(data);
        fileSaver.AppendData(data);
    }

    public void SynchronizeStops()
    {
        File.Delete(stopsFileName);
        foreach (var stop in Stops)
        {
            File.AppendAllText(stopsFileName, stop.Name+Environment.NewLine);
        }
    }

    public void AddStop(Stop stop)
    {
        Stops.Add(stop);
        SynchronizeStops();
    }

    public void RemoveStop(Stop stop)
    {
        Stops.Remove(stop);
        SynchronizeStops();
    }
}