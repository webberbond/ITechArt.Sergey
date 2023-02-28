namespace Patterns.Components;

public class LoginPageComponents
{
    public readonly TextField Login = new(By.XPath("//input[@id='user-name']"), "Login Input");

    public readonly TextField Password = new(By.XPath("//input[@id='password']"), "Password Input");

    public readonly Button LoginButton = new(By.XPath("//input[@id='login-button']"), "Login Button");

    public readonly Label ErrorContainer =
        new(By.XPath("//div[@class='error-message-container error']"), "Error Label");
}