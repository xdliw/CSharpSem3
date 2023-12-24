using G253505_Kryshalovich_Lab2.Entities;

namespace G253505_Kryshalovich_Lab2.Contracts;
using Collections;

public abstract class IATS
{
    private MyCustomCollection<Tariff> _tariffs;
    private MyCustomCollection<Client> _clients;
    private MyCustomCollection<Call> _calls;
    public abstract void AddTariff(int cost, string toTown);
    public abstract void AddClient(string first, string last);
    public abstract void AddCall(string firstName, string lastName, int costPerCall, string toTown);
    public abstract int CostForLastName(string lastName);
    public abstract int TotalCost();
    public abstract int CountCallsToTown(string town);
}