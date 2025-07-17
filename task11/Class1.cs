using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Reflection;
namespace task11;

public class ClassGenerator
{
    public static Type GenerateCalculatorType()
    {
        string code = "public class Calculator{public int Add(int a,int b){return a+b;}" +
                     "public int Minus(int a,int b){return a-b;}" +
                     "public int Mul(int a, int b){return a*b;}"+
                     "public int Div(int a, int b){return a/b;}}";

        var tree = CSharpSyntaxTree.ParseText(code);

        var refs = new MetadataReference[2];
        refs[0] = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        refs[1] = MetadataReference.CreateFromFile(typeof(Console).Assembly.Location);

        var comp = CSharpCompilation.Create(
            "Calc",
            new[] { tree },
            refs,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var stream = new MemoryStream();
        var result = comp.Emit(stream);



        stream.Position = 0;
        var asm = Assembly.Load(stream.ToArray());
        return asm.GetType("Calculator");
    }
}
