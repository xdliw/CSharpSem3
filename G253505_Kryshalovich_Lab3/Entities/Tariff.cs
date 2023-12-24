namespace G253505_Kryshalovich_Lab3.Entities;

public class Tariff
{
    public string Name { get; set; }
    public int CostPerCall { get; set; } 
    public string? ToTown { get; set; }
    public Tariff(string name, int costPerCall, string toTown)
    {
        Name = name;
        CostPerCall = costPerCall;
        ToTown = toTown;
    }
    
}