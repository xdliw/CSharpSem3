namespace G253505_Kryshalovich_Lab2.Entities.EventArgs;


public class TariffEventArgs
{
    public string Message { get; }
    public int Cost { get; }
    public string ToTown { get; }

    public TariffEventArgs(string message, int cost,string toTown)
    {
        Message = message;
        Cost = cost;
        ToTown = toTown;
    }
}