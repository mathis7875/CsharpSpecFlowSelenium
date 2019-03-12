using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using BHG.Test.MasterFramework.Controls;

namespace BHGVision.Pages
{
    public class BHGLeadActivity : BHGBasePage
    {
        /// <summary>
        /// Instantiates an instance and initiates an the BHGLeadActivity page elements
        /// </summary>
        public BHGLeadActivity()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

        #region Activity Details

        [FindsBy(How = How.Name, Using = "btnCreateActivity")]
        public IWebElement CreateActivity;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(3) > tbody > tr:nth-child(5) > td.dnrequire > font > textarea")]
        public IWebElement MarketingPitch;

        //[FindsBy(How = How.XPath, Using = "//*[@id='LeadActivity']/table[2]/tbody/tr[6]/td[2]/font/select")]
        //public IWebElement CampaignLookup;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F0_CampaignLookup')]")]
        public IWebElement CampaignLookup;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(2) > td:nth-child(2) > font > select")]
        public IWebElement Responsible;

        //[FindsBy(How = How.CssSelector, Using = "//*[@id='LeadActivity']/table[2]/tbody/tr[6]/td[2]/font/select")]
        //public IWebElement DirectionInboundOutBound;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F0_NewActivityDirection')]")]
        public IWebElement DirectionInboundOutBound;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(5) > td:nth-child(2) > font > input")]
        public IWebElement ActivityPhone;

        //[FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(6) > td:nth-child(2) > font > select")]
        //public IWebElement Disposition;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F3_DispositionCode')]")]
        public IWebElement Disposition;


        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(7) > td.dnrequire > font > select")]
        public IWebElement Unqualified;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(8) > td.dnrequire > font > select")]
        public IWebElement UnqualifiedReasons;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(9) > td.dnrequire > font > textarea")]
        public IWebElement NoteField;



        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(2) > td:nth-child(4) > font > select")]
        public IWebElement ReferralAgent;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(5) > td:nth-child(4) > font > select")]
        public IWebElement ChangeChannel;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(11) > tbody > tr:nth-child(6) > td:nth-child(4) > font > select")]
        public IWebElement ContactPerson;

        //[FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(12) > tbody > tr > td > input:nth-child(1)")]
        //public IWebElement OkButton;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'btnOK')]")]
        public IWebElement okBtn;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(12) > tbody > tr > td > input:nth-child(2)")]
        public IWebElement Savebutton;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(12) > tbody > tr > td > input:nth-child(3)")]
        public IWebElement CancelButton;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(13) > tbody > tr > td > input:nth-child(4)")]
        public IWebElement CreateOpporntunityButton;

        #endregion

        #region Practitioner Details

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(5) > td:nth-child(2) > font > select")]
        public IWebElement PrimarySpeciality;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(6) > td:nth-child(2) > font > select")]
        public IWebElement Gender;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(7) > td.dnrequire > font > select")]
        public IWebElement MedicalTitle;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(8) > td:nth-child(2) > font > select")]
        public IWebElement LicenseState;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(9) > td:nth-child(2) > font > input")]
        public IWebElement LicenseExpiration;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(10) > td.dnrequire > font > input")]
        public IWebElement MedicalSchool;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(11) > td:nth-child(2) > font > input")]
        public IWebElement GraduationDate;

        [FindsBy(How = How.XPath, Using = "//*[@id='LeadPractitioner']/table[12]/tbody/tr[13]/td[2]/font/input")]
        public IWebElement PersonalEmail;

        [FindsBy(How = How.XPath, Using = "//*[@id='LeadPractitioner']/table[12]/tbody/tr[15]/td[2]/font/input")]
        public IWebElement PeferredPhone;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(16) > td:nth-child(2) > font > input")]
        public IWebElement HomePhone;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(19) > td:nth-child(2) > font > input")]
        public IWebElement AssisantName;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(20) > td:nth-child(2) > font > input")]
        public IWebElement AssisantPhone;

        [FindsBy(How = How.XPath, Using = "//*[@id='LeadPractitioner']/table[12]/tbody/tr[22]/td[2]/font/input")]
        public IWebElement HomeAddress;

        //[FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(23) > td.dnrequire > font > input")]
        //public IWebElement CityField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F5_HomeCity')]")]
        public IWebElement CityField;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(24) > td:nth-child(2) > font > select")]
        public IWebElement StateField;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(25) > td.dnrequire > font > select")]
        public IWebElement Elucidate;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(6) > td:nth-child(4) > font > input")]
        public IWebElement DateOfBirthfield;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(8) > td:nth-child(4) > font > input")]
        public IWebElement LicenseNumber;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(9) > td:nth-child(4) > font > input")]
        public IWebElement NPIfield;

        [FindsBy(How = How.CssSelector, Using = "#LeadActivity > table:nth-child(61) > tbody > tr:nth-child(24) > td:nth-child(4) > font > input")]
        public IWebElement ZipcodeField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'HomeState')]")]
        public IWebElement homeState;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F3_Direction')]")]
        public IWebElement activityDirectionInboundOutbound;

        #endregion


        public void ClearPractitionerDetails()
        {
            _CurrentPage.As<BHGLeadActivity>().PersonalEmail.Clear();
            _CurrentPage.As<BHGLeadActivity>().PeferredPhone.Clear();
            _CurrentPage.As<BHGLeadActivity>().HomeAddress.Clear();
            _CurrentPage.As<BHGLeadActivity>().CityField.Clear();
        }

        public void CreatePractitionerDetails()
        {
            _CurrentPage.As<BHGLeadActivity>().PersonalEmail.Clear();
            _CurrentPage.As<BHGLeadActivity>().PeferredPhone.Clear();
            _CurrentPage.As<BHGLeadActivity>().HomeAddress.Clear();
            _CurrentPage.As<BHGLeadActivity>().CityField.Clear();
        }

        public void FillInPractitionerDetails(string direction, string email, string phone, string homeAdd, string city, string state)
        {
            WebControlsExtension.SelectItemByTextFromDDL(DirectionInboundOutBound, direction);
            PersonalEmail.SendKeys(email);
            PeferredPhone.SendKeys(phone);
            HomeAddress.SendKeys(homeAdd);
            CityField.SendKeys(city);
            WebControlsExtension.SelectItemByTextFromDDL(homeState, state);
        }

        public void ClickOkButton()
        {
            okBtn.Click();
        }

        public BHGLeadOpportunityPage ClickCreateOppButton()
        {
            CreateOpporntunityButton.Click();
            return GetInstance<BHGLeadOpportunityPage>();
        }

        public void SelectCampaignLookup(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(CampaignLookup,value);
        }

        public void SelectDisposition(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(Disposition, value);
        }

        public void SelectDirection(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(DirectionInboundOutBound, value);
        }

        public void SelectActivityDirection(string value)
        {
            WebControlsExtension.SelectItemByValueFromDDL(activityDirectionInboundOutbound, value);
        }

    }
}
