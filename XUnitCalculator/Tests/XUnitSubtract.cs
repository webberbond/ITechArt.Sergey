using XUnitCalculator.Calculator;

namespace XUnitCalculator.Tests;

public class XUnitSubtract 
{
    private readonly ICalculator _calculator;
    
    public XUnitSubtract(ICalculator calculator)
    {
        _calculator = calculator;
    }

    [Fact]
    public void SubtractValues()
    {
        //Arrange
        double expectedResult = 5.2;
        
        //Act
        double result = _calculator.Subtraction(6.7, 1.5);

        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(100, 31)]
    public void ParametrizedSumTest(double a, double b)
    {
        //Arrange
        double expectedResult = 69;
        
        //Act
        double result = _calculator.Subtraction(a, b);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
}