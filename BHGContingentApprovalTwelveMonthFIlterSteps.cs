using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Controls;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;

namespace BHGVision.Test
{
  
    public class BHGContingentApprovalTwelveMonthFIlterSteps : BHGBaseSteps
    {
        //[Given(@"I have been core declined in the last twelve months")]
        public void GivenIHaveBeenCoreDeclinedInTheLastTwelveMonths()
        {   
            //Core Decline Application
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().ViewApplicationsAll.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("216885");//This is for the application Number the Core declined status
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridListGuarantor.Click();
           // WebControlsExtension.
           
           // DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGLeadActivity>();
            _CurrentPage.As<BHGLeadActivity>().CreateActivity.Click();
            _CurrentPage.As<BHGLeadActivity>().CampaignLookup.SelectItemByValueFromDDL("19*1");
            _CurrentPage.As<BHGLeadActivity>().Disposition.SelectItemByValueFromDDL("59");
            _CurrentPage.As<BHGLeadActivity>().CreateOpporntunityButton.Click();
        }

       // [Given(@"I have completed a new application")]
        public void GivenIHaveCompletedANewApplication()
        {
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("ComplateApplciation");//Datadriven test data being pass 
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorName("Hoy", "G", "Barber");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("3535 Michigan", "Dallas", "Texas", "33315");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("Owner", "05/05/1982", "894344475", "hoygbarber@test.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncome("Salaried", "No Secondary Source of Income", "Physician/Surgeon (MD)", "Texas", "Yes");
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsFirst("Business Development", "25000", "No", "No", "Yes", "No", "9545551212", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePersonalIncome("250000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsSecondScore("No", "No", "Yes", "No", "Yes", "No", "Texas", "No", "No", "No", "Yes", "Yes", "No", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSAssets("25000", "85000", "200000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiabilitiesAmounts("15000", "0.00", "0.00", "0.00", "100000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiablitiesPayments("900", "0.00", "0.00", "0.00", "750", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().WaitForPageUpdate();
        }
    
       // [When(@"I click score the button")]
        public void WhenIClickScoreTheButton()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
         }

        //[Then(@"the result should be a  ca two maybe staus for core declined applciation in last twelve months")]
        public void ThenTheResultShouldBeACaTwoMaybeStausForCoreDeclinedApplciationInLastTwelveMonths()
        {
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentApprovalTwoMaybe();
        }

        //[Given(@"I have been intitial declined in the last twelve months")]
        public void GivenIHaveBeenIntitialDeclinedInTheLastTwelveMonths()
        {
            //Initial Decline application
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().ViewApplicationsAll.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("216885");//This is for the application Number the Core declined status
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridListGuarantor.Click();
            _CurrentPage = GetInstance<BHGLeadActivity>();
            _CurrentPage.As<BHGLeadActivity>().CreateActivity.Click();
            _CurrentPage.As<BHGLeadActivity>().CampaignLookup.SelectItemByValueFromDDL("19*1");
            _CurrentPage.As<BHGLeadActivity>().Disposition.SelectItemByValueFromDDL("59");
            _CurrentPage.As<BHGLeadActivity>().CreateOpporntunityButton.Click();
        }
            
       // [Then(@"the result should be a  ca two maybe staus for intial declined applciation in last twelve months")]
        public void ThenTheResultShouldBeACaTwoMaybeStausForIntialDeclinedApplciationInLastTwelveMonths()
        {
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentApprovalTwoMaybe();
        }
    }
}
