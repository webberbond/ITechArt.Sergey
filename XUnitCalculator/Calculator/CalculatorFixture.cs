namespace XUnitCalculator.Calculator;

public class CalculatorFixture : IDisposable
{
    public ICalculator Calculator;

    public CalculatorFixture(ICalculator calculator)
    {
        Calculator = calculator;
    }

    public void Dispose()
    {
        Calculator = null;
    }
}