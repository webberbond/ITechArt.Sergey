using NUnit.Allure.Core;

namespace WebDriverBasics.Tests;

[AllureNUnit]
public class Onliner : BaseTest
{
    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Open Site Test")]
    [AllureSubSuite("Positive")]
    [Obsolete("Obsolete")]
    public void OpenSiteClickTab_MobilePhones()
    {
        HomePage.OpenPage();

        AllureLifecycle.Instance.WrapInStep(() => { Assert.True(HomePage.IsPageOpened, "HomePage should be opened"); },
            "Validate Is HomePage Opened");

        HomePage.ClickTab_MobilePhones();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.True(MobilePhonesPage.IsPageOpened, "MobilePhonesPage should be opened"); },
            "Validate Is MobilePhonesPage Opened");
    }

    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Checking MobilePhonesTab")]
    [AllureSubSuite("Positive")]
    [Obsolete("Obsolete")]
    public void MobilePhonesTab_Check()
    {
        OpenSiteClickTab_MobilePhones();

        MobilePhonesPage.SelectChekboxes();

        MobilePhonesPage.DeleteHonor();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(MobilePhonesPage.IsHonorTagVisible, "Honor is not selected"); },
            "Validate Is Honor Not Selected");

        MobilePhonesPage.AddFirstAndThirdProducts();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(MobilePhonesPage.AreItemsAdded, Is.True, "Products are successfully added"); },
            "Validate Are Products Added");

        MobilePhonesPage.CompareButtonClick();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(ComparePage.IsPageOpened, "ComparePage should be opened"); },
            "Validate Is ComparePage Opened");
    }

    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Checking ComparePage")]
    [AllureSubSuite("Positive")]
    [Obsolete("Obsolete")]
    public void ComparePage_Check()
    {
        MobilePhonesTab_Check();

        ComparePage.GetDescriptionTable();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(ComparePage.IsDescriptionOpened, "Description table is successfully opened"); },
            "Validate Is Description Table Opened");

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(ComparePage.IsDescriptionRight, "Text equals to our string value"); },
            "Validate Text In Description Table");

        ComparePage.GetPreviousPage();

        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.That(MobilePhonesPage.IsPageOpened, "Previous page is successfully opened"); },
            "Validate Is Previous Page Opened");
    }

    [Test]
    [AllureTag("Regression")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Sergey Zarochentsev")]
    [AllureSuite("Checking ComparePage")]
    [AllureSubSuite("Positive")]
    [Obsolete("Obsolete")]
    public void OpenSite_ClickLogin()
    {
        HomePage.OpenPage();

        AllureLifecycle.Instance.WrapInStep(() => { Assert.True(HomePage.IsPageOpened, "HomePage should be opened"); },
            "Validate Is HomePage Opened");

        HomePage.ClickButton_Auth();
        AllureLifecycle.Instance.WrapInStep(() => { Assert.True(AuthPage.IsPageOpened, "AuthPage should be opened"); },
            "Validate Is AuthPage Opened");

        AuthPage.InputNicknameAndPassword();
        AuthPage.CaptchaPass();
        AllureLifecycle.Instance.WrapInStep(
            () => { Assert.True(AuthPage.IsAuthenticationPass(), "Authentication Passed"); },
            "Validate Is Authentication Passed");
    }
}