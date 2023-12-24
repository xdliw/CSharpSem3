using System.Text.Json;
using G253505_Kryshalovich_Lab6.Domain;

namespace G253505_Kryshalovich_Lab6.FileServiceLib;

public class FileService<T> : IFileService<T> where T : class
{
    public IEnumerable<T>? ReadFile(string fileName)
    {
        using var fs = File.OpenRead(fileName);
        return JsonSerializer.Deserialize<IEnumerable<T>>(fs);
    }


    public void SaveData(IEnumerable<T> data, string fileName)
    {
        using var fs = File.OpenWrite(fileName);
        JsonSerializer.Serialize(fs,data);
    }
    
    
    
}