using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.BHGHelpers;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;
using System.Configuration;
using NUnit.Framework;

namespace BHGVision.Test
{
    public class BHGContingentApprovalTwoPricingGroupsSteps : BHGBaseSteps
    {
        public void Setup()
        {
            DatabaseHelper._visionDBConnect();

        }

        //Go to Vision Created loan application
        //[Given(@"I have created loan application")]
        public void GivenIHaveCreatedLoanApplication()
        {
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().ViewApplicationsAll.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("222680");//This is for the application Number
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();

        }

        //[Given(@"I Complete the Gaurantor information with pricing group one fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupOneFico()
        {
            //Clear program filters
              clearFilters();

            //Set active credit app to 0
              noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0"
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }

       // [When(@"I click the score button")]
        public void WhenIClickTheScoreButton()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
        }

       // [Then(@"the result should be pricing group one")]
        public void ThenTheResultShouldBePricingGroupOne()
        {
            //Assert pricing group 1
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupOne();
        }

        //Test to cover the pricing group two 
       // [Given(@"I Complete the Gaurantor information with pricing group two fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupTwoFico()
        {
            //Clear program filters
            clearFilters();

            //Set active credit app to 0
            noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0" ///Change CBR request to match gaurantor on app
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }

       // [Then(@"the result should be pricing group two")]
        public void ThenTheResultShouldBePricingGroupTwo()
        {
            //Assert pricing group 2
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupTwo();
        }

        //Test to cover the pricing group three
       // [Given(@"I Complete the Gaurantor information with pricing group three fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupThreeFico()
        {
            //Clear program filters
            clearFilters();

            //Set active credit app to 0
            noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0" ///Change CBR request to match gaurantor on app
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }

        //[Then(@"the result should be pricing group three")]
        public void ThenTheResultShouldBePricingGroupThree()
        {
            //Assert pricing group 3
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupThree();
        }

        //Test to cover the pricing group four
       // [Given(@"I Complete the Gaurantor information with pricing group four fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupFourFico()
        {
            //Clear program filters
            clearFilters();

            //Set active credit app to 0
            noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0" ///Change CBR request to match gaurantor on app
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }

       // [Then(@"the result should be pricing group four")]
        public void ThenTheResultShouldBePricingGroupFour()
        {
            //Assert pricing group 4
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupFour();
        }

        //Test to cover the pricing group six
       // [Given(@"I Complete the Gaurantor information with pricing group six fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupSixFico()
        {
            //Clear program filters
            clearFilters();

            //Set active credit app to 0
            noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0" ///Change CBR request to match gaurantor on app
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }

        //[Then(@"the result should be pricing group six")]
        public void ThenTheResultShouldBePricingGroupSix()
        {
            //Assert pricing group 6
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupSix();
        }

        //Test to cover the pricing group seven
       // [Given(@"I Complete the Gaurantor information with pricing group seven fico")]
        public void GivenICompleteTheGaurantorInformationWithPricingGroupSevenFico()
        {
            //Clear program filters
            clearFilters();

            //Set active credit app to 0
            noActiveCBRGaurantor();

            //Set active gaurantor on credit app non  active
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"PDATE dbo.tGuarantorCBReport
                SET active = 1      
                WHERE ApplicationNum = '222680' and
                CBRRequestGUID = '1165192' and Active = 0" ///Change CBR request to match gaurantor on app
                );

            //Clear gaurantor details
            _CurrentPage = GetInstance<BHGApplicationPage>();
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorSSN.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorPostalCode.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorAddress1.Clear();
            _CurrentPage.As<BHGApplicationPage>().guarantorCity.Clear();

            //Guarantor Application details
            _CurrentPage.As<BHGApplicationPage>().guarantorFirstName.SendKeys("JAIME");
            _CurrentPage.As<BHGApplicationPage>().guarantorLastName.SendKeys("LLAMAS");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorPersonalInformation("President", "07/11/1980", "666189203", "Mtest@yahoo.com");
            _CurrentPage.As<BHGApplicationPage>().CompleteGuarantorAddress("364 BOONE AV", "WINCHESTER", "Kentucky", "40391");
        }
        
       // [Then(@"the result should be pricing group seven")]
        public void ThenTheResultShouldBePricingGroupSeven()
        {
            //Assert pricing group 7
            _CurrentPage.As<BHGApplicationPage>().VerifyContingentTwoPricingGroupSeven();
        }


        #region 
        public void clearFilters()
        {
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",   
          @" DECLARE @ApplicationNum int = 222680
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
        public void noActiveCBRGaurantor()
        {
            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-DC1-STGSQL;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
                @"UPDATE dbo.tGuarantorCBReport 
                  SET active =0
                  WHERE ApplicationNum='222680' and Active=1"
                );
        }
        #endregion
    }
}
