namespace WebDriverBasics.Exceptions;

public class NoAlertPresentException : Exception
{
    public NoAlertPresentException()
    {
    }

    public NoAlertPresentException(string message) : base(message)
    {
    }
}