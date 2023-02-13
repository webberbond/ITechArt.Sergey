namespace Patterns.ValueObject;

public class SauceDemo
{
    private string _userName;
    private string _password;
    private string _errorText;

    public string GetUserName() {
        return _userName;
    }

    public void SetUserName(string userName) {
        this._userName = userName;
    }

    public string GetPassword() {
        return _password;
    }

    public void SetPassword(string password) {
        this._password = password;
    }

    public string GetErrorText() {
        return _errorText;
    }

    public void SetErrorText(string errorText) {
        this._errorText = errorText;
    }

}