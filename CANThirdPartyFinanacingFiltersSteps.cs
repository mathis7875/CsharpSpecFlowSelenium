using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.BHGHelpers;
using BHG.Test.MasterFramework.Controls;
using System.Data.SqlClient;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;
using NUnit.Framework;

namespace BHGVision.Steps
{
 
    public class CANThirdPartyFinanacingFiltersSteps : BHGBaseSteps
    {
       
        public void Setup()
        {
            DatabaseHelper._visionDBConnect();

        }

        // Case 1 TPF BizFi Pass, Source of income is Full Ownership Practice, FICO >=550, Gross sales >120k and
        //business accepts credit Cards

       // [Given(@"I have completed a application with Full Ownership Practice")]
        public void GivenIHaveCompletedAApplicationWithFullOwnershipPractice()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("CECIL");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("MOUTRAY");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            //Rename extension method to SwitchWebWindowPage
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }
        
       // [Given(@"I have added a company and filled out grantor information")]
        public void GivenIHaveAddedACompanyAndFilledOutGrantorInformation()
        {
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorBirthdate.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "8666794657", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("7550 CENTER RIDGE RD ", "WILBURN", "ARIZONA", "72179");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.Clear();
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("125000");
            _CurrentPage.As<BHGApplicationPage>().guarantorPrimIncSource.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().guarantorSecIncSource.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("1");

            //Clears program filters
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",

            @" DECLARE @ApplicationNum int = 211553 
                          UPDATE sub8900.tApplication8900
                              SET ScreenResultCore = NULL,
                                      PaystubQualified = NULL,
                                              ScreenResultAF = NULL,
                                                  ScreenResultAMI = NULL,
                                                      ScreenResultNewLogic = NULL,
                                                                      SBAQualified = NULL,
                                                      ScreenResultWeekly = NULL,
                                          ScreenResultTPFMessage = NULL,
                                                      DTIfromCBR = NULL,
                                       ScreenResultCreditCard = NULL,
                                              ScreenResultNote = NULL
                          WHERE ApplicationNum = @ApplicationNum
              UPDATE sub8900.tGuarantor8900
                  SET ScreenResultCreditCard = NULL,
              DTIPlain = NULL
              WHERE ApplicationNum = @ApplicationNum");

            DriverWait.WaitForPageLoaded();   
        }

        //[When(@"I click score button to score the vision application")]
        public void WhenIClickScoreButtonToScoreTheVisionApplication()
        {
            //Click scoring
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }

