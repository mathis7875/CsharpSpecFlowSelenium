using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BHGVision.Pages
{
    public class BHGPrac : BHGBasePage
    {
        [FindsBy(How = How.XPath, Using = "//font[contains(.='Home.aspx')]")]
        private IWebElement homeStamp;

        public void isAt()
        {
            //DriverWait.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//font[contains(.='LeadPractitionerList.vc')]")));
            DriverWait.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("screentitle")));
            Assert.IsTrue(homeStamp.Text.Equals("LeadPractitionerList.vc"));
        }
        
        public BHGLogin ClickHomeLink()
        {
            Browser.Current.FindElement(By.LinkText("Home")).Click();
            return GetInstance<BHGLogin>();
        }
    }
}
