using System.Collections;
using G253505_Kryshalovich_Lab5.Domain;

namespace G253505_Kryshalovich_Lab5;
using Domain.Entities;
using SerializerLib;


using static Utility;

internal static class Program
{
    private static int Main()
    {

        List<ArtistFee> afs = new();
        afs.Add(new ArtistFee("q", 1));
        afs.Add(new ArtistFee("qwe", 2));
        afs.Add(new ArtistFee("yujq", 3));
        afs.Add(new ArtistFee("q91c27iyh", 4));

        var fileNameXml = "lab5Xml";
        var fileNameLinqXml = "lab5LinqXml";
        var fileNameJson = "lab5Json";
        
        Serializer s = new();
        
        s.SerializeXML(afs,fileNameXml);
        s.SerializeByLINQ(afs,fileNameLinqXml);
        s.SerializeJSON(afs,fileNameJson);
        
        var Xml = s.DeSerializeXML(fileNameXml);
        var LinqXml = s.DeSerializeByLINQ(fileNameLinqXml);
        var Json = s.DeSerializeJSON(fileNameJson);
        
        var L1 = new List<ArtistFee>(Xml);
        var L2 = new List<ArtistFee>(LinqXml);
        var L3 = new List<ArtistFee>(Json);
        
        var c = new EqualityComparerArtistFee();
        
        
        
        //не получилось сравнить нормально
        
        bool ok = true;
        for (int i = 0; i < afs.Count; ++i)
        {
            if (!(c.Equals(L1[i],afs[i]) && c.Equals(L2[i],afs[i]) && c.Equals(L3[i],afs[i])))
            {
                ok = false;
                break;
            }
        }

        Console.WriteLine(ok);

        
        return 0;
    }
    
    private static void Cwafe(IEnumerable<ArtistFee> af)
    {
        foreach (var a in af)
        {
            Cw($"{a.Name} got {a.Fee} for a commission\n");
        }
    }
}