       // [Then(@"the result should be Pass on AMI and New Logic and TPF")]
        public void ThenTheResultShouldBePassOnAMIAndNewLogicAndTPF()
        {
            //Checks the Program Filter results in Database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();

            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT  * FROM sub8900.tApplication8900 WHERE ApplicationNum =221977 and ScreenResultCore =0 and  isnull( PaystubQualified ,0) = 0 and ScreenResultAF= 0 and 
            ScreenResultAMI =0 and ScreenResultNewLogic =0 and isnull(SBAQualified ,0)=0 and ScreenResultWeekly =0 and ScreenResultTPFMessage ='BIZFI - Pass' and ScreenResultCreditCard =0)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END "));
        }

        //Case 2 AMI/New logic with Source of income Outside Employment Contracted with business bank statement =Yes and
       // Fico >=550 from GuarantorNum 1, sales >120k and Business accepts credit cards

       // [Given(@"I have completed a application Outside Employment Contracted")]
        public void GivenIHaveCompletedAApplicationOutsideEmploymentContracted()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("NICOLE");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("BUSHMAN");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }

        //[Given(@"I have addded a company and filled out grantor information")]
        public void GivenIHaveAdddedACompanyAndFilledOutGrantorInformation()
        {
            _CurrentPage = GetInstance<BHGApplicationPage>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().guarantorPrimIncSource.SelectItemByValueFromDDL("2");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoBankStatementsDDL.SelectItemByValueFromDDL("1");
    
            //Clears program filters
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
             @" DECLARE @ApplicationNum int = 211553 
                          UPDATE sub8900.tApplication8900
                              SET ScreenResultCore = NULL,
                                      PaystubQualified = NULL,
                                              ScreenResultAF = NULL,
                                                  ScreenResultAMI = NULL,
                                                      ScreenResultNewLogic = NULL,
                                                                      SBAQualified = NULL,
                                                      ScreenResultWeekly = NULL,
                                          ScreenResultTPFMessage = NULL,
                                                      DTIfromCBR = NULL,
                                          ScreenResultCreditCard = NULL,
                                              ScreenResultNote = NULL
                          WHERE ApplicationNum = @ApplicationNum
              UPDATE sub8900.tGuarantor8900
                  SET ScreenResultCreditCard = NULL,
              DTIPlain = NULL
              WHERE ApplicationNum = @ApplicationNum");   
        }

       // [Then(@"the result should be Pass for AMI and New Logic and TPF")]
        public void ThenTheResultShouldBePassForAMIAndNewLogicAndTPF()
        {
            //Checks the Program Filter results in Database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();

            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT  * FROM sub8900.tApplication8900 WHERE ApplicationNum =221979 and ScreenResultCore =0 and  isnull( PaystubQualified ,0) = 0 and ScreenResultAF= 0 and 
            ScreenResultAMI =1 and ScreenResultNewLogic =1 and isnull(SBAQualified ,0)=0 and ScreenResultWeekly =0 and ScreenResultTPFMessage ='BIZFI - Pass' and ScreenResultCreditCard =0)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END "));
        }

        // Case 3 New logic with source of income Partial ownerhsip in pratice,Fico >=550 for grantor, sales less than
        //a 120k, business does not accept credit cards

        //[Given(@"I have completed a application with Partial ownerhsip")]
        public void GivenIHaveCompletedAApplicationWithPartialOwnerhsip()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
             WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
             DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGApplicationPage>();
             DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().guarantorPrimIncSource.SelectItemByValueFromDDL("3");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().intCoBankStatementsDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.Clear();
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("99000");

            //Clear program filters
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
            @" DECLARE @ApplicationNum int = 211553 
                          UPDATE sub8900.tApplication8900
                              SET ScreenResultCore = NULL,
                                      PaystubQualified = NULL,
                                              ScreenResultAF = NULL,
                                                  ScreenResultAMI = NULL,
                                                      ScreenResultNewLogic = NULL,
                                                                      SBAQualified = NULL,
                                                      ScreenResultWeekly = NULL,
                                          ScreenResultTPFMessage = NULL,
                                                      DTIfromCBR = NULL,
                                          ScreenResultCreditCard = NULL,
                                              ScreenResultNote = NULL
                          WHERE ApplicationNum = @ApplicationNum
              UPDATE sub8900.tGuarantor8900
                  SET ScreenResultCreditCard = NULL,
              DTIPlain = NULL
              WHERE ApplicationNum = @ApplicationNum");
        }

        //[Then(@"the result should be Pass for New logic and TPF and fail for AMI")]
        public void ThenTheResultShouldBePassForNewLogicAndTPFAndFailForAMI()
        {
            //Checks the Program Filter results in Database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();

            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT  * FROM sub8900.tApplication8900 WHERE ApplicationNum =211553 and ScreenResultCore =1 and  isnull( PaystubQualified ,0) = 0 and ScreenResultAF= 0 and 
            ScreenResultAMI =0 and ScreenResultNewLogic =0 and isnull(SBAQualified ,0)=0 and ScreenResultWeekly =0 and ScreenResultTPFMessage ='BIZFI - Fail' and ScreenResultCreditCard =1)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
        }

        //Case 4  All filters fail AMI,New logic and TPF. Source of income salaried fico>=550 for grantor, sales <120k and
        // No to credit cards and no to business statements
        //[Given(@"I have completed a application income salaried")]
        public void GivenIHaveCompletedAApplicationIncomeSalaried()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGApplicationPage>();
            DriverWait.WaitForPageLoaded();
        
            //Clear program filters
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @" DECLARE @ApplicationNum int = 211553 
                          UPDATE sub8900.tApplication8900
                              SET ScreenResultCore = NULL,
                                      PaystubQualified = NULL,
                                              ScreenResultAF = NULL,
                                                  ScreenResultAMI = NULL,
                                                      ScreenResultNewLogic = NULL,
                                                                      SBAQualified = NULL,
                                                      ScreenResultWeekly = NULL,
                                          ScreenResultTPFMessage = NULL,
                                                      DTIfromCBR = NULL,
                                          ScreenResultCreditCard = NULL,
                                              ScreenResultNote = NULL
                          WHERE ApplicationNum = @ApplicationNum
              UPDATE sub8900.tGuarantor8900
                  SET ScreenResultCreditCard = NULL,
              DTIPlain = NULL
              WHERE ApplicationNum = @ApplicationNum");
        }
        
       // [Given(@"I have added a compnay and filled out grantor primary source of income as salaried")]
        public void GivenIHaveAddedACompnayAndFilledOutGrantorPrimarySourceOfIncomeAsSalaried()
        {
            _CurrentPage.As<BHGApplicationPage>().guarantorPrimIncSource.SelectItemByValueFromDDL("4");
            _CurrentPage.As<BHGApplicationPage>().guarantorSecIncSource.SelectItemByValueFromDDL("4");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().intCoBankStatementsDDL.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.Clear();
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("99000");

        }

       // [Then(@"the result should be fail for AMI and New logic and TPF")]
        public void ThenTheResultShouldBeFailForAMIAndNewLogicAndTPF()
        {
            //Checks the Program Filter results in Database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();

            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT  * FROM sub8900.tApplication8900 WHERE ApplicationNum =211553 and ScreenResultCore =1 and  isnull( PaystubQualified ,0) = 0 and ScreenResultAF= 0 and 
            ScreenResultAMI =0 and ScreenResultNewLogic =0 and isnull(SBAQualified ,0)=0 and ScreenResultWeekly =0 and ScreenResultTPFMessage ='BIZFI - Fail' and ScreenResultCreditCard =1)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
        }

        //Case 5 Adding mutliple companies, source of primary income is ownerhsip and secondary source is outside employement with bankstatments
        //fico <=550, and 1st company sales 10k and 2nd company sales 150k and, 2nd comnpany accepts credit cards
       // [Given(@"I have completed a application multiple companies")]
        public void GivenIHaveCompletedAApplicationMultipleCompanies()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = GetInstance<BHGApplicationPage>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().guarantorPrimIncSource.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().intCoAcceptCCDDL.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().intCoBankStatementsDDL.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.Clear();
            _CurrentPage.As<BHGApplicationPage>().intCoPriorSales.SendKeys("10000");

            //Clear program filters
          var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
              @" DECLARE @ApplicationNum int = 211553 
                          UPDATE sub8900.tApplication8900
                              SET ScreenResultCore = NULL,
                                      PaystubQualified = NULL,
                                              ScreenResultAF = NULL,
                                                  ScreenResultAMI = NULL,
                                                      ScreenResultNewLogic = NULL,
                                                                      SBAQualified = NULL,
                                                      ScreenResultWeekly = NULL,
                                          ScreenResultTPFMessage = NULL,
                                                      DTIfromCBR = NULL,
                                          ScreenResultCreditCard = NULL,
                                              ScreenResultNote = NULL
                          WHERE ApplicationNum = @ApplicationNum
              UPDATE sub8900.tGuarantor8900
                  SET ScreenResultCreditCard = NULL,
              DTIPlain = NULL
              WHERE ApplicationNum = @ApplicationNum");
        }
        
        //[Given(@"I have added multiple companies and completed grantor details")]
        public void GivenIHaveAddedMultipleCompaniesAndCompletedGrantorDetails()
        {
            _CurrentPage.As<BHGApplicationPage>().addRelatedCompany.Click();
            DriverWait.WaitForPageLoaded();
            //Clear company 2 fields
            _CurrentPage.As<BHGApplicationPage>().secondCompanyFullLegalName.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCoPhoneNumber.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCoDateEstablished.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCoAddress.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCoZipCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCompanyFullLegalName.Clear();
            _CurrentPage.As<BHGApplicationPage>().secondCoIntGrossSales.Clear();
            //Complete company 2 details
            _CurrentPage.As<BHGApplicationPage>().secondCompanyFullLegalName.SendKeys("Mathis Test Compnay");
            _CurrentPage.As<BHGApplicationPage>().secondCoAddress.SendKeys("615 N 31st ave");
            _CurrentPage.As<BHGApplicationPage>().secondCoCity.SendKeys("Fort Lauderdale");
            _CurrentPage.As<BHGApplicationPage>().secondCoState.SelectItemByValueFromDDL("FL");
            _CurrentPage.As<BHGApplicationPage>().secondCoPhoneNumber.SendKeys("9545582626");
            _CurrentPage.As<BHGApplicationPage>().secondCoZipCode.SendKeys("33311");
            _CurrentPage.As<BHGApplicationPage>().secondCoDateEstablished.SendKeys("12/12/2015");
            _CurrentPage.As<BHGApplicationPage>().secondCoBankruptcy10years.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().secondCoOutstandingTaxIrs.SelectItemByValueFromDDL("0");
            _CurrentPage.As<BHGApplicationPage>().secondCoTaxPriorYearFiled.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().secondCoIntAcceptCC.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().secondCoIntGrossSales.SendKeys("160000");
            _CurrentPage.As<BHGApplicationPage>().saveButton.Click();
             DriverWait.WaitForPageLoaded();
        }
        
       // [When(@"I click save and click the score button to score the application")] 
        public void WhenIClickSaveAndClickTheScoreButtonToScoreTheApplication()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }

        //[Then(@"the result should pass for AMI and New logic")]
        public void ThenTheResultShouldPassForAMIAndNewLogic()
        {
            //Checks the Program Filter results in Database
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();

            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT  * FROM sub8900.tApplication8900 WHERE ApplicationNum =211553 and ScreenResultCore =1 and  isnull( PaystubQualified ,0) = 0 and ScreenResultAF= 0 and 
            ScreenResultAMI =1 and ScreenResultNewLogic =1 and isnull(SBAQualified ,0)=0 and ScreenResultWeekly =0 and ScreenResultTPFMessage ='BIZFI - Pass' and ScreenResultCreditCard =1)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));

            _CurrentPage.As<BHGApplicationPage>().deleteSecondCompanyInfo.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().saveButton.Click();
    }
    }
}

