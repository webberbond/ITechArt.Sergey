using Image = SeleniumWrapper.Elements.Image;

namespace SeleniumWrapperTests.Pages;

public class OrderPage : BasePage
{
    public OrderPage(BaseElement uniqueElement, string pageName) : base(uniqueElement, pageName)
    {
    }

    public OrderPage(Browser browser) : base(browser)
    {
    }

    protected override string UrlPath => string.Empty;

    protected override By UniqueWebLocator => By.XPath("//h1[contains(text(),'Оформить заказ')]");

    private readonly TextField _nameField = new(By.XPath("//input[@id='msordersform-first_name']"), "NameField");

    private readonly TextField _surnameField =
        new(By.XPath("//input[@id='msordersform-last_name']"), "SurnameField");

    private readonly TextField _phoneNumber = new(By.XPath("//input[@id='msordersform-phone_m']"), "PhoneNumber");

    private readonly TextField _address = new(By.XPath("//input[@id='msordersform-address']"), "Address");

    private readonly TextField _captchaInput =
        new(By.XPath("//input[@id='msordersform-captchacode']"), "CaptchaInput");

    private readonly Label _successOrder = new(By.XPath("//div[@class='contentAlert']"), "SuccessOrder");

    private readonly Button _nextStepAfterClientInfo = new(By.XPath("//button[@name='button']"), "NextStep");

    private readonly Button _nextStepAfterOrderInfo =
        new(By.XPath("//button[@class='btn btn-default pull-right check-delivery template_btn']"), "NextStep");

    private readonly Button _cashType = new(By.XPath("//label[@for='payment_info_0']"), "CashType");

    private readonly Button _deliveryType =
        new(By.XPath("//div[@id='msordersform-delivery_type']"), "DeliveryType");

    private readonly Button _agreeCheckbox = new(By.XPath("//input[@id='msordersform-offer']"), "AgreeCheckbox");

    private readonly Button _checkoutButton = new(By.XPath("//button[@name='checkout-button']"), "CheckoutButton");

    private readonly Image _captcha = new(By.XPath("//*[@id=\"msordersform-captchacode-image\"]"), "Captcha");

    public void ClientInfoEnter()
    {
        _nameField.SendText("Arslan");
        _surnameField.SendText("Munasipov");
        _phoneNumber.SendText("325554748");
    }

    public void NextStepAfterClientInfoEnter()
    {
        _nextStepAfterClientInfo.Click();
    }

    public void NextStepAfterDeliveryInfoEnter()
    {
        _nextStepAfterOrderInfo.Click();
    }

    public void DeliveryInfoEnter()
    {
        _address.SendText("Yunusabad District");
        _deliveryType.Click();
    }

    [Obsolete("Obsolete")]
    public void CashInfoEnter()
    {
        _cashType.Click();

        Thread.Sleep(2000);
        var imageSource = _captcha.GetSrc();
        var folderPath = "C:/Users/HomeUser/Desktop/captcha";
        if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);


        using (var client = new WebClient())
        {
            client.DownloadFile(imageSource, Path.Combine(folderPath, "Captcha.png"));
        }

        Installation.LicenseKey =
            "IRONOCR.ZAROCHENTSEVSERGEY.25402-5CF0D85B7D-BL6PFBHTSMOOMXCE-NSKQCAINH3W6-CEJPIVGIJI7U-USU57PVBU3VI-PQWWR7WCY57M-WYOTQO-T5ULZ6PJVG6JEA-DEPLOYMENT.TRIAL-OEEAWV.TRIAL.EXPIRES.11.MAR.2023";
        var result = new IronTesseract().Read(folderPath + "/Captcha.png").Text;

        _captchaInput.SendText(result);
    }

    public void FinishOrder()
    {
        _agreeCheckbox.Click();
        _checkoutButton.Click();
    }

    public bool IsSuccessDisplayed => _successOrder.IsDisplayed();
}