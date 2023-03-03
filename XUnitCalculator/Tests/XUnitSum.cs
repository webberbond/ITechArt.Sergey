using XUnitCalculator.Calculator;

namespace XUnitCalculator.Tests;

[Collection("Calculator Collection Tests")]
public class XUnitSum
{
    private readonly CalculatorFixture _calculatorFixture;

    public XUnitSum(CalculatorFixture calculatorFixture)
    {
        _calculatorFixture = calculatorFixture;
    }

    [Fact]
    public void SumPositiveValues()
    {
        //Arrange
        var calculator = _calculatorFixture.Calculator;

        //Act
        var result = calculator.Sum(2, 1);

        //Assert
        Assert.Equal(3, result);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(2, 3, 5)]
    [InlineData(5, 6, 11)]
    public void ParametrizedSumTest(double a, double b, double expectedResult)
    {
        //Arrange
        var calculator = _calculatorFixture.Calculator;

        //Act
        var result = calculator.Sum(a, b);

        //Assert
        Assert.Equal(expectedResult, result);
    }
}