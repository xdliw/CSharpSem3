namespace G253505_Kryshalovich_Lab5.Domain.Interfaces;

using Entities;

public interface ISerializer
{
    
    IEnumerable<ArtistFee> DeSerializeByLINQ(string fileName);
    IEnumerable<ArtistFee> DeSerializeXML(string fileName);
    IEnumerable<ArtistFee> DeSerializeJSON(string fileName);
    void SerializeByLINQ(IEnumerable<ArtistFee> artistFees, string fileName);
    void SerializeXML(IEnumerable<ArtistFee> artistFees, string fileName);
    void SerializeJSON(IEnumerable<ArtistFee> artistFees, string fileName);
    
}