using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.BHGHelpers;
using BHG.Test.MasterFramework.Controls;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;
using NUnit.Framework;

namespace BHGVision.Test
{
    public class DTICoreApplicationSteps : BHGBaseSteps
    {
        public void Setup()
        {
            DatabaseHelper._visionDBConnect();
        }

        /*******************************************************************************************************************************************************************************
        //Call One(Strategy One) for Single Gaurantor first scoring with application in initial Entry Status
        *******************************************************************************************************************************************************************************/
        [Test]
        [Category("Vision Strategy One Call One")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        public void GivenIHaveCompletedAApplicationForSingleGaurantor(String browserName)
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
       // [Given(@"I have entered My PFS and have no Liabilities")]
            _CurrentPage = GetInstance<BHGApplicationPage>();
            //Update Application to intial Entry for first scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
            @" DECLARE @ApplicationNum int = 211553 
            UPDATE tApplication
            SET ApplicationStatus='E'
            WHERE ApplicationNum = @ApplicationNum");//Change application #
            //Clear PFS Assset Fields
            _CurrentPage.As<BHGApplicationPage>().ClearPersonalFinancialStatement();
            //Enter PFS values
            _CurrentPage.As<BHGApplicationPage>().finAssBankAcctsPFS.SendKeys("50000");
            _CurrentPage.As<BHGApplicationPage>().finAssInvestPFS.SendKeys("10000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREPrimaryPFS.SendKeys("90000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaCCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaTaxesPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaPersonalLoanPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaLOCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortPrimaryPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().salaryAnnualIncome.SendKeys("50000.00");
            _CurrentPage.As<BHGApplicationPage>().rentalAnnualIncome.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().otherAnnualIncome.SendKeys("5000.00");

            //Clear scoring filters 
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
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
        }//-TODO update scroing filters

        //[When(@"I click score")]
        public void WhenIClickScore()
        {
            //Click to score application after changes
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }

        //[Then(@"the result Should Generate a DTI single Gaurantor")]
        public void ThenTheResultShouldGenerateADTISingleGaurantor()
        {
            //Checking for DTI results on Dti Factor table for first score
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 0 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));

            //Clean up DTI factor table after scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;", @"Delete from dtifactor where ApplicationNumber='211553'");
        }

