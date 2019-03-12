using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BHG.Test.MasterFramework.Controls;

namespace BHGVision.Pages
{
    public class BHGLeadOpportunityPage : BHGBasePage
    {
        [FindsBy(How = How.XPath, Using = "//font[contains(.='LeadOpportunity.vc)]")]
        public IWebElement screenTitleStamp;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F0_SoleProp')]")]
        public IWebElement solePropDDL;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F0_ConApp')]")]
        public IWebElement consumerAppDDL;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F0_InsuranceApp')]")]
        public IWebElement insuranceAppDDL;

        [FindsBy(How = How.Name, Using = "btnCreateApp")]
        public IWebElement createAppBtn;


        public BHGLeadOpportunityPage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

        /// <summary>
        /// Asserts that the page is the Lead Opportunity page.
        /// </summary>
        public void IsAt()
        {
            DriverWait.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("screentitle")));
            Assert.IsTrue(screenTitleStamp.Text.Equals("LeadOpportunity.vc"));
        }

        /// <summary>
        /// Clicks the Create App button
        /// </summary>
        public BHGApplicationPage ClickCreateAppButton()
        {
            createAppBtn.Click();
            return GetInstance<BHGApplicationPage>();

        }

        /// <summary>
        /// Selects Yes or No from the Will a spin up sole-proprietorship be used for funding? list
        /// </summary>
        /// <param name="value">Value for answer. "0" for No, "1" for Yes</param>
        public void SelectSolePropDDL(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(solePropDDL, value);
        }

        /// <summary>
        /// Selects Yes or No from the Is this a Consumer Application? list
        /// </summary>
        /// <param name="value">Value for answer. "0" for No, "1" for Yes</param>
        public void SelectConsumerAppDDL(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(consumerAppDDL, value);
        }

        /// <summary>
        /// Selects Yes or No from the Is this an Insurance Application? list
        /// </summary>
        /// <param name="value">Value for answer. "0" for No, "1" for Yes</param>
        public void SelectInsuranceAppDDL(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(insuranceAppDDL, value);
        }
    }
}
