using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using System.Data.SqlClient;
using BHG.Test.MasterFramework.Controls;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;
using NUnit.Framework;


namespace BHGVision.Test
{
    public class BHGContingentApprovalTwoMaybeSteps : BHGBaseSteps
    {
        //[Given(@"I have click created a new bhg application")]
        public void GivenIHaveClickCreatedANewBhgApplication()
        {
            //Create BHG application
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().ViewApplicationsAll.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().NewBHGApplciationBtn.Click();

        }

        //[Given(@"I have enter gaurantor information and business information")]
        public void GivenIHaveEnterGaurantorInformationAndBusinessInformation()
        {    
            //Guarantor information with  ouststanding tax liens = yes and business tax liens =yes test scenario
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsFirst("Business Development", "25000", "No", "No", "No", "No", "9545551212", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("0");
 
            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncome("Full Ownership Practice", "Full Ownership Practice", "Physician/Surgeon (MD)", "Florida", "Yes");
            _CurrentPage.As<BHGApplicationPage>().guarantoCreditReleaseObtainedDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("125000");
            _CurrentPage.As<BHGApplicationPage>().CompletePersonalIncome("500000", "50000", "50000");

            //Second Score questions with Tax lien=yes
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsSecondScore("No", "Yes", "Yes", "No", "Yes", "No", "Texas", "No", "No", "No", "Yes", "Yes", "No", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSAssets("25000", "85000", "200000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiabilitiesAmounts("15000", "0.00", "0.00", "0.00", "100000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiablitiesPayments("900", "0.00", "0.00", "0.00", "750", "0.00", "0.00");
        }
        
       // [When(@"I press score")]
        public void WhenIPressScore()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().VerifyFirstScoreText();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }
        
       // [Then(@"the result should be CA two maybe review")]
        public void ThenTheResultShouldBeCATwoMaybeReview()
        {
            //Add a assertion to check for maybe review condition
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentApprovalTwoMaybe();
        }
    }
}