       /*****************************************************************************************************************************************************************************************
        //DTI for Single Gaurantor at first scoring with AlimonyChildAmt + ChildSupportAmt.Second scoring with AlimonyChildAmt + ChildSupportAmt added to the Debt
        ****************************************************************************************************************************************************************************************/
        //[Given(@"I have completed a application for Single Gaurantor with Liabilities")]
        public void GivenIHaveCompletedAApplicationForSingleGaurantorWithLiabilities()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }

       // [Given(@"I have entered My PFS and with Liabilities")]
        public void GivenIHaveEnteredMyPFSAndWithLiabilities()
        {
            _CurrentPage = GetInstance<BHGApplicationPage>();

            //Update Application to intial Entry for first scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
            @" DECLARE @ApplicationNum int = 211553 
            UPDATE tApplication
            SET ApplicationStatus='E'
            WHERE ApplicationNum = @ApplicationNum");//Change application #

            //Clear PFS Assset Fields
            _CurrentPage.As<BHGApplicationPage>().ClearPersonalFinancialStatement();
            //Enter PFS values
            _CurrentPage.As<BHGApplicationPage>().finAssBankAcctsPFS.SendKeys("50000");
            _CurrentPage.As<BHGApplicationPage>().finAssInvestPFS.SendKeys("10000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREPrimaryPFS.SendKeys("90000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaCCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaTaxesPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaPersonalLoanPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaLOCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortPrimaryPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().salaryAnnualIncome.SendKeys("50000.00");
            _CurrentPage.As<BHGApplicationPage>().rentalAnnualIncome.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().otherAnnualIncome.SendKeys("5000.00");
            //Add Alimony and ChildSupport Payment
            _CurrentPage.As<BHGApplicationPage>().eAlimonyChildSupDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildAmt.SendKeys("350.00");
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildType.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().ChildSupportAmt.SendKeys("150.00");
        }

       // [Then(@"the result Should Generate a DTI single Gaurantor with Liabilities")]
        public void ThenTheResultShouldGenerateADTISingleGaurantorWithLiabilities()
        {
            //Checking for DTI results on Dti Factor table after first scoring
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 1 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
            //Change AlimonyChildAmt + ChildSupportAmt and complete second scoring
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildAmt.Clear();
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildAmt.SendKeys("150.00");
            _CurrentPage.As<BHGApplicationPage>().ChildSupportAmt.Clear();
            _CurrentPage.As<BHGApplicationPage>().ChildSupportAmt.SendKeys("50.00");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Checking for DTI results on Dti Factor table after first scoring
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 1 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  ")); 
            //Clean up DTI factor table after scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;", @"Delete from dtifactor where ApplicationNumber='211553'");
        }

        /**************************************************************************************************************************************************************************************
        //DTI for Multiple Gaurantors with no liabilities added 
        **************************************************************************************************************************************************************************************/
       // [Given(@"I have completed a application for Mutliple Gaurantors with no Liabilities")]
        public void GivenIHaveCompletedAApplicationForMutlipleGaurantorsWithNoLiabilities()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }
        
       // [Given(@"I have entered My PFS and have no Liabilities for Mutliple Gaurantors")]
        public void GivenIHaveEnteredMyPFSAndHaveNoLiabilitiesForMutlipleGaurantors()
        {
            //Update Application to intial Entry for first scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
            @" DECLARE @ApplicationNum int = 211553 
            UPDATE tApplication
            SET ApplicationStatus='E'
            WHERE ApplicationNum = @ApplicationNum");//Change application #

            //Clear PFS Assset Fields
            _CurrentPage.As<BHGApplicationPage>().ClearPersonalFinancialStatement();
            //Enter PFS values
            _CurrentPage.As<BHGApplicationPage>().finAssBankAcctsPFS.SendKeys("50000");
            _CurrentPage.As<BHGApplicationPage>().finAssInvestPFS.SendKeys("10000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREPrimaryPFS.SendKeys("90000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaCCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaTaxesPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaPersonalLoanPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaLOCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortPrimaryPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().salaryAnnualIncome.SendKeys("50000.00");
            _CurrentPage.As<BHGApplicationPage>().rentalAnnualIncome.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().otherAnnualIncome.SendKeys("5000.00");
            //Add Gaurantors to application
            _CurrentPage.As<BHGApplicationPage>().AddGurantorButton.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorNameTwo("Test","data","gohere");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncomeTwo("1","1","8011-01","FL","1");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformationTwo("CEO","07/11/1980","9999999","mtest@yahoo.com");

            //Clear scoring filters 
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
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

       // [Then(@"the result Should Generate a DTI for Multiple Gaurantors")]
        public void ThenTheResultShouldGenerateADTIForMultipleGaurantors()
        {
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            //Check Dti factor table for gurantor one after first scoring 
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 1 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
            //Check Dti factor table for gurantor two after first scoring 
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 2 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
            //Clean up DTI factor table after scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;", @"Delete from dtifactor where ApplicationNumber='211553'");
            //Delete second gurantor
        }

        /****************************************************************************************************************************************************************************************
        //DTI for Multiple Gaurantors with AlimonyChildAmt + ChildSupportAmt
        ****************************************************************************************************************************************************************************************/
        //[Given(@"I have completed a application for Mutliple Gaurantors with with Liabilities")]
        public void GivenIHaveCompletedAApplicationForMutlipleGaurantorsWithWithLiabilities()
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
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Juliet");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Abijay");//Change Name
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            WebControlsExtension.SwitchWindowToApplicationPage("#AppV3BHG > table:nth-child(5) > tbody > tr > td > font");
            DriverWait.WaitForPageLoaded();
        }
        
        //[Given(@"I have entered My PFS and have Liabilities for Mutliple Gaurantors")]
        public void GivenIHaveEnteredMyPFSAndHaveLiabilitiesForMutlipleGaurantors()
        {
            //Clear PFS Assset Fields
            _CurrentPage.As<BHGApplicationPage>().ClearPersonalFinancialStatement();
            //Enter PFS values
            _CurrentPage.As<BHGApplicationPage>().finAssBankAcctsPFS.SendKeys("50000");
            _CurrentPage.As<BHGApplicationPage>().finAssInvestPFS.SendKeys("10000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREPrimaryPFS.SendKeys("90000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssREOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finAssOthersPFS.SendKeys("1000000.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaCCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaTaxesPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaPersonalLoanPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaLOCPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortPrimaryPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaMortOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().finLiaOtherPFS.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().salaryAnnualIncome.SendKeys("50000.00");
            _CurrentPage.As<BHGApplicationPage>().rentalAnnualIncome.SendKeys("0.00");
            _CurrentPage.As<BHGApplicationPage>().otherAnnualIncome.SendKeys("5000.00");
            //Add Alimony and ChildSupport Payment to first gurantor
            _CurrentPage.As<BHGApplicationPage>().eAlimonyChildSupDDL.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildAmt.SendKeys("350.00");
            _CurrentPage.As<BHGApplicationPage>().AlimonyChildType.SelectItemByValueFromDDL("1");
            _CurrentPage.As<BHGApplicationPage>().ChildSupportAmt.SendKeys("150.00");
            //Add Gaurantors to application
            _CurrentPage.As<BHGApplicationPage>().AddGurantorButton.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorNameTwo("Test", "data", "gohere");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorMedicalAndIncomeTwo("1", "1", "8011-01", "FL", "1");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformationTwo("CEO", "07/11/1980", "9999999", "mtest@yahoo.com");
        }

        //[Then(@"the result Should Generate a DTI for Multiple Gaurantors with Liabilities")]
        public void ThenTheResultShouldGenerateADTIForMultipleGaurantorsWithLiabilities()
        {
            var conn = DatabaseHelper.ConnectionManager.GetSqlConnection();
            //Check Dti factor table for gurantor one after first scoring 
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 1 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
            //Check Dti factor table for gurantor two after first scoring 
            Assert.IsTrue(DatabaseHelper.AssertDatabaseResults(conn, @"IF EXISTS (SELECT * FROM dtifactor WHERE ApplicationNumber = 211553 and GuarantorNumber = 2 and Dti = 0.01)
            BEGIN  PRINT 'Pass' END ELSE BEGIN PRINT'FAIL'END  "));
            //Clean up DTI factor table after scoring
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;", @"Delete from dtifactor where ApplicationNumber='211553'");
            //Delete second gurantor
        }
    }
}
