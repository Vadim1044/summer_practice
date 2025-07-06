namespace task05tests;
using task05;
using Xunit;

public class TestClass
{
    public int PublicField;
    private readonly string _privateField;
    public int Property { get; set; }

    public void Method(string param) { }
}

[Serializable]
public class AttributedClass : Attribute{ }

public class ClassAnalyzerTests
{
    [Fact]
    public void GetPublicMethods_ReturnsCorrectMethods()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var methods = analyzer.GetPublicMethods();

        Assert.Contains("Method", methods);
    }

    [Fact]
    public void GetAllFields_IncludesPrivateFields()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var fields = analyzer.GetAllFields();

        Assert.Contains("_privateField", fields);
    }

    [Fact]
    public void GetMethodParams_ReturnsCorrectParams()
    {
        var analyzer = new ClassAnalyzer(typeof(TestClass));
        var paramsList = analyzer.GetMethodParams("Method").ToList();

        Assert.Contains("param", paramsList);
    }

    [Fact]
    public void HasAttribute_ReturnsCorrectAttribute()
    {
        var myObject = new ClassAnalyzer(typeof(AttributedClass));
        bool isSerializable = myObject.HasAttribute<AttributedClass>();
        Assert.True(isSerializable);
    }
}