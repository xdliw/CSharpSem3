using G253505_Kryshalovich_Lab5.Domain.Entities;

namespace G253505_Kryshalovich_Lab5.Domain;

public class EqualityComparerArtistFee : IEqualityComparer<ArtistFee>
{
    public bool Equals(ArtistFee x, ArtistFee y)
    {
        return x.Name == y.Name && x.Fee == y.Fee;
    }

    public int GetHashCode(ArtistFee obj)
    {
        return HashCode.Combine(obj.Name, obj.Fee);
    }
    
}