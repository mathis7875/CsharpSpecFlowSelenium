using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BHGVision.Pages
{
   public  class BHGDeclineQueueListPage : BHGBasePage
    {

        public BHGDeclineQueueListPage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }


        #region quick search menu
        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3DecQueueList']/table[2]/tbody/tr/td/font/select[1]")]
        public IWebElement QuickSearchField;

       
        [FindsBy(How = How.ClassName , Using = "QuickSearchOperator")]
        public IWebElement QuickSearchOperator;

        [FindsBy(How = How.XPath , Using = "//*[@id='AppV3DecQueueList']/table[2]/tbody/tr/td/font/input[1]")]
        public IWebElement QuickSearchValue;

        [FindsBy(How = How.ClassName, Using = "QuickSearchAndOr")]
        public IWebElement QuickSearchAndOr;

        [FindsBy(How = How.ClassName, Using = "QuickSearchField2")]
        public IWebElement QuickSearchField2;

        [FindsBy(How = How.ClassName, Using = "QuickSearchOperator2")]
        public IWebElement QuickSearchOperator2;

        [FindsBy(How = How.ClassName, Using = "QuickSearchValue2")]
        public IWebElement QuickSearchValue2;

        [FindsBy(How = How.ClassName, Using = "btnQuickSearchGo")]
        public IWebElement btnQuickSearchGo;

        [FindsBy(How = How.ClassName, Using = "btnQuickSearchReset")]
        public IWebElement btnQuickSearchReset;

        #endregion



    }
}
