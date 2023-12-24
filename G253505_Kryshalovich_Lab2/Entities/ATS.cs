using G253505_Kryshalovich_Lab2.Collections;
using G253505_Kryshalovich_Lab2.Entities.EventArgs;

namespace G253505_Kryshalovich_Lab2.Entities;

public class ATS : Contracts.IATS
{
    
    
//data
    private MyCustomCollection<Tariff> _tariffs = new();
    private MyCustomCollection<Client> _clients = new();
    private MyCustomCollection<Call> _calls = new();
    
    //events
    public EventHandler<TariffEventArgs>? TariffHandler; //event with delegate : delegate void (object? sender, TEventArgs e)
    public EventHandler<ClientEventArgs>? ClientHandler;
    public EventHandler<CallEventArgs>? CallHandler;

    
    
//methods

    
    public override void AddTariff(int cost, string toTown)
    {
        _tariffs.Push_back(new Tariff(cost, toTown));
        
        TariffHandler?.Invoke(this,new TariffEventArgs
        (
            $"A tariff has been added: call to {toTown} for {cost}",cost,toTown)
        );
    }

    public override void AddClient(string firstName, string lastName)
    {
        _clients.Push_back(new Client(firstName,lastName));
        
        ClientHandler?.Invoke(this,new ClientEventArgs
        (
            $"A client has been registered: {firstName} {lastName}",firstName,lastName)
        );
    }

    public override void AddCall(string firstName, string lastName, int costPerCall, string toTown)
    {
        _calls.Push_back(new Call(new Client(firstName,lastName),new Tariff(costPerCall,toTown)));

        CallHandler?.Invoke(this,new CallEventArgs
        (
            $"A call has happened: {firstName} {lastName} has called to {toTown} for {costPerCall}",
            firstName, lastName, costPerCall, toTown)
        );
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