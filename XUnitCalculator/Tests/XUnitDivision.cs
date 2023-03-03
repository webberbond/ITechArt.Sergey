using XUnitCalculator.Calculator;

namespace XUnitCalculator.Tests;

public class XUnitDivision : IClassFixture<CalculatorFixture>
{
    private readonly CalculatorFixture _calculatorFixture;

    public XUnitDivision(CalculatorFixture calculatorFixture)
    {
        _calculatorFixture = calculatorFixture;
    }
    
    [Fact]
    public void DivideValues()
    {
        //Arrange
        var calculator = _calculatorFixture.Calculator;
        double expectedResult = 2;
        
        //Act
        double result = calculator.Division(4, 2);

        //Assert
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(100, 5)]
    public void ParametrizedDivisionTest(double a, double b)
    {
        //Arrange
        var calculator = _calculatorFixture.Calculator;
        double expectedResult = 20;
        
        //Act
        double result = calculator.Division(a, b);
        
        //Assert
        Assert.Equal(expectedResult, result);
    }
}