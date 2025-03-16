namespace BusShuttle;

public class Reporter
{
    public static Stop FindBusiestStop(List<PassengerData> data)
    {
        var passengerCountPerStop = new Dictionary<string, int>();

        foreach(var item in data)
        {
            if (!passengerCountPerStop.ContainsKey(item.Stop.Name))
            {
                passengerCountPerStop.Add(item.Stop.Name,0);
            }
            passengerCountPerStop[item.Stop.Name] += item.Boarded;
        }

        string busiestStop = "";
        int highestSum = -1;

        foreach (var item in passengerCountPerStop)
        {
            if(item.Value > highestSum)
            {
                highestSum = item.Value;
                busiestStop = item.Key;
            }
        }
        
        return new Stop(busiestStop);
    }
}