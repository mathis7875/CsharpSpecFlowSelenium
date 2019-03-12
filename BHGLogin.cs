using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using NUnit.Framework;

namespace BHGVision.Pages
{
    public class BHGLogin : BHGBasePage
    {
        [FindsBy(How = How.XPath, Using = "//font[contains(.='Home.aspx')]")]
        private IWebElement homeStamp;

        /// <summary>
        /// Instantiates an instance and initializes the page elements for BHGLogin Page
        /// </summary>
        public BHGLogin()
        {
            PageFactory.InitElements(DriverContext.Driver,this);
        }

        /// <summary>
        /// Logins into Vision with a username and password
        /// </summary>
        #region Login fields

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement Username;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password;

        [FindsBy(How = How.Name, Using = "Go")]
        public IWebElement EnterButton;

        #endregion
        public void LoginPageBHG()
        {
            Username.SendKeys("myoung");
            Password.SendKeys("Algebra2");
            EnterButton.Click();

        }

        /// <summary>
        /// Clicks the autologin page
        /// </summary>
        /// <returns>BHGApplication Page</returns>
        public BHGBasePage ClickAutoLogin()
        {
            IWebElement element = DriverContext.Driver.FindElement(By.LinkText("Auto Login"));
            element.Click();
           return GetInstance<BHGApplicationPage>();
        }

        /// <summary>
        /// Asserts that the page is on the home page.
        /// </summary>
        public void isAt()
        {
           
            DriverWait.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//font[.='Home.aspx']")));
            Assert.IsTrue(homeStamp.Text.Equals("Home.aspx"));
        }

        /// <summary>
        /// CLicks the Practitioner link on the page and returns an instance of a Practitioner page
        /// </summary>
        /// <returns>BHGPractitioner Page</returns>
        public BHGPrac ClickPractitionerLink()
        {
            Browser.Current.FindElement(By.LinkText("Practitioner List")).Click();
            //return new BHGPrac();
            return GetInstance<BHGPrac>();
        }
    }
}
