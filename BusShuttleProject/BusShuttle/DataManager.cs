namespace BusShuttle;

public class DataManager
{
    FileSaver fileSaver;
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }

    public DataManager()
    {
        fileSaver = new FileSaver("passenger-data.txt");

        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));

        Stops = new List<Stop>();
        Stops.Add(new Stop("Bango"));
        Stops.Add(new Stop("Bengo"));
        Stops.Add(new Stop("Bingo"));
        Stops.Add(new Stop("Bongo"));
        Stops.Add(new Stop("Bungo"));
        Stops.Add(new Stop("Byngo"));

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
    }

    public void AddNewPassengerData(PassengerData data)
    {
        this.PassengerData.Add(data);
        fileSaver.AppendData(data);
    }
}