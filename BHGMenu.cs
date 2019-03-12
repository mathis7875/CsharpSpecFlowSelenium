using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using BHG.Test.MasterFramework.Controls;

namespace BHGVision.Pages
{
    public class BHGMenu : BHGBasePage
    {
        /// <summary>
        /// Instantiates an instance and initiates BHGMenu page objects
        /// </summary>
        public BHGMenu()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

        #region Horizontal menu

        [FindsBy(How = How.Name, Using = "btnSave")]
        public IWebElement SaveButton;

        [FindsBy(How = How.Name, Using = "btnCance")]
        public IWebElement CancelButton;

        [FindsBy(How = How.Name, Using = "btnDocumnets")]
        public IWebElement DocumentsButton;

        [FindsBy(How = How.Name, Using = "btnPayoffRepor")]
        public IWebElement PayoffReportButton;

        [FindsBy(How = How.Name, Using = "btnSubmit")]
        public IWebElement ScoreButton;

        [FindsBy(How = How.Name, Using = "btnBureauReports")]
        public IWebElement CreditButton;

        [FindsBy(How = How.Name, Using = "btnFundingTask")]
        public IWebElement TaskButton;

        [FindsBy(How = How.Name, Using = "btnStatusHistor")]
        public IWebElement HistoryButton;

        #endregion

        #region CRM Menu

        [FindsBy(How = How.LinkText, Using = "/app/LeadActivityList.vc?vcqs=My%7e%600%60%7eToday%7e%600%60%7eComplete%7e%602%60%7eListName%7e%60CompleteToday%60%7ec%7e%60-1726346593")]
        public IWebElement TodayCompleted;

        [FindsBy(How = How.LinkText, Using = "/app/LeadActivityList.vc?vcqs=My%7e%601%60%7eToday%7e%600%60%7eComplete%7e%600%60%7eListName%7e%60My%60%7ec%7e%601131141500")]
        public IWebElement MyActivities;

        [FindsBy(How = How.LinkText, Using = "/app/LeadActivityList.vc?vcqs=My%7e%600%60%7eToday%7e%600%60%7eComplete%7e%600%60%7eListName%7e%60All%60%7ec%7e%601388071372")]
        public IWebElement AllActivities;

        [FindsBy(How = How.LinkText, Using = "/app/LeadActivityList.vc?vcqs=My%7e%600%60%7eToday%7e%600%60%7eComplete%7e%601%60%7eListName%7e%60Complete%60%7ec%7e%60-59265698")]
        public IWebElement CompleteActivities;

        [FindsBy(How = How.LinkText, Using = "/app/LeadTransactionList.vc?vcqs=c%7e%60410010988")]
        public IWebElement TransactionList;

        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr[8]/td/a/font")]
        public IWebElement PractitionerList;

        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr[28]/td/a/font")]
        public IWebElement DeclineedQueuelist;

        #endregion

        #region Application Menu

        [FindsBy(How = How.LinkText, Using = "/app/LeadOpportunityList.vc?vcqs=My%7e%600%60%7eListName%7e%60All%60%7ec%7e%60-958417249")]
        public IWebElement OpporntunityList;

        [FindsBy(How = How.LinkText, Using = "/app/LeadOpportunityList.vc?vcqs=My%7e%601%60%7eListName%7e%60My%60%7ec%7e%60255071493")]
        public IWebElement MyOpporntunities;

        /*[FindsBy(How = How.LinkText, Using = "/app/AppV3List.vc?vcqs=ActiveApps%7e%600%60%7eMy%7e%600%60%7ec%7e%601993312228")]
        public IWebElement ViewApplicationsAll;*/

        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td[1]/table/tbody/tr[21]/td/a/font")]
         public IWebElement ViewApplicationsAll;
   
       
        [FindsBy(How = How.LinkText, Using = "/app/AppV3List.vc?vcqs=ActiveApps%7e%601%60%7eMy%7e%600%60%7ec%7e%60637659715")]
        public IWebElement HActiveApplications;

        [FindsBy(How = How.LinkText, Using = "/app/AppV3List.vc?vcqs=ActiveApps%7e%601%60%7eMy%7e%601%60%7ec%7e%601898665748")]
        public IWebElement Myapplications;

        [FindsBy(How = How.LinkText, Using = "/app/AppV3GuarantorList.vc?vcqs=c%7e%607054141")]
        public IWebElement DoctorSearch;

        [FindsBy(How = How.XPath, Using = " //*[@id='AppV3List']/table[1]/tbody/tr/td/input")]
        public IWebElement NewBHGApplciationBtn;



      

        #endregion

        #region Quick Search Menu
        [FindsBy(How = How.Name, Using = "QuickSearchField")]
        public IWebElement QuickSearchField;

        [FindsBy(How = How.Name, Using = "QuickSearchOperator")]
        public IWebElement QuickSearchOperator;

        [FindsBy(How = How.Name, Using = "QuickSearchValue")]
        public IWebElement QuickSearchValueFirstName;

        [FindsBy(How = How.Name, Using = "QuickSearchValue2")]
        public IWebElement QuickSearchValueLastName;

        [FindsBy(How = How.Name, Using = "QuickSearchAndOr")]
        public IWebElement QuickSearchAndOr;

        [FindsBy(How = How.Name, Using = "btnQuickSearchGo")]
        public IWebElement QuickSearchGo;

        [FindsBy(How = How.Name, Using = "btnQuickSearchReset")]
        public IWebElement QuickSearchReset;

        [FindsBy(How = How.CssSelector, Using = "#LeadPractitionerList > table:nth-child(6) > tbody > tr.listrow1 > td:nth-child(2) > font > a")]
        public IWebElement GridList;

        [FindsBy(How = How.CssSelector, Using = "#AppV3List > table:nth-child(5) > tbody > tr.listrow1 > td:nth-child(7) > font > a:nth-child(1)")]
        public IWebElement GridListGuarantor;

        [FindsBy(How = How.CssSelector, Using = "#LeadPractitioner > table:nth-child(23) > tbody > tr.listrow1 > td:nth-child(3) > font > a")]
        public IWebElement GridListOpprtunitiesApplicationLink;

        [FindsBy(How = How.CssSelector, Using = "# AppV3List > table:nth-child(2) > tbody > tr > td > input")]
        public IWebElement NewBHGApplicationButton;

        #endregion

        public void goToApplciation()
        {
            _CurrentPage.As<BHGMenu>().PractitionerList.Click();
            _CurrentPage.As<BHGMenu>().QuickSearchReset.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }
    }
}
