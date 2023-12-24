using System.Numerics;

namespace G253505_Kryshalovich_Lab4.Comparer;
using Entities;
//2 вопроса в файле

public class MyCustomComparer : IComparer<Music>
{
    //можно ли сделать как расширение для класса Music? типо <>==
    public int Compare(Music? x, Music? y)
    {
        return String.CompareOrdinal(x?.Name, y?.Name);
        
        //там в конце концов есть проверка на null и какие-то действия предприняты.
        //То есть так и стоит делать: принимать возможный null и только в самом конце обрабатывать эти случаи?
    }
}