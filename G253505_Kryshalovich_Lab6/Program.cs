using G253505_Kryshalovich_Lab6.Domain;
using System.Reflection;

namespace G253505_Kryshalovich_Lab6;

internal static class Program
{
    private static int Main()
    {
        
        Queue<Employee> queue = new();
        queue.Enqueue(new Employee("LYN(U)X",45,true));
        queue.Enqueue(new Employee("Rozum",9,true));
        queue.Enqueue(new Employee("TETRAHYDROPYRANYLCYCLOPENTYLTETRAHYDROPYRIDOPYRIDINE",123456,true));
        queue.Enqueue(new Employee("Livesey",3,true));
        queue.Enqueue(new Employee("Cormick",4,true));
        queue.Enqueue(new Employee("Erik",126,true));
        
        var dllName = "G253505_Kryshalovich_Lab6.FileServiceLib.dll";
        
        var asm = Assembly.LoadFrom(dllName);
        
        var types = asm.GetTypes();
        foreach(var t in types) Console.WriteLine(t.Name);
        
        var className = "G253505_Kryshalovich_Lab6.FileServiceLib.FileService`1";
        Type? type = asm.GetType(className);
        
        if (type == null)
        {
            Console.WriteLine("ERROR: the type is null");
            return 1;
        }

        var genericType = type.MakeGenericType(typeof(Employee));
        
        var fileName = "lab6task.txt";
        var instance = Activator.CreateInstance(genericType);

        MethodInfo? saveData = genericType.GetMethod("SaveData", BindingFlags.Public | BindingFlags.Instance);

        if (saveData == null)
        {
            Console.WriteLine("ERROR: saveData is null");
            return 1;
        }
        
        saveData.Invoke(instance, new object[] { queue, fileName });

        var readFile = genericType.GetMethod("ReadFile", BindingFlags.Public | BindingFlags.Instance);
        if (readFile == null)
        {
            Console.WriteLine("ERROR: readFile is null");
            return 1;
        }
        
        if (readFile.Invoke(instance, new object[] { fileName }) is not IEnumerable<Employee> list)
        {
            Console.WriteLine("ERROR: list is null");
            return 1;
        }

        foreach (var e in list)
        {
            Console.WriteLine($"{e.Name} with rating {e.Rating} {(e.WorkingAtTheMoment?"is":"isn't")} working at the moment");
        }
        
        return 0;
    }
}