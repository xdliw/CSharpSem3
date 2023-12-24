using System.Net.Security;

namespace G253505_Kryshalovich_Lab3.Entities;

using EventArgs;


public class ATS
{
    
//data
    private Dictionary<string,Tariff> _tariffs = new();
    private List<Client> _clients = new();
    private List<Call> _calls = new();
    
    //events
    public EventHandler<TariffEventArgs>? TariffHandler; //event with delegate : delegate void (object? sender, TEventArgs e)
    public EventHandler<ClientEventArgs>? ClientHandler;
    public EventHandler<CallEventArgs>? CallHandler;

    
    
//methods


    public void AddTariff(string name, int cost, string toTown)
    {
        _tariffs[name] = new Tariff(name,cost,toTown);
        
        TariffHandler?.Invoke(this,new TariffEventArgs
        (
            $"A tariff has been added. \"{name}\" : call to {toTown} for {cost}",name,cost,toTown)
        );
    }

    public void AddClient(string firstName, string lastName)
    {
        _clients.Add(new Client(firstName,lastName));
        
        ClientHandler?.Invoke(this,new ClientEventArgs
        (
            $"A client has been registered: {firstName} {lastName}",firstName,lastName)
        );
    }

    public void AddCall(string firstName, string lastName, string tariffName)
    {
        var costPerCall = _tariffs[tariffName].CostPerCall;
        var toTown = _tariffs[tariffName].ToTown;
        _calls.Add(new Call(new Client(firstName,lastName),new Tariff(tariffName,costPerCall,toTown!)));

        CallHandler?.Invoke(this,new CallEventArgs
        (
            $"A call has happened: {firstName} {lastName} has called to {toTown} for {costPerCall}",
            firstName, lastName, costPerCall, toTown!)
        );
    }
    
    //returns a string with name + '\n' for every tariff
    public string ListOfAllTariffs()
    {
        return (from t in _tariffs
                orderby t.Value.CostPerCall
                select t.Key)
                .Aggregate((res,s) => res + s + '\n');
    }

    public string ClientNameWithHighestCost()
    {
        Dictionary<string, int> cost = new();

        foreach (var c in _calls)
        {
            if(!cost.ContainsKey(c.Client.FirstName)) cost.Add(c.Client.FirstName,0);
            cost[c.Client.FirstName] += c.Tariff.CostPerCall;
        }

        return (from c in cost
                orderby c.Value
                select c.Key)
                .Last();
    }
    
    public int AmountOfClientsThatPaidMoreThan(int x)
    {
        Dictionary<string, int> cost = new();

        foreach (var c in _calls)
        {
            if(!cost.ContainsKey(c.Client.FirstName)) cost.Add(c.Client.FirstName,0);
            cost[c.Client.FirstName] += c.Tariff.CostPerCall;
        }

        return (from c in cost
                where c.Value > x
                select c)
                .Count();
    }

    //returns string - (name of tariff : cost for that tariff\n)
    public string CostForEachTariffForLastName(string lastName)
    {
        Dictionary<string, int> cost = new();

        foreach (var c in _calls)
        {
            if(c.Client.LastName != lastName) continue;

            var t = c.Tariff.Name;
            if(!cost.ContainsKey(t)) cost.Add(t,0);
            cost[t] += c.Tariff.CostPerCall;
        }

        return cost.Aggregate("", (current, c) => current + (c.Key + " : " + c.Value + '\n'));
    }
    
    public int CostForLastName(string lastName)
    {
        return (from call in _calls
                where call.Client?.LastName == lastName
                select call.Tariff
                into tariff
                where tariff != null
                select tariff)
                .Sum(t => t.CostPerCall);
    }
    
    public int TotalCost()
    {
        return (from call in _calls
                where call.Tariff != null
                select call.Tariff.CostPerCall
                into cost select cost)
                .Sum(c => c);
    }

    public int CountCallsToTown(string town)
    {
        return (from c in _calls
            select c.Tariff
            into tariff
            where tariff != null && tariff.ToTown == town
            select tariff).Count();
    }

}