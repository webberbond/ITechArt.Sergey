using Microsoft.Extensions.Logging;

namespace XUnitCalculator.Calculator;

public class Calculator : ICalculator
{
    private readonly ILogger _logger;

    public Calculator(ILogger<Calculator> logger)
    {
        _logger = logger;
    }
    
    public double Sum(double a, double b)
    {
        _logger.LogInformation($"First number: {a}. Second number: {b}");
        _logger.LogInformation("Sum of two numbers");
        var result =  a + b;
        _logger.LogInformation($"Result: {result}");
        
        return result;
    }
    
    public double Subtraction(double a, double b)
    {
        _logger.LogInformation($"First number: {a}. Second number: {b}");
        _logger.LogInformation("Subtraction of two numbers");
        var result =  a - b;
        _logger.LogInformation($"Result: {result}");
        
        return result;
    }
   
    public double Multiplication(double a, double b)
    {
        _logger.LogInformation($"First number: {a}. Second number: {b}");
        _logger.LogInformation("Multiplication of two numbers");
        var result =  a * b;
        _logger.LogInformation($"Result: {result}");
        
        return result;
    }

    public double Division(double a, double b)
    {
        //_logger.LogInformation($"First number: {a}. Second number: {b}");
        //_logger.LogInformation("Division of two numbers");
        var result =  a / b;
        //_logger.LogInformation($"Result: {result}");
        
        return result;
    }
}