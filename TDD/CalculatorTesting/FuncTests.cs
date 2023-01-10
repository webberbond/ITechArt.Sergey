using NUnit.Framework;

namespace TDD.CalculatorTesting;

public class FuncTests 
{
    [Test]
    public void SumPositiveValues()
    {
        double result = Calculator.Sum(5, 1);
        Assert.AreEqual(6, result);
    }

    [Test]
    public void SumNegativeValues()
    {
        double result = Calculator.Sum(-3, -6);
        Assert.AreEqual(-9, result);
    }

    [Test]
    public void SubtractPositiveValues()
    {
        double result = Calculator.Subtraction(7, 2);
        Assert.AreEqual(5, result);
    }

    [Test]
    public void SubtractNegativeValues()
    {
        double result = Calculator.Subtraction(-1, -4);
        Assert.AreEqual(3,result);
    }

    [Test]
    public void MultiplicatePositiveValues()
    {
        double result = Calculator.Multiplication(3, 6);
        Assert.AreEqual(18,result);
    }

    [Test]
    public void MultiplicateNegativeValues()
    {
        double result = Calculator.Multiplication(-7, -1);
        Assert.AreEqual(7,result);
    }

    [Test]
    public void DividePostiveValues()
    {
        double result = Calculator.Division(6, 2);
        Assert.AreEqual(3,result);
    }

    [Test]
    public void DivideNegativeNumbers()
    {
        double result = Calculator.Division(-9, -3);
        Assert.AreEqual(3,result);
    }
}