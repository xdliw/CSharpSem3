namespace G253505_Kryshalovich_Lab3.Entities.EventArgs;


public class TariffEventArgs
{
    public string Message { get; }
    public string Name { get; }
    public int Cost { get; }
    public string ToTown { get; }

    public TariffEventArgs(string message, string name, int cost,string toTown)
    {
        Name = name;
        Message = message;
        Cost = cost;
        ToTown = toTown;
    }
}