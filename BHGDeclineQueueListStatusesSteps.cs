using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.BHGHelpers;
using BHG.Test.MasterFramework.Controls;
using System.Data.SqlClient;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;
using NUnit.Framework;


namespace BHGVision.Test
{
    //TEST IS BIENG WORK ON STILL<NOT COMPLETED, WORKING ON DTI AUTOMATION
   
    public class BHGDeclineQueueListStatusesSteps : BHGBaseSteps
    {

        public void Setup()
        {
            DatabaseHelper._visionDBConnect();

        }

        //Test to cover the Decline Queue status for TPF 
        //[Given(@"I have Completed Scoring and TPF Failed")]
        public void GivenIHaveCompletedScoringAndTPFFailed()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().PractitionerList.Click();
            _CurrentPage.As<BHGMenu>().QuickSearchReset.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Bill");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Aaalevelg");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click(); //---> Find element by text and click, add function 
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();    
        }
        
        //[Given(@"I have  Changed the TPF staus to Decline")]
        public void GivenIHaveChangedTheTPFStausToDecline()
        {
            
        }

       // [When(@"I Click Save I Go To The Decline Queue Page")]
        public void WhenIClickSaveIGoToTheDeclineQueuePage()
        {
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().DeclineedQueuelist.Click();
        }

       // [Then(@"the result should show the status for TPF WithDrawn in the Decline List and Decline Letter")]
        public void ThenTheResultShouldShowTheStatusForTPFWithDrawnInTheDeclineListAndDeclineLetter()
        {
            
        }

        //Test to cover the Decline Queue status for AMI 

        //[Given(@"I have Completed Scoring and AMI Failed")]
        public void GivenIHaveCompletedScoringAndAMIFailed()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().PractitionerList.Click();
            _CurrentPage.As<BHGMenu>().QuickSearchReset.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Bill");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Aaalevelg");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click(); //---> Find element by text and click, add function 
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }
        
       // [Given(@"I have  Changed the AMI staus to Decline")]
        public void GivenIHaveChangedTheAMIStausToDecline()
        {
            _CurrentPage.As<BHGApplicationPage>().appStatusDDL.SelectItemByValueFromDDL("APR");
            _CurrentPage.As<BHGApplicationPage>().saveButton.Click();
        }

        //[Then(@"the result should show the status for AMI Intial Decline in the Decline List and Decline Letter")]
        public void ThenTheResultShouldShowTheStatusForAMIIntialDeclineInTheDeclineListAndDeclineLetter()
        {
           
            //Add page switch 
            //Search for element to appear on page grid
            //Assert status on backend database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, 
                @"IF EXISTS(SELECT * FROM tApplication where applicationNum='204303 ' 
                                                                        and ApplicationStatus='3X')
                                                                                        BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END"));

            //Clear Decline Queue Applicant from list
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                                                                            @" DECLARE @ApplicationNum int = 204303  
                                                                                                UPDATE tApplication SET ApplicationStatus='E'WHERE ApplicationNum = @ApplicationNum");
        }

        //Test to cover the Decline Queue status for Core

       // [Given(@"I have Completed Scoring and Core Failed")]
        public void GivenIHaveCompletedScoringAndCoreFailed()
        {
         
        }
        
        //[Given(@"I have  Changed the Core staus to Decline")]
        public void GivenIHaveChangedTheCoreStausToDecline()
        {
            
        }

        //[Then(@"the result should show the status for Core Decline in the Decline List and Decline Letter")]
        public void ThenTheResultShouldShowTheStatusForCoreDeclineInTheDeclineListAndDeclineLetter()
        {
            
        }

        //Test to cover the Decline Queue status for New Logic

       // [Given(@"I have Completed Scoring and New Logic Failed")]
        public void GivenIHaveCompletedScoringAndNewLogicFailed()
        {
           
        }
        
        //[Given(@"I have  Changed the New Logic staus to Decline")]
        public void GivenIHaveChangedTheNewLogicStausToDecline()
        {
           
        }

       // [Then(@"the result should show the status for New Logic Decline in the Decline List and Decline Letter")]
        public void ThenTheResultShouldShowTheStatusForNewLogicDeclineInTheDeclineListAndDeclineLetter()
        {
            
        }


        //Test to cover the Decline Queue status for Initial Vision Application

       // [Given(@"I have Completed Scoring and Vision Application Failed for all filters")]
        public void GivenIHaveCompletedScoringAndVisionApplicationFailedForAllFilters()
        {
           
        }
        
        //[Given(@"I have  Changed the staus to Initail Decline")]
        public void GivenIHaveChangedTheStausToInitailDecline()
        {
          
        }
           
       // [Then(@"the result should show the status for Initial Decline in the Decline List and Decline Letter")]
        public void ThenTheResultShouldShowTheStatusForInitialDeclineInTheDeclineListAndDeclineLetter()
        {
            
        }
    }
}
