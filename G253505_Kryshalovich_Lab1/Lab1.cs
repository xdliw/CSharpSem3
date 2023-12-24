namespace G253505_Kryshalovich_Lab1;

using Entities;

public class Lab1
{
    public static void Execute()
    {
        ATS firstAts = new ATS();
        SetupData(firstAts);

        string f1 = "vlad", l1 = "treshinsky";
        string f2 = "gennady", l2 = "korotkevich";
        string t1 = "moscow", t2 = "new-york";
        int c1 = 4, c2 = 10;
        firstAts.AddCall(f1,l1,c1,t1);
        firstAts.AddCall(f1,l1,c2,t2);
        
        firstAts.AddCall(f2,l2,c2,t2);

        Console.WriteLine(firstAts.CountCallsToTown("moscow"));
        Console.WriteLine(firstAts.CostForLastName("treshinsky"));
        Console.WriteLine(firstAts.CostForLastName("korotkevich"));
        Console.WriteLine(firstAts.TotalCost());

        Console.WriteLine(firstAts.CountCallsToTown("dfghj"));
        Console.WriteLine(firstAts.CostForLastName("7y8ui1h2jbd"));
        Console.WriteLine(firstAts.CostForLastName("vlad"));
    }

    static void SetupData(ATS firstAts)
    {
        Client c1 = new Client("vlad","treshinsky");
        Client c2 = new Client("gennady","korotkevich");
        Tariff t1 = new Tariff(4, "moscow");
        Tariff t2 = new Tariff(10, "new-york");
        firstAts.AddClient(c1);
        firstAts.AddTariff(t1);
    }

}