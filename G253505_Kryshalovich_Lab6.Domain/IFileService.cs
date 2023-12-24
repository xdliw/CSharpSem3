namespace G253505_Kryshalovich_Lab6.Domain;

public interface IFileService<T> where T : class
{
    IEnumerable<T>? ReadFile(string fileName);
    void SaveData(IEnumerable<T> data, string fileName);
}