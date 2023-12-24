
namespace G253505_Kryshalovich_Lab2;
using Collections.MyCustomCollectionStuff;
using Collections;
using Entities;

using static Utility; //for Cout



internal static class Program
{
    private static int Main()
    {
        var ats = new ATS();
        var journal = new Journal();
        
        ats.ClientHandler += journal.LogClient;
        ats.TariffHandler += journal.LogTariff;
        
        ats.CallHandler += (sender, args) => Cout(args.Message + '\n');
        
        ats.AddTariff(1,"1");
        ats.AddClient("q","q");
        ats.AddCall("w","w",2,"2");
        
        Cout(journal.GetAllLogs());


        try
        {
            try
            {
                var c = new MyCustomCollection<int>();
                
                Cout(c[0].ToString());
                

                throw new Exception("ghjkl");
                throw new NoItemInCollectionException();
            }
            catch (IndexOutOfRangeException e) when (1 == 1)
            {
                Cout(e.Message + '\n');
                try
                {
                    var c = new MyCustomCollection<int>();
                    c.Remove(1);
                }
                catch (NoItemInCollectionException ee)
                {
                    Cout(ee.Message + '\n');
                    throw;
                }

            }
            catch (Exception e)
            {
                Cout(e.Message);
            }
        }
        catch
        {
            Cout("handling all the exceptions!");
        }

        return 0;
    }
}

 