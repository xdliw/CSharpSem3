namespace G253505_Kryshalovich_Lab3.Entities;

using EventArgs;

public class Journal
{
    
    //data
    private List<string> _log = new();
    
    
    
    //methods
    public void LogClient(object? o, ClientEventArgs args)
    {
        _log.Add(args.Message);
    }
    
    public void LogTariff(object? o, TariffEventArgs args)
    {
        _log.Add(args.Message);
    }

    //with \n after every log
    public string GetAllLogs()
    {
        return _log.Aggregate((res, s) => res + (s + '\n'));
    }
    
    
    //
    // //actions
    // public Action<object?, TariffEventArgs>? LogTariff;
    // public Action<object?, ClientEventArgs>? LogClient = (sender, args) =>
    // {
    //     _log.Push_back(args.Message); //this is like static scenario so cant
    // };
    //
    //
}
