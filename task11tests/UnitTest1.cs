using System.Threading.Tasks;

namespace task11tests;

using System;
using task11;
using Xunit;

public class TestCalculator
{
    [Fact]
    public void AddTest()
    {
        var calculatorType = ClassGenerator.GenerateCalculatorType();
        dynamic calculator = Activator.CreateInstance(calculatorType);
        Assert.Equal(8, calculator.Add(5, 3));
    }
    [Fact]
    public void MinusTest()
    {
        var calculatorType = ClassGenerator.GenerateCalculatorType();
        dynamic calculator = Activator.CreateInstance(calculatorType);
        Assert.Equal(2, calculator.Minus(5, 3));
    }
    [Fact]
    public void MulTest()
    {
        var calculatorType = ClassGenerator.GenerateCalculatorType();
        dynamic calculator = Activator.CreateInstance(calculatorType);
        Assert.Equal(15, calculator.Mul(5, 3));
    }
    [Fact]
    public void DivTest()
    {
        var calculatorType = ClassGenerator.GenerateCalculatorType();
        dynamic calculator = Activator.CreateInstance(calculatorType);
        Assert.Equal(3, calculator.Div(6, 2));
    }
}