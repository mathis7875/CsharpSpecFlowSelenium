using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using Baseclass.Contrib.SpecFlow.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using BHGMasterFrameWork.BHGBaseObjects;
using BHGMasterFrameWork.Controls;

namespace BHGVision.Pages.VisionApplication
{
   public class BHGLeadOpportunity : BHGBasePage
    {

        public BHGLeadOpportunity()
        {
            PageFactory.InitElements(Browser.Current, this);
        }

        #region Opporntunity Details

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(8) > td.dnrequire > font > select")]
        public IWebElement FronterAgent;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(9) > td.dnrequire > font > select")]
        public IWebElement InitialSalesAgent;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(10) > td.dnrequire > font > select")]
        public IWebElement ReassignSalesAgent;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(11) > td.dnrequire > font > select")]
        public IWebElement SSSAgent;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(12) > td.dnrequire > font > select")]
        public IWebElement ResponsibleField;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(13) > td:nth-child(2) > font:nth-child(1) > select")]
        public IWebElement CreateFollowup;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(14) > td.dnrequire > font > select")]
        public IWebElement SolePropriertorshipField;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(15) > td.dnrequire > font > select")]
        public IWebElement ConsumerApplicationField;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(4) > tbody > tr:nth-child(16) > td.dnrequire > font > select")]
        public IWebElement InsuranceApplicationField;

        [FindsBy(How = How.CssSelector, Using = "#LeadOpportunity > table:nth-child(5) > tbody > tr > td > input:nth-child(4)")]
        public IWebElement CreateApplicationButton;

        #endregion

    }
}
