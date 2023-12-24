namespace G253505_Kryshalovich_Lab1.Entities;

public class Call
{
    public Call(Client client, Tariff tariff)
    {
        Client = client;
        Tariff = tariff;
    }
    public Client? Client { get; set; }
    public Tariff? Tariff { get; set; }
}