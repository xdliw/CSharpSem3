namespace G253505_Kryshalovich_Lab4.Services;

using Entities;
using Interfaces;

//2 вопроса в файле


/// <summary> Exceptions: FileNotFoundException and others</summary>
public class FileServiceMusic : IFileService<Music>
//почему нельзя сделать этот класс статическим, если он наследуется
{
    
    public static IEnumerable<Music> ReadFile(string fileName)
    {
        using var reader = new BinaryReader(File.OpenRead(fileName));
        while (reader.PeekChar() != -1)
        {
            string name;
            int lengthSeconds;
            bool favourite;

            try
            {
                name = reader.ReadString();
                lengthSeconds = reader.ReadInt32();
                favourite = reader.ReadBoolean();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                yield break;
            }
            
            yield return new Music(name, lengthSeconds, favourite);
            
        }
    }

    public static void SaveData(IEnumerable<Music> data, string fileName)
    {
        using var writer = new BinaryWriter(File.Create(fileName));
        foreach (var d in data)
        {
            //что если стринг больше чем 127 байт? writer перед стрингом записывает его длину 7битным числом, так?
            try
            {
                writer.Write(d.Name);
                writer.Write(d.LengthSeconds);
                writer.Write(d.Favourite);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}