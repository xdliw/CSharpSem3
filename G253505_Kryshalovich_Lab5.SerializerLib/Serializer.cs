using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using G253505_Kryshalovich_Lab5.Domain.Entities;

namespace G253505_Kryshalovich_Lab5.SerializerLib;

using Domain.Interfaces;


public class Serializer : ISerializer
{
    public IEnumerable<ArtistFee> DeSerializeByLINQ(string fileName)
    {
        var xd = XDocument.Load(fileName);
        var xAFS = xd.Element("ArrayOfArtistFee");

        if (xAFS == null) yield break;
        
        foreach (var xAF in xAFS.Elements("ArtistFee"))
        {
            var xName = xAF.Attribute("Name").Value;
            var xFee = int.Parse(xAF.Element("Fee").Value);

            yield return new ArtistFee(xName, xFee);
        }
    }

    public IEnumerable<ArtistFee> DeSerializeXML(string fileName)
    {
        using var fs = File.OpenRead(fileName);
        
        var xs = new XmlSerializer(typeof(List<ArtistFee>));
        return xs.Deserialize(fs) as IEnumerable<ArtistFee>;
    }

    public IEnumerable<ArtistFee> DeSerializeJSON(string fileName)
    {
        using var fs = File.OpenRead(fileName);
        return JsonSerializer.Deserialize<IEnumerable<ArtistFee>>(fs);
    }

    public void SerializeByLINQ(IEnumerable<ArtistFee> artistFees, string fileName)
    {
        XDocument xd = new();

        XElement xAFS = new("ArrayOfArtistFee");

        foreach (var af in artistFees)
        {
            var xAF = new XElement("ArtistFee");

            var XName = new XAttribute("Name", af.Name);
            var XFee = new XElement("Fee", af.Fee);
            
            xAF.Add(XName);
            xAF.Add(XFee);
            xAFS.Add(xAF);
        }
        
        xd.Add(xAFS);
        xd.Save(fileName);
    }

    //only for List<ArtistFee>
    public void SerializeXML(IEnumerable<ArtistFee> artistFees, string fileName)
    {
        using var fs = File.OpenWrite(fileName);
        
        var xs = new XmlSerializer(typeof(List<ArtistFee>));
        xs.Serialize(fs,artistFees);
    }

    public void SerializeJSON(IEnumerable<ArtistFee> artistFees, string fileName)
    {
        using var fs = new FileStream(fileName, FileMode.OpenOrCreate);
        JsonSerializer.Serialize<IEnumerable<ArtistFee>>(fs, artistFees);
    }
}