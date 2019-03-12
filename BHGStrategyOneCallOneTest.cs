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
   public  class BHGStrategyOneCallOneTest : BHGBaseSteps
    {

        public void Setup()
        {
            DatabaseHelper._visionDBQA4Connect();
        }

        [Test]
        [Category("StrategyOne Call One Business 550<")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 550<
        **************************************************************************************************/
        public void GivenIScoreBusinessAppThenCallOneExecutes(String browserName)//pass chrome only
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CallOneBusiness550<");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //ENTER CODE hahahahha
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One IHP 550<")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 550<
        **************************************************************************************************/
        public void GivenIScoreIHPAppThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CallOneIHP550<");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One Business 650<")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 650<
        **************************************************************************************************/

        public void GivenIScoreBusinessApp650ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CallOneBusiness650<");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }
        [Test]
        [Category("StrategyOne Call One IHP 650<")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 650<
        **************************************************************************************************/
        public void GivenIScoreIHPApp650ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CallOneIHP650<");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One Business 550>")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 550>
        **************************************************************************************************/
        public void GivenIScoreBusinessApp550ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneBusiness550>");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One IHP 550>")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 550>
        **************************************************************************************************/
        public void GivenIScoreIHPApp550ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneIHP550>");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One Business 650>")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 650>
        **************************************************************************************************/
        public void GivenIScoreBusinessApp650UpperThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneBusiness650>");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One IHP 650>")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 650>
        **************************************************************************************************/
        public void GivenIScoreIHPApp650UpperThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneIHP650>");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One Busines 700")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 700>
        **************************************************************************************************/
        public void GivenIScoreBusinessApp700ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneBusiness700");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }

        [Test]
        [Category("StrategyOne Call One IHP 700")]
        [TestCaseSource(typeof(BHGBaseSteps), "BrowserToRunWith")]
        /**************************************************************************************************
        //This test is for Call 1 , with Fico 700>
        **************************************************************************************************/
        public void GivenIScoreIHPApp700ThenCallOneExecutes(String browserName)
        {
            Setup("chrome");
            Browser.Current.Navigate().GoToUrl(ConfigurationManager.AppSettings["seleniumBaseUrl"]);//todo
            Browser.Current.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));//todo
            _CurrentPage = GetInstance<BHGLogin>();
            _CurrentPage.As<BHGLogin>().ClickAutoLogin();
            _CurrentPage = GetInstance<BHGMenu>();
            _CurrentPage.As<BHGMenu>().goToApplciation();
            _CurrentPage.As<BHGApplicationPage>().ClearTextGuarantorFields();
            _CurrentPage.As<BHGApplicationPage>().CompleteApplicationEntry("CalloneIHP700");
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            DriverWait.WaitForPageLoaded();
            //Assert filter results 
            //use after intial score to put app back to intial entry, change db connection,use for test cleanup to reset app
            _CurrentPage.As<BHGApplicationPage>().resetVisionApplicationToInitialEntry();
        }
    }
}
