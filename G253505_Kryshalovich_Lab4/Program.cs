using System.Collections;

namespace G253505_Kryshalovich_Lab4;

using Entities;
using Services;
using Comparer;
using static Utility;

//0 вопросов в файле




internal static class Program
{
    private static int Main()
    {
        
        var path = Directory.GetCurrentDirectory() + "\\Kryshalovich_Lab4";
        
        //delete the directory
        Directory.Delete(path,true);
        
        //create directory and fill with 10 random empty files
        Directory.CreateDirectory(path);
        for(int i = 0; i < 10;++i) File.Create(path + '\\' + Path.GetRandomFileName());

        //output
        foreach (var file in Directory.EnumerateFiles(path).Select(s => Path.GetFileName(s)))
        {
            var s = file.Split('.');
            Cw($"Файл: {s[0]} имеет расширение {s[1]}\n");
        }
        
//music part of the laba

        List<Music> musicCollection = new();
        musicCollection.Add(new Music("Converting Vegetarians",343,true));
        musicCollection.Add(new Music("Soft Fuzzy Man",174,true));
        musicCollection.Add(new Music("Happy Birthday",116,false));
        musicCollection.Add(new Music("Jingle Bells",117,false));
        musicCollection.Add(new Music("La Campanella",286,true));
        musicCollection.Add(new Music("Cleric Beast",186,true));

        //create file and save
        var fullFilePath = path + '\\' + "musicCollectionFile.music";
        FileServiceMusic.SaveData(musicCollection,fullFilePath);

        //rename
        var newFullFilePath = path + '\\' + "musicaNaDiske.music";
        File.Move(fullFilePath, newFullFilePath);

        //read
        var newMusicCollection = FileServiceMusic.ReadFile(newFullFilePath);

        Console.WriteLine("\nИсходная коллекция: ");
        Test.CMusic(musicCollection);

        Console.WriteLine("\nОтсортированная коллекция из файла: ");
        Test.CMusic(newMusicCollection.OrderBy(m => m, new MyCustomComparer()));
        
        Console.WriteLine("\nОтсортированная коллекция из файла по свойству bool Favourite по убыванию: ");
        Test.CMusic(newMusicCollection.OrderByDescending(m => m.Favourite));

        return 0;
    }

    
}

internal static class Test
{
    public static void CMusic(IEnumerable<Music> m)
    {
        foreach (var q in m)
        {
            Cw($"{q.Name} : {q.LengthSeconds} seconds, is favourite = {q.Favourite}\n");
        }
    }
    public static void Tost()
    {
        
        List<Music> musicCollection = new();
        Music track1 = new Music("Snatch",601,true);
        Music track2 = new Music("La Campanella",505,true);
        musicCollection.Add(track1);
        musicCollection.Add(track2);
        Test.CMusic(musicCollection);


        var fileName1 = "test1";
        FileServiceMusic.SaveData(musicCollection,fileName1);
        
        FileServiceMusic.SaveData(musicCollection,fileName1);
        
        Cw("From file:\n");
        try
        {
            
            IEnumerable<Music> musicCollectionFromFile1 = FileServiceMusic.ReadFile(fileName1);
            Test.CMusic(musicCollectionFromFile1);
        }
        catch (Exception e)
        {
            Cw("ERROR: " + e.Message);
        }
        
    }
}