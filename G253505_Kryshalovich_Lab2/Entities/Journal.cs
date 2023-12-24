namespace G253505_Kryshalovich_Lab2.Entities;
using Collections;
using EventArgs;

public class Journal
{
    
    //data
    private MyCustomCollection<string> _log = new();
    
    
    
    //methods
    public void LogClient(object? o, ClientEventArgs args)
    {
        _log.Push_back(args.Message);
    }
    
    public void LogTariff(object? o, TariffEventArgs args)
    {
        _log.Push_back(args.Message);
    }

    //with \n after every log
    public string GetAllLogs() 
    {
        var res = "";
        foreach (var s in _log)
        {
            res += s + '\n';
        }

        return res;
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
