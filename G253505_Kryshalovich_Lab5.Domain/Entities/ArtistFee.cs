namespace G253505_Kryshalovich_Lab5.Domain.Entities;

public class ArtistFee
{
    public string? Name { get; set; }
    public int? Fee { get; set; }
    
    public ArtistFee(){}

    public ArtistFee(string? name, int? fee)
    {
        Name = name;
        Fee = fee;
    }
}
