using System.Threading.Tasks;
using System;
using System.Reflection;
using task09;

public class Program
{
    public static void Main(string[] path)
    {
        if (path.Length == 0)
        {
            Console.WriteLine("Отсутствует путь до dll");
        }
        string dll_path = path[0];
        Console.WriteLine($"Assembly: {dll_path}");
        Assembly assembly = Assembly.LoadFile(dll_path);

        foreach (Type type in assembly.GetTypes())
        {
            string className = type.Name;
            Console.WriteLine($"\nClass: {className}");


            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var m in methods)
            {
                Console.WriteLine("Method: " + m);
                var parameters = m.GetParameters();
                foreach (var p in parameters) { Console.WriteLine("Parameters: " + p.Name); }
            }

            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var constructor in constructors)
            {
                Console.WriteLine("Constructors: " + constructor);
                var parameters = constructor.GetParameters();
                foreach (var p in parameters) { Console.WriteLine("Parameters: " + p.Name); }
            }

            var attributes = type.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                Console.WriteLine("Attributes: " + attribute);
            }
            var results = ReflectionHelper.PrintTypeInfo(type).ToList();
            foreach (var result in results) { Console.WriteLine(result); }
            Console.WriteLine();
        }
    }
}