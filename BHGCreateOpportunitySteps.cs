using System;
using NUnit.Framework;
using System.Configuration;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using BHGVision.Pages;

namespace BHGVision.Test
{
   
    public class CreatOpportunitySteps : BHGBaseSteps
    {
        [Test]
        [Category("Vision Create Opporntunity")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        public void GivenIHaveLoggedIntoVisionAndSelectedAPractitionerFromThePractitionerList(String browserName)
        {
            Setup(browserName);
            IntiateVisionBrowser();
            _CurrentPage = GetInstance<BHGLogin>();      
            //Navigate to Practitioner list and look up applicant
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();   
            _CurrentPage.As<BHGMenu>().PractitionerList.Click();
            _CurrentPage.As<BHGMenu>().QuickSearchReset.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.Clear();
            _CurrentPage.As<BHGMenu>().QuickSearchValueFirstName.SendKeys("Kenneth");
            _CurrentPage.As<BHGMenu>().QuickSearchValueLastName.SendKeys("Osier");
            _CurrentPage.As<BHGMenu>().QuickSearchGo.Click();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            _CurrentPage = GetInstance<BHGLeadActivity>();
            //Start refactoring this logic
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().ClearPractitionerDetails();
            _CurrentPage.As<BHGLeadActivity>().FillInPractitionerDetails("Outbound", "mathistest@yahoo.com", "9545832223", "615 N 31st Road", "PMA City", "Florida");
            _CurrentPage.As<BHGLeadActivity>().ClickOkButton();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().GridList.Click();
            _CurrentPage = GetInstance<BHGLeadActivity>();
            //Add page wait for refresh
            DriverWait.WaitForPageLoaded(); 
            _CurrentPage.As<BHGLeadActivity>().CreateActivity.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectCampaignLookup("21*1");
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectDisposition("59");
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectActivityDirection("0");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = _CurrentPage.As<BHGLeadActivity>().ClickCreateOppButton();
            _CurrentPage.As<BHGLeadActivity>().CreateActivity.Click();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectCampaignLookup("21*1");
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectDisposition("59");
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadActivity>().SelectActivityDirection("0");
            DriverWait.WaitForPageLoaded();
            _CurrentPage = _CurrentPage.As<BHGLeadOpportunityPage>().ClickCreateAppButton();
            DriverWait.WaitForPageLoaded();
            _CurrentPage.As<BHGLeadOpportunityPage>().SelectSolePropDDL("0");
            _CurrentPage.As<BHGLeadOpportunityPage>().SelectConsumerAppDDL("0");
            _CurrentPage.As<BHGLeadOpportunityPage>().SelectInsuranceAppDDL("0");
            _CurrentPage.As<BHGApplicationPage>().IsAt();
        }
    }
}
