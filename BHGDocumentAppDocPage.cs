using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BHG.Test.MasterFramework.BHGBaseObjects;


namespace BHGVision.Pages
{
    public  class BHGDocumentAppDocPage : BHGBasePage
    {
        public BHGDocumentAppDocPage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

        #region Menu

        [FindsBy(How = How.XPath, Using = "//*[@id='AppDocPackDetail']/table[3]/tbody/tr/td/input[4]")]
        public IWebElement cancelButton;

        #endregion
    }
}
