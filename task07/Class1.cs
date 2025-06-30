namespace task07;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public sealed class DisplayNameAttribute : Attribute
{
    public string DisplayName {get;}

    public DisplayNameAttribute(string displayName)
    {
      DisplayName = displayName;
    }
}
public sealed class VersionAttribute : Attribute
{
    public int Major { get; }
    public int Minor { get; }

    public VersionAttribute(string version)
    {
        string[] version_split = version.Split('.');
        Minor = Convert.ToInt32(version_split[1]);
        Major = Convert.ToInt32(version_split[0]);
    }
}

[DisplayNameAttribute("Пример класса")]
[VersionAttribute("1.0")]
public class SampleClass
{
    private Type _type;

    public SampleClass(Type type)
    {
        _type = type;
    }
    [DisplayName("Тестовый метод")]
    public string TestMethod(string name)
    {
        return _type.Name;
    }
    [DisplayName("Числовое свойство")]
    public int Number { get; set; }
}

public class ReflectionHelper()
{

    public static IEnumerable<string> PrintTypeInfo(Type type)
    {
        var displayName = type.GetCustomAttribute<DisplayNameAttribute>();
        var displayVersion = type.GetCustomAttribute<VersionAttribute>();
        if (displayVersion != null && displayName != null) { Console.WriteLine(displayName + " " + displayVersion); }
        else { if (displayName != null) { Console.WriteLine(displayName); } if (displayVersion != null) { Console.WriteLine(displayVersion); } }

        var methods = type.GetMethods().Where(method => method.GetCustomAttributes<DisplayNameAttribute>().Any()).Select(method => method.Name).ToList();
        var propetyes = type.GetProperties().Where(property => property.GetCustomAttributes<DisplayNameAttribute>().Any()).Select(property => property.Name).ToList();
        for (int item = 0; item <= methods.Count() - 1; item++)
        {
            yield return methods[item];
        }
        for (int item = 0; item <= propetyes.Count() - 1; item++)
        {
            yield return propetyes[item];
        }
    }
}
