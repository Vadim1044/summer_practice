namespace task05;
using System;
using System.Collections.Generic;
using System.Reflection;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }
    public IEnumerable<string> GetPublicMethods()
    {
        return _type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)
            .Select(method => method.Name);
    }
    public IEnumerable<string> GetMethodParams(string methodname)
    {
        return _type.GetMethod(methodname, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic).GetParameters().Select(method => method.Name);
    }
    public IEnumerable<string> GetAllFields()
    {
        return _type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic).Select(field => field.Name);
    }
    public IEnumerable<string> GetProperties()
    {
        return _type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic).Select(field => field.Name).ToList();
    }
    public bool HasAttribute<T>() where T : Attribute
    {
        var attribute = typeof(T).GetCustomAttributes(false);
        if (attribute.Length > 0)
        {
            return true;
        }
        else { return false; }
    }
}
