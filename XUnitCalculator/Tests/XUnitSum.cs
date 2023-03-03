using XUnitCalculator.Calculator;

namespace XUnitCalculator.Tests;

[Collection("Sum Collection")]
public class XUnitSum
{
    private readonly ICalculator _calculator;
    
    public XUnitSum(ICalculator calculator)
    {
        _calculator = calculator;
    }
    
    [Fact]
    public void SumPositiveValues()
    {
        Assert.Equal(3, _calculator.Sum(2,1));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(5, 6, 11)]
    public void ParametrizedSumTest(double a, double b, double expectedResult)
    {
        double result = _calculator.Sum(a, b);
        
        Assert.Equal(expectedResult, result);
    }
}