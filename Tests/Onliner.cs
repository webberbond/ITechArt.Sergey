namespace WebDriverBasics.Tests;

public class Onliner : BaseTest
{

    [Test]
    public void OpenSiteClickTab_MobilePhones()
    {
        //Opening HomePage
        HomePage.OpenPage();
        Assert.That(HomePage.IsPageOpened, Is.True, "HomePage should be opened");

        //Opening MobilePhonesTab
        HomePage.ClickTab_MobilePhones();
        Assert.That(MobilePhonesPage.IsPageOpened, "HomePage should be opened");
    }

    [Test]
    public void MobilePhonesTab_Check()
    {
        //Open HomePage and then open MobilePhonesTab
        OpenSiteClickTab_MobilePhones();
        
        //Selecting checkboxes for Apple and Honor
        MobilePhonesPage.SelectChekboxes();
        
        //Deleting Honor
        MobilePhonesPage.DeleteHonor();
        Assert.That(MobilePhonesPage.IsHonorTagVisible, "Honor is not selected");
        
        //Select first and third products
        MobilePhonesPage.AddFirstAndThirdProducts();
        Assert.That(MobilePhonesPage.AreItemsAdded, Is.True, "Products are successfully added");
        
        //Open ComparePage
        MobilePhonesPage.CompareButtonClick();
        Assert.That(ComparePage.IsPageOpened, "ComparePage should be opened" );
    }

    [Test]
    public void ComparePage_Check()
    {
        //Open site and then navigate to ComparePage
        MobilePhonesTab_Check();
        
        //Opening DescriptionTable
        ComparePage.GetDescriptionTable();
        Assert.Multiple(() =>
        {

            //Checking if class attribute contains class "product-table-tip__trigger_visible"
            Assert.That(ComparePage.IsDescriptionOpened, "Description table is successfully opened");

            //Checking if text in description equals to our string value
            Assert.That(ComparePage.IsDescriptionRight, "Text equals to our string value");
        });

        //Navigating to previous page
        ComparePage.GetPreviousPage();
        Assert.That(MobilePhonesPage.IsPageOpened, "Previous page is successfully opened");
    }
}