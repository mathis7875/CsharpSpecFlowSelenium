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
    
    public class BHGContingentApprovalTwoSteps : BHGBaseSteps
    {

        //[Given(@"I  click created a new bhg application")]
        public void GivenIClickCreatedANewBhgApplication()
        {

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
        
        //[Given(@"I enter gaurantor information and business information")]
        public void GivenIEnterGaurantorInformationAndBusinessInformation()
        {
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsFirst("Business Development", "125000", "No", "No", "No", "No", "9545551212", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("0");
           // _CurrentPage.As<BHGApplicationPage>().intCoDateEstablished.SendKeys("05/05/2005");
            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("AARON");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("MCCOMB");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666582918", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("PO BOX 243", "TYGH VALLEY", "Oregon", "97063");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncome("Full Ownership Practice", "Full Ownership Practice", "Physician/Surgeon (MD)", "Florida","Yes");
            _CurrentPage.As<BHGApplicationPage>().UID.SendKeys("3817702");
            _CurrentPage.As<BHGApplicationPage>().LeadOwner.SelectItemByValueFromDDL("GMP");
            _CurrentPage.As<BHGApplicationPage>().guarantoCreditReleaseObtainedDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("125000");
            _CurrentPage.As<BHGApplicationPage>().CompletePersonalIncome("500000","50000","50000");
            //PFS Details complete
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsSecondScore("No", "No", "Yes", "No", "Yes", "No", "Texas", "No", "No", "No", "Yes", "Yes", "No", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSAssets("25000", "85000", "200000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiabilitiesAmounts("15000", "0.00", "0.00", "0.00", "100000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiablitiesPayments("900", "0.00", "0.00", "0.00", "750", "0.00", "0.00");

        }
        
       // [When(@"I  click score")]
        public void WhenIClickScore()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().VerifyFirstScoreText();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }
        //Verify application pass CA2 filter Happy path
       // [Then(@"the result should be CA(.*) approval afer second scoring")]
        public void ThenTheResultShouldBeCAApprovalAferSecondScoring(int p0)
        {
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentApprovalTwoText();
        }
    }
}
