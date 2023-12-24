namespace G253505_Kryshalovich_Lab3;
using Entities;
using static Utility;

internal static class Program
{
    private static int Main()
    {
        Cout("Lab1--------------------------------------------------------\n");


        ATS firstAts = new ATS();

        string f1 = "vlad", l1 = "treshinsky";
        string f2 = "gennady", l2 = "korotkevich";
        string t1 = "moscow", t2 = "new-york";
        int c1 = 4, c2 = 10;
        firstAts.AddTariff("one",c1,t1);
        firstAts.AddTariff("two",c2,t2);
        
        firstAts.AddCall(f1,l1,"one");
        firstAts.AddCall(f1,l1,"two");
        firstAts.AddCall(f2,l2,"two");

        Console.WriteLine(firstAts.CountCallsToTown("moscow"));
        Console.WriteLine(firstAts.CostForLastName("treshinsky"));
        Console.WriteLine(firstAts.CostForLastName("korotkevich"));
        Console.WriteLine(firstAts.TotalCost());
        
        
        Console.WriteLine(firstAts.CountCallsToTown("dfghj"));
        Console.WriteLine(firstAts.CostForLastName("7y8ui1h2jbd"));
        Console.WriteLine(firstAts.CostForLastName("vlad"));
        
        Cout("\nLab3-------------------------------\n");
        Cout(firstAts.ClientNameWithHighestCost() + '\n');
        Cout(firstAts.AmountOfClientsThatPaidMoreThan(9).ToString() + '\n');
        Cout(firstAts.AmountOfClientsThatPaidMoreThan(10).ToString() + '\n');
        Cout($"{l1}'s tariff costs are\n" + firstAts.CostForEachTariffForLastName(l1));
        
        
        
        Cout("\nLab2--------------------------------------------------------\n");
        
        
        
        var ats = new ATS();
        var journal = new Journal();
        
        ats.ClientHandler += journal.LogClient;
        ats.TariffHandler += journal.LogTariff;
        
        ats.CallHandler += (sender, args) => Cout(args.Message + '\n');
        
        ats.AddTariff("one",1,"1");
        ats.AddClient("q","q");
        ats.AddCall("w","w","one");
        
        Cout(journal.GetAllLogs());


        return 0;
    }
   
}

