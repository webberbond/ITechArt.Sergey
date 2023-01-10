namespace TDD.CalculatorTesting;
public class Calculator
{
    public static double Sum(double a, double b)
    {
        return a + b;
    }
    
    public void Sum()
    {
        Result = FirstNumber + SecondNumber;
    }
    public static double Subtraction(double a, double b)
    {
        return a - b;
    }
    public void Subtract()
    {
        Result = FirstNumber - SecondNumber;
    }
    public static double Multiplication(double a, double b)
    {
        return a * b;
    }
    public void Multiplication()
    {
        Result = FirstNumber * SecondNumber;
    }
    public static double Division(double a, double b)
    {
        return a / b;
    }
    public void Division()
    {
        Result = FirstNumber / SecondNumber;
    }
    public int Result { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
}