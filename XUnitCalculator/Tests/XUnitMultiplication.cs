using XUnitCalculator.Calculator;

namespace XUnitCalculator.Tests;

public class XUnitMultiplication : IDisposable
{
    private ICalculator _calculator;
    
    public XUnitMultiplication(ICalculator calculator)
    {
        _calculator = calculator;
    }

    [Fact]
    public void MultiplicateValues()
    {
        Assert.Equal(60, _calculator.Multiplication(5,12));
    }
    
    [Theory]
    [InlineData(4, 12, 48)]
    [InlineData(2, 7, 14)]
    public void ParametrizedMultiplicateTest(double a, double b, double expectedResult)
    {
        double result = _calculator.Multiplication(a, b);
        
        Assert.Equal(expectedResult, result);
    }

    public void Dispose()
    {
        _calculator = null;
    }
}