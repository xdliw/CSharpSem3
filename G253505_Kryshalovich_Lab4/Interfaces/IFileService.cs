namespace G253505_Kryshalovich_Lab4.Interfaces;

public interface IFileService<T>
{
    //что за abstract и почему он нужен для того, чтобы метод можно было сделать статическим тут?
    static abstract IEnumerable<T> ReadFile(string fileName);
    static abstract void SaveData(IEnumerable<T> data, string fileName);
}