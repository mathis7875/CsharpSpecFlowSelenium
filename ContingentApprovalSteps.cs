using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using System.Data.SqlClient;
using System.IO;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;

namespace BHGVision
{

    public class ContingentApprovalSteps : BHGBaseSteps
    {
        //[Given(@"I have created an application for a practitioner")]
        public void GivenIHaveCreatedAnApplicationForAPractitioner()
        {
            //ScenarioContext.Current.Pending();
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            Browser.Current.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            //_CurrentPage = GetInstance<BHGLogin>();
            //_CurrentPage.As<BHGLogin>().ClickAutoLogin();
            Browser.Current.Navigate().GoToUrl("http://rgomez:Gomer206@192.168.0.42/app/AppV3BHG.vc?vcqs=TransientKey~%60119574%60~ApplicationNum~%60211432%60~c~%60-1097023819");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGLogin>();
           // _CurrentPage = _CurrentPage.As<BHGLogin>().ClickAutoLogin();    
        }
        
        
        //[Given(@"I have entered the second set of required questions")]
        public void GivenIHaveEnteredTheSecondSetOfRequiredQuestions()
        {
            
        }

       // [Given(@"I have entered the required data for a first scoring")]
        public void GivenIHaveEnteredTheRequiredDataForAFirstScoring()
        {

            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorName("Hoy","G","Barber");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("3535 Michigan","Dallas","Texas","33315");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("Owner","05/05/1982","894344475","hoygbarber@test.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncome("Salaried", "No Secondary Source of Income", "Physician/Surgeon (MD)", "Texas", "Yes");
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsFirst("Business Development", "25000", "No","No", "Yes","No","9545551212","05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePersonalIncome("250000","0.00","0.00");
            _CurrentPage.As<BHGApplicationPage>().ClickAutoFillButton();
            _CurrentPage.As<BHGApplicationPage>().WaitForPageUpdate();
        }


       // [Given(@"I have entered the second set of required questions for a passing Contingent Approval")]
        public void GivenIHaveEnteredTheSecondSetOfRequiredQuestionsForAPassingContingentApproval()
        {
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsSecondScore("No", "No","Yes","No", "Yes","No","Texas", "No", "No","No","Yes","Yes","No", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSAssets("25000","85000","200000","0.00","0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiabilitiesAmounts("15000","0.00","0.00","0.00","100000","0.00","0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiablitiesPayments("900","0.00","0.00","0.00","750","0.00","0.00");
        }

       // [Given(@"I have done a first scoring")]
        public void GivenIHaveDoneAFirstScoring()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            _CurrentPage.As<BHGApplicationPage>().VerifyFirstScoreText();
        }

        //[When(@"I press Score")]
        public void WhenIPressScore()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
        }
        
       // [Then(@"the message for appoved Contingent Approval should be on the screen")]
        public void ThenTheMessageForAppovedContingentApprovalShouldBeOnTheScreen()
        {
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentApprovalText();
        }

        //[Given(@"I have added a user in the database")]
        public void GivenIHaveAddedAUserInTheDatabase()
        {
            string script = File.ReadAllText("creatingrecords.sql");
            string connectionString = "Data Source=bhg-colo-sq05;Initial Catalog=Vision;Integrated Security=True";
            SqlConnection ApplicationCon = new SqlConnection(connectionString);
            ServerConnection svrConnection = new ServerConnection(ApplicationCon);
            Server server = new Server(svrConnection);
            server.ConnectionContext.ExecuteNonQuery(script);
        }


        //[Given(@"I click on the practitioner list")]
        public void GivenIClickOnThePractitionerList()
        {
            _CurrentPage = GetInstance<BHGLogin>();
           _CurrentPage =  _CurrentPage.As<BHGLogin>().ClickPractitionerLink();
        }

       // [When(@"I click on the homepage link in the navbar")]
        public void WhenIClickOnTheHomepageLinkInTheNavbar()
        {
            _CurrentPage.As<BHGPrac>().isAt();
            _CurrentPage = _CurrentPage.As<BHGPrac>().ClickHomeLink();
        }

       // [Then(@"I am on the homepage")]
        public void ThenIAmOnTheHomepage()
        {
            _CurrentPage.As<BHGLogin>().isAt();
        }

    }
}
