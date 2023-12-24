namespace G253505_Kryshalovich_Lab4.Entities;

public class Music
{
//data
    public string Name { get; }
    public int LengthSeconds { get; }
    public bool Favourite { get; }

    public Music(string name, int lengthSeconds, bool favourite)
    {
        Name = name;
        LengthSeconds = lengthSeconds;
        Favourite = favourite;
    }
    
}