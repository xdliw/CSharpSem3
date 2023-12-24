namespace G253505_Kryshalovich_Lab2.Entities;

public class Tariff
{
    public Tariff(int costPerCall, string toTown)
    {
        CostPerCall = costPerCall;
        ToTown = toTown;
    }
    public int CostPerCall { get; set; } 
    public string? ToTown { get; set; }
}