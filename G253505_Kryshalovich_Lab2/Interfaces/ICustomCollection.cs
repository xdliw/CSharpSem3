namespace G253505_Kryshalovich_Lab2.Interfaces;

public interface ICustomCollection<T>
{
    T this[int index] { get; set; }
    private void Reset()
    {
        throw new NotImplementedException();
    }

    private void Next()
    {
        throw new NotImplementedException();
    }

    private T Current()
    {
        throw new NotImplementedException();
    }

    int Count { get; }
    void Push_back(T item);
    void Remove(T item);
    private T RemoveCurrent()
    {
        throw new NotImplementedException();
    }
}