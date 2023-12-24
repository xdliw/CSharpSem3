using G253505_Kryshalovich_Lab1.Collections;

namespace G253505_Kryshalovich_Lab1.Entities;

public class ATS : Contracts.IATS
{
    private MyCustomCollection<Tariff> _tariffs = new MyCustomCollection<Tariff>();
    private MyCustomCollection<Client> _clients = new MyCustomCollection<Client>();
    private MyCustomCollection<Call> _calls = new MyCustomCollection<Call>();

    public override void AddTariff(int cost, string toTown)
    {
        _tariffs.Push_back(new Tariff(cost, toTown));
    }

    public void AddTariff(Tariff tariff)
    {
        _tariffs.Push_back(tariff);
    }

    public override void AddClient(string first, string last)
    {
        _clients.Push_back(new Client(first,last));
    }
    public void AddClient(Client client)
    {
        _clients.Push_back(client);
    }
    

    public override void AddCall(string firstName, string lastName, int costPerCall, string toTown)
    {
        _calls.Push_back(new Call(new Client(firstName,lastName),new Tariff(costPerCall,toTown)));
    }

    public void AddCall(Call call)
    {
        _calls.Push_back(call);
    }

    public override int CostForLastName(string lastName)
    {
        int cost = 0;
    
        for (int i = 0; i < _calls.Count; ++i)
        {
            if (_calls[i].Client?.LastName == lastName)
            {
                var tariff = _calls[i].Tariff;
                if (tariff != null)
                    cost += tariff.CostPerCall;
            }
        }

        return cost;

    }

    public override int TotalCost()
    {
        int cost = 0;
        
        for (int i = 0; i < _calls.Count; ++i)
        {
            var tariff = _calls[i].Tariff;
            if (tariff != null) cost += tariff.CostPerCall;
        }

        return cost;
    }

    public override int CountCallsToTown(string town)
    {
        int count = 0;
        for (int i = 0; i < _calls.Count; ++i)
        {
            var tariff = _calls[i].Tariff;
            if(tariff != null && tariff.ToTown == town) count++;
            
        }

        return count;
    }

}