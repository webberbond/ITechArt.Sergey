using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace Patterns.Tests;

[AllureNUnit]
public class LoginTest : BaseTest
{
    [Test]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Login Tests")]
    public void SuccesfullLogin()
    {
        LoginSteps
            .Login(Username, Password)
            .ValidateIsProductsPageOpened();
    }

    [Test]
    public void ErrorLogin()
    {
        LoginSteps
            .Login("", Password)
            .ValidateErrorMessage("Epic sadface: Username is required");
    }
}