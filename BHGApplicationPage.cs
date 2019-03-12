using System;
using BHG.Test.MasterFramework.BHGBaseObjects;
using BHG.Test.MasterFramework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using BHG.Test.MasterFramework.Controls;
using BHGVision.TestData;
using BHG.Test.MasterFramework.BHGHelpers;

namespace BHGVision.Pages
{
    public class BHGApplicationPage : BHGBasePage
    {

        /// <summary>
        /// Instantiates an instance and initiates an the BHGApplication page elements
        /// </summary>
        public BHGApplicationPage() 
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }

        #region
  
        /*[FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td[2]/table[1]/tbody/tr/td[4]/font/text()")]
        public IWebElement appPageStamp;*/

        [FindsBy(How = How.XPath, Using = "*[@id='AppV3BHG']/table[4]/tbody/tr[2]/td[2]/font)]")]
        public IWebElement appNum { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F1_Status')]")]
        public IWebElement appStatusDDL { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'Request1Use')]")]
        public IWebElement useOfFundsDDL { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'Request1Amt')]")]
        public IWebElement requestAmt { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_UID')]")]
        public IWebElement UID { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_LeadOwner')]")]
        public IWebElement LeadOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'EarlyWithdrawal3Years')]")]
        public IWebElement earlyWithdrawal3YearsDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'AlimonyChildSup')]")]
        public IWebElement eAlimonyChildSupDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_AlimonyChildAmt')]")]
        public IWebElement AlimonyChildAmt { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_AlimonyChildType')]")]
        public IWebElement AlimonyChildType { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_ChildSupportAmt')]")]
        public IWebElement ChildSupportAmt { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'IntOtherBusinesses')]")]
        public IWebElement IntOtherBusinessesDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'SalaryAnnualIncome')]")]
        public IWebElement salaryAnnualIncome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'RentalAnnualIncome')]")]
        public IWebElement rentalAnnualIncome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'OtherAnnualIncome')]")]
        public IWebElement otherAnnualIncome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'btnSubmit')]")]
        public IWebElement btnSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG'/table[21]/tbody/tr/td/input[1]")]
        public IWebElement AddGurantorButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'btnAutoFill')]")]
        public IWebElement btnAutoFill { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F9_IntBankStatements')]")]
        public IWebElement intCoBankStatementsDDL{ get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'IntAcceptCC')]")]
        public IWebElement intCoAcceptCCDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'DateEstablished')]")]
        public IWebElement intCoDateEstablished { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'CoPhone')]")]
        public IWebElement intCoPhone { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F9_IntBankruptcy')]")]
        public IWebElement intCoBankruptcyDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F9_IntTaxLiens')]")]
        public IWebElement intCoTaxLiensDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F9_TaxPriorYearFiled')]")]
        public IWebElement intCoTaxPriorYearFiledDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_IntBankruptcy')]")]
        public IWebElement intBankruptcyDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_IntBankruptcyIntent')]")]
        public IWebElement intBankruptcyIntentDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_IntTaxLiens')]")]
        public IWebElement intTaxLiensDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_TaxPriorYearFiled')]")]
        public IWebElement intTaxPriorYearFiledDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_TaxReturnAddress')]")]
        public IWebElement intTaxReturnAddressDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_Haveyoueverbeenconvicted')]")]
        public IWebElement intDisciplinaryActionDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_EarlyWithdrawal3Years')]")]
        public IWebElement intEarlyWithdrawalDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_CurLicenseState')]")]
        public IWebElement intCurrLicenseStateDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F9_IntGrossSales')]")]
        public IWebElement intCoPriorSales { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[16]/tbody/tr/td/input[1]")]
        public IWebElement saveButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_TaxPriorYearFiled')]")]
        //public IWebElement taxPriorYearFiledDDL;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_PartnerWillCosign')]")]
        public IWebElement intPartnerWillCosignDDL;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssBankAccts')]")]
        public IWebElement finAssBankCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssPractice')]")]
        public IWebElement finAssPracticeCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssEquip')]")]
        public IWebElement finAssEquipCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssAcctsRec')]")]
        public IWebElement finAssAcctsRecCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssREPractice')]")]
        public IWebElement finAssREPracticeCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssREOther')]")]
        public IWebElement finAssREOtherCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinAssOther')]")]
        public IWebElement finAssOtherCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaTaxes')]")]
        public IWebElement finLiaTaxesCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaTaxesPmt')]")]
        public IWebElement finLiaTaxesPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaPracticeLoan')]")]
        public IWebElement finLiaPracticeLoanCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaPracticeLoanPmt')]")]
        public IWebElement finLiaPracticeLoanPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaEquipLoan')]")]
        public IWebElement finLiaEquipLoanCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaEquipLoanPmt')]")]
        public IWebElement finLiaEquipLoanPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaLOC')]")]
        public IWebElement finLiaLOCCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaLOCPmt')]")]
        public IWebElement finLiaLOCPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaMortPractice')]")]
        public IWebElement finLiaMortPracticeCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaMortPracticePmt')]")]
        public IWebElement finLiaMortPracticePmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaMortOther')]")]
        public IWebElement finLiaMortOtherCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaMortOtherPmt')]")]
        public IWebElement finLiaMortOtherPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaOther')]")]
        public IWebElement finLiaOtherCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F13_FinLiaOtherPmt')]")]
        public IWebElement finLiaOtherPmtCoAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinAssBankAccts')]")]
        public IWebElement finAssBankAcctsPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinAssInvest')]")]
        public IWebElement finAssInvestPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinAssREPrimary')]")]
        public IWebElement finAssREPrimaryPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinAssREOther')]")]
        public IWebElement finAssREOthersPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinAssOther')]")]
        public IWebElement finAssOthersPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaCC')]")]
        public IWebElement finLiaCCPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaCCPmt')]")]
        public IWebElement finLiaCCPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaTaxes')]")]
        public IWebElement finLiaTaxesPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaTaxesPmt')]")]
        public IWebElement finLiaTaxesPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaPersonalLoan')]")]
        public IWebElement finLiaPersonalLoanPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaPersonalLoanPmt')]")]
        public IWebElement finLiaPersonalLoanPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaLOC')]")]
        public IWebElement finLiaLOCPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaLOCPmt')]")]
        public IWebElement finLiaLOCPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaMortPrimary')]")]
        public IWebElement finLiaMortPrimaryPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaMortPrimaryPmt')]")]
        public IWebElement finLiaMortPrimaryPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaMortOther')]")]
        public IWebElement finLiaMortOtherPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaMortOtherPmt')]")]
        public IWebElement finLiaMortOtherPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaOther')]")]
        public IWebElement finLiaOtherPFS;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F14_FinLiaOtherPmt')]")]
        public IWebElement finLiaOtherPmtPFS;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[28]/tbody/tr[42]/td[3]/font)]")]
        public IWebElement pcdMonthly;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[28]/tbody/tr[42]/td[2]/font")]
        public IWebElement pcdAnnual;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F16_CMSDSPersDebtItems')]")]
        public IWebElement cmsDSPersDebtItems;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[28]/tbody/tr[43]/td[2]/font")]
        public IWebElement perMortAnnual;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[28]/tbody/tr[43]/td[3]/font")]
        public IWebElement perMortMonthly;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[30]/tbody/tr[43]/td[4]/font")]
        public IWebElement perMortItemization;

        [FindsBy(How = How.ClassName, Using = "modal-header")]
        public IWebElement modalHeader;

        [FindsBy(How = How.ClassName, Using = "screentitle")]
        public IWebElement screenTitle;

        [FindsBy(How = How.XPath, Using = "//h3/font[.='Validate PFS and Rescore']")]
        public IWebElement validatePFSandScoreH3;

        [FindsBy(How = How.XPath, Using = "//h3/font[.='Contingent Approve']")]
        public IWebElement contingentApproveH3;

        [FindsBy(How = How.XPath, Using = "//h3/font[.='CA 2 - 0 Days']")]
        public IWebElement ContingentApprovalTwo;

        [FindsBy(How = How.XPath, Using = "//h3/font[.='CA 2 - Maybe']")]
        public IWebElement ContingentApprovalTwoMaybe;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[41]/tbody/tr[14]/td[2]/font")]
        public IWebElement CATwoPricingGroups;

        [FindsBy(How = How.Id, Using = "btnAutoApprove")]
        public IWebElement btnContingentApprove;

        #endregion

        #region Liabilities
        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinAssBankAccts')]")]
        public IWebElement checkingAndSavings;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaCC')]")]
        public IWebElement creditCardsChargeAccts;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaPersonalLoan')]")]
        public IWebElement personalLoans;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaLOC')]")]
        public IWebElement mortgage;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaMortOther')]")]
        public IWebElement rentalInvestOtherIncome;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaCCPmt')]")]
        public IWebElement creditCardMonthlyPayment;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaTaxesPmt')]")]
        public IWebElement monthlyTaxesPayment;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaPersonalLoanPmt')]")]
        public IWebElement personalLoanPayments;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F15_FinLiaLOCPmt')]")]
        public IWebElement homeEquityLoanPayments;

        #endregion

        #region Guarantor Information

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'F12_GuarantorFirstName')]")]
        public IWebElement guarantorFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorMiddleInitial')]")]
        public IWebElement guarantorMiddleName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorLastName')]")]
        public IWebElement guarantorLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorAddress1')]")]
        public IWebElement guarantorAddress1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorCity')]")]
        public IWebElement guarantorCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorStateCode')]")]
        public IWebElement guarantorStateDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorPostalCode')]")]
        public IWebElement guarantorPostalCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorTitle')]")]
        public IWebElement guarantorBusinessTitleDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'Birthdate')]")]
        public IWebElement guarantorBirthdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorSSN')]")]
        public IWebElement guarantorSSN { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'GuarantorEmail')]")]
        public IWebElement guarantorEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'PrimIncSource')]")]
        public IWebElement guarantorPrimIncSource { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'SecIncSource')]")]
        public IWebElement guarantorSecIncSource { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'Specialty')]")]
        public IWebElement guarantorSpecialty { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'CurLicenseState')]")]
        public IWebElement guarantorCurLicenseStateDDL { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'CreditReleaseObtained')]")]
        public IWebElement guarantoCreditReleaseObtainedDDL { get; set; }


        public void CompleteApplicationEntry(string testName)
        {
            var userData = XcelDataAccess.GetTestData(testName);
            guarantorFirstName.SendKeys(userData.guarantorFirstName);
            guarantorLastName.SendKeys(userData.guarantorLastName);
            guarantorLastName.SendKeys(userData.guarantorMiddlename);
            guarantorAddress1.SendKeys(userData.guarantorAddress1);
            guarantorCity.SendKeys(userData.guarantorCity);
            guarantorStateDDL.SelectItemByValueFromDDL(userData.guarantorStateDDL);
            guarantorPostalCode.SendKeys(userData.guarantorPostalCode);
            guarantorBusinessTitleDDL.SelectItemByValueFromDDL(userData.guarantorBusinessTitleDDL);
            guarantorBirthdate.SendKeys(userData.guarantorBirthdate);
            guarantorSSN.SendKeys(userData.guarantorSSN);
            guarantorEmail.SendKeys(userData.guarantorEmail);
            guarantorPrimIncSource.SelectItemByValueFromDDL(userData.guarantorPrimIncSource);
            guarantorSecIncSource.SelectItemByValueFromDDL(userData.guarantorSecIncSource);
            guarantorSpecialty.SelectItemByValueFromDDL(userData.guarantorSpecialty);
            guarantorCurLicenseStateDDL.SelectItemByValueFromDDL(userData.guarantorCurLicenseStateDDL);
            guarantoCreditReleaseObtainedDDL.SelectItemByValueFromDDL(userData.guarantoCreditReleaseObtainedDDL);
            
            btnSubmit.Click();
        }

        public void CompletePFSSection(string testName)
        {
            var userData = XcelDataAccess.GetTestPFSData(testName);
            salaryAnnualIncome.SendKeys(userData.salaryAnnualIncome);
            rentalAnnualIncome.SendKeys(userData.rentalAnnualIncome);
            otherAnnualIncome.SendKeys(userData.otherAnnualIncome);
            finAssBankAcctsPFS.SendKeys(userData.finAssBankAcctsPFS);
            finAssInvestPFS.SendKeys(userData.finAssInvestPFS);
            finAssREPrimaryPFS.SendKeys(userData.finAssREPrimaryPFS);
            finAssREOthersPFS.SendKeys(userData.finAssREOthersPFS);
            finAssOthersPFS.SendKeys(userData.finAssOthersPFS);
            checkingAndSavings.SendKeys(userData.checkingAndSavings);
            creditCardsChargeAccts.SendKeys(userData.creditCardsChargeAccts);
            personalLoans.SendKeys(userData.personalLoans);
            mortgage.SendKeys(userData.mortgage);
            creditCardMonthlyPayment.SendKeys(userData.creditCardMonthlyPayment);
            monthlyTaxesPayment.SendKeys(userData.monthlyTaxesPayment);
            personalLoanPayments.SendKeys(userData.personalLoanPayments);
            homeEquityLoanPayments.SendKeys(userData.homeEquityLoanPayments);

            // Add data driven function for PFS 

        }

        #endregion

        #region Guarantor information 2

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[3]/td[2]/font[1]/input")]
        public IWebElement guarantorFirstName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[3]/td[2]/font[2]/input")]
        public IWebElement guarantorMiddleName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[3]/td[2]/font[3]/input")]
        public IWebElement guarantorLastName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[5]/td[2]/font/input")]
        public IWebElement guarantorAddress2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[6]/td[2]/font/input")]
        public IWebElement guarantorCity2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[7]/td[2]/font/select")]
        public IWebElement guarantorStateDDL2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[7]/td[4]/font/input")]
        public IWebElement guarantorPostalCode2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[12]/td[2]/font/select")]
        public IWebElement guarantorBusinessTitleDDL2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[12]/td[4]/font/input")]
        public IWebElement guarantorBirthdate2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[14]/td[2]/font/input")]
        public IWebElement guarantorSSN2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[16]/td[2]/font/input")]
        public IWebElement guarantorEmail2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[17]/td[2]/font/select")]
        public IWebElement guarantorPrimIncSource2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[18]/td[2]/font/select")]
        public IWebElement guarantorSecIncSource2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[17]/td[4]/font/select")]
        public IWebElement guarantorSpecialty2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[21]/td[2]/font/select")]
        public IWebElement guarantorCurLicenseStateDDL2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[25]/tbody/tr[25]/td[2]/font/select")]
        public IWebElement guarantoCreditReleaseObtainedDDL2 { get; set; }

        #endregion  

        #region Second Application Elements
        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[19]/tbody/tr/td/input[3]")]
        public IWebElement deleteSecondCompanyInfo;

        [FindsBy(How = How.XPath, Using = "//*[contains(@name, 'btnAddCompany')]")]
        public IWebElement addRelatedCompany;

        [FindsBy(How = How.XPath,Using = "//*[@id='AppV3BHG'] /table[20]/tbody/tr[3]/td[2]/font/input")]
        public IWebElement secondCompanyFullLegalName;
      
        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[5]/td[2]/font/select")]
        public IWebElement secondCoBusinessStrutureType;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[6]/td[2]/font/input")]
        public IWebElement secondCoAddress;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[7]/td[2]/font/input")]
        public IWebElement secondCoCity;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[8]/td[2]/font/select")]
        public IWebElement secondCoState;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[10]/td[2]/font/input")]
        public IWebElement secondCoPhoneNumber;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[8]/td[4]/font/input")]
        public IWebElement secondCoZipCode;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[9]/td[4]/font/input")]
        public IWebElement secondCoDateEstablished;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[16]/td[2]/font/select")]
        public IWebElement secondCoBankruptcy10years;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[17]/td[2]/font/select")]
        public IWebElement secondCoOutstandingTaxIrs;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[18]/td[2]/font/select")]
        public IWebElement secondCoTaxPriorYearFiled;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[22]/td[2]/font/select")]
        public IWebElement secondCoIntAcceptCC;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[15]/td[4]/font/input")]
        public IWebElement secondCoIntGrossSales;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[20]/td[4]/font/select")]
        public IWebElement secondCoIntbankStatements;

        #endregion

        #region Company Information 
        /*[FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[20]/td[4]/font/select")]
        public IWebElement secondCoIntbankStatements;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[20]/td[4]/font/select")]
        public IWebElement secondCoIntbankStatements;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[20]/td[4]/font/select")]
        public IWebElement secondCoIntbankStatements;

        [FindsBy(How = How.XPath, Using = "//*[@id='AppV3BHG']/table[20]/tbody/tr[20]/td[4]/font/select")]
        public IWebElement secondCoIntbankStatements;*/


        #endregion
        /// <summary>
        /// Clears all the text fields
        /// </summary>
        public void ClearTextGuarantorFields()
        {
            guarantorFirstName.Clear();
            guarantorMiddleName.Clear();
            guarantorLastName.Clear();
            guarantorEmail.Clear();
            guarantorAddress1.Clear();
            guarantorCity.Clear();
            guarantorPostalCode.Clear();
            guarantorSSN.Clear();
            requestAmt.Clear();
            intCoDateEstablished.Clear();
            intCoPhone.Clear();
            salaryAnnualIncome.Clear();
            rentalAnnualIncome.Clear();
            otherAnnualIncome.Clear();
        }

        public void ClearPersonalFinancialStatement()
        {
            //Clear PFS Assets
            finAssBankAcctsPFS.Clear();
            finAssInvestPFS.Clear();
            finAssREPrimaryPFS.Clear();
            finAssREOthersPFS.Clear();
            finAssOthersPFS.Clear();
            //Clear PFS Liabilities Fields
            finLiaCCPFS.Clear();
            finLiaTaxesPFS.Clear();
            finLiaPersonalLoanPFS.Clear();
            finLiaLOCPFS.Clear();
            finLiaMortPrimaryPFS.Clear();
            finLiaMortOtherPFS.Clear();
            finLiaOtherPFS.Clear();
            //Clear PFS personal income
            salaryAnnualIncome.Clear();
            rentalAnnualIncome.Clear();
            otherAnnualIncome.Clear();
            finLiaCCPmtPFS.Clear();
            finLiaTaxesPmtPFS.Clear();
            finLiaPersonalLoanPmtPFS.Clear();
            finLiaLOCPmtPFS.Clear();
            finLiaMortPrimaryPmtPFS.Clear();
            finLiaMortOtherPmtPFS.Clear();
            finLiaOtherPmtPFS.Clear();
        }

        public void GetAppNumber()
        {
            int appNumber;
            Int32.TryParse(appNum.Text,out appNumber);
            //ScenarioContext.Current["appNum"] = appNumber;
        }

        /// <summary>
        /// Completes the interview questions for first scoring. exlcusive of text inputs save for phone number and date established
        /// </summary>
        /// <param name="ira">Early withdrawals answer</param>
        /// <param name="alimony">Pays alimony question</param>
        /// <param name="otherBusiness">Involved in other businesses?</param>
        /// <param name="bankStatements">Has all bank statements</param>
        /// <param name="acceptCC">Accepts credit cards</param>
        /// <param name="coPhoneNum">Company phone number</param>
        /// <param name="dateEst">date established</param>
        public void CompleteInterviewQuestionsFirst(string useOfFunds, string requestAmount, string alimony, string otherBusiness, string bankStatements, string acceptCC, string coPhoneNum, string dateEst)
        {
            WebControlsExtension.SelectItemByTextFromDDL(useOfFundsDDL, useOfFunds);
            requestAmt.SendKeys(requestAmount);
            WebControlsExtension.SelectItemByTextFromDDL(eAlimonyChildSupDDL, alimony);
            WebControlsExtension.SelectItemByTextFromDDL(IntOtherBusinessesDDL, otherBusiness);
            WebControlsExtension.SelectItemByTextFromDDL(intCoBankStatementsDDL, bankStatements);
            WebControlsExtension.SelectItemByTextFromDDL(intCoAcceptCCDDL, acceptCC);
            intCoPhone.SendKeys(coPhoneNum);
            //intCoDateEstablished.SendKeys(dateEst);
        }

        /// <summary>
        /// Completes interview questions for second scoring save for text fields
        /// </summary>
        /// <param name="bankruptcy">Company bankruptcy?</param>
        /// <param name="taxLiens">Company tax liens?</param>
        /// <param name="taxesPrior">Company field taxes for prior year?</param>
        /// <param name="bankStatements">Company has business bank statements?</param>
        /// <param name="partnerCosign">Partner cosign loan?</param>
        /// <param name="currLicenseSt">Current license state?</param>
        /// <param name="bankruptcyPer">Personal banktuptcy?</param>
        /// <param name="bankruptcyIntent">Intent to file bankruptcy?</param>
        /// <param name="taxLiensPer">Personal tax liens?</param>
        /// <param name="discpAction">Disciplinary actions on license?</param>
        /// 
        public void CompleteInterviewQuestionsSecondScore(string bankruptcy, string taxLiens, string taxesPrior, string ira, string bankStatements, string partnerCosign, string currLicenseSt, string bankruptcyPer, string bankruptcyIntent, string taxLiensPer, string taxesPriorPer, string taxAddCorrectPer, string discpAction, string dateEst)
        {
            WebControlsExtension.SelectItemByTextFromDDL(intCoBankruptcyDDL, bankruptcy);
            WebControlsExtension.SelectItemByTextFromDDL(intCoTaxLiensDDL, taxLiens);
            WebControlsExtension.SelectItemByTextFromDDL(intCoTaxPriorYearFiledDDL, taxesPrior);
            WebControlsExtension.SelectItemByTextFromDDL(intCoBankStatementsDDL, bankStatements);
            WebControlsExtension.SelectItemByTextFromDDL(intPartnerWillCosignDDL, partnerCosign);
            WebControlsExtension.SelectItemByTextFromDDL(intCurrLicenseStateDDL, currLicenseSt);
            WebControlsExtension.SelectItemByTextFromDDL(intBankruptcyDDL, bankruptcyPer);
            WebControlsExtension.SelectItemByTextFromDDL(earlyWithdrawal3YearsDDL, ira);
            WebControlsExtension.SelectItemByTextFromDDL(intBankruptcyIntentDDL, bankruptcyIntent);
            WebControlsExtension.SelectItemByTextFromDDL(intTaxLiensDDL, taxLiensPer);
            WebControlsExtension.SelectItemByTextFromDDL(intTaxPriorYearFiledDDL, taxesPriorPer);
            WebControlsExtension.SelectItemByTextFromDDL(intTaxReturnAddressDDL, taxAddCorrectPer);
            WebControlsExtension.SelectItemByTextFromDDL(intDisciplinaryActionDDL, discpAction);
            intCoDateEstablished.SendKeys(dateEst);
        }

        /// <summary>
        /// Completes company assets amounts
        /// </summary>
        /// <param name="bankAmt"></param>
        /// <param name="practiceAmt"></param>
        /// <param name="equipAmt"></param>
        /// <param name="finAcctsRecAmt"></param>
        /// <param name="rePracticeAmt"></param>
        /// <param name="reOtherAmt"></param>
        /// <param name="otherAmt"></param>
        public void CompleteCompanyAssetsFS(string bankAmt, string practiceAmt, string equipAmt, string finAcctsRecAmt, string rePracticeAmt, string reOtherAmt, string otherAmt)
        {
            finAssBankCoAccts.SendKeys(bankAmt);
            finAssPracticeCoAccts.SendKeys(practiceAmt);
            finAssEquipCoAccts.SendKeys(equipAmt);
            finAssAcctsRecCoAccts.SendKeys(finAcctsRecAmt);
            finAssREPracticeCoAccts.SendKeys(rePracticeAmt);
            finAssREOtherCoAccts.SendKeys(reOtherAmt);
            finAssOtherCoAccts.SendKeys(otherAmt);
        }

        /// <summary>
        /// Completes company liabilities amounts
        /// </summary>
        /// <param name="finLiaTaxesCo"></param>
        /// <param name="finLiaPracticeLoan"></param>
        /// <param name="finLiaEquipLoan"></param>
        /// <param name="finLOCCo"></param>
        /// <param name="finLiaMortPractice"></param>
        /// <param name="finLiaMortOther"></param>
        /// <param name="finLiaOther"></param>
        public void CompleteCompanyLiabilitiesAmountsFS(string finLiaTaxesCo, string finLiaPracticeLoan, string finLiaEquipLoan, string finLOCCo, string finLiaMortPractice, string finLiaMortOther, string finLiaOther)
        {
            finLiaTaxesCoAccts.SendKeys(finLiaTaxesCo);
            finLiaPracticeLoanCoAccts.SendKeys(finLiaPracticeLoan);
            finLiaEquipLoanCoAccts.SendKeys(finLiaEquipLoan);
            finLiaLOCCoAccts.SendKeys(finLOCCo);
            finLiaMortPracticeCoAccts.SendKeys(finLiaMortPractice);
            finLiaMortOtherCoAccts.SendKeys(finLiaMortOther);
            finLiaOtherCoAccts.SendKeys(finLiaOther);
        }

        /// <summary>
        /// Completes company liabilities payments
        /// </summary>
        /// <param name="finLiaTaxesCoPmt"></param>
        /// <param name="finLiaPracticeLoanPmt"></param>
        /// <param name="finLiaEquipLoanPmt"></param>
        /// <param name="finLOCCoPmt"></param>
        /// <param name="finLiaMortPracticePmt"></param>
        /// <param name="finLiaMortOtherPmt"></param>
        /// <param name="finLiaOtherPmt"></param>
        public void CompleteCompanyLiabilitiesPaymentsFS(string finLiaTaxesCoPmt, string finLiaPracticeLoanPmt, string finLiaEquipLoanPmt, string finLOCCoPmt, string finLiaMortPracticePmt, string finLiaMortOtherPmt, string finLiaOtherPmt)
        {
            finLiaTaxesPmtCoAccts.SendKeys(finLiaTaxesCoPmt);
            finLiaPracticeLoanPmtCoAccts.SendKeys(finLiaPracticeLoanPmt);
            finLiaEquipLoanPmtCoAccts.SendKeys(finLiaEquipLoanPmt);
            finLiaLOCPmtCoAccts.SendKeys(finLOCCoPmt);
            finLiaMortPracticePmtCoAccts.SendKeys(finLiaMortPracticePmt);
            finLiaMortOtherPmtCoAccts.SendKeys(finLiaMortOtherPmt);
            finLiaOtherPmtCoAccts.SendKeys(finLiaOtherPmt);
        }

        /// <summary>
        /// Completes PFS assets
        /// </summary>
        /// <param name="bankAccts"></param>
        /// <param name="investments"></param>
        /// <param name="rePrimary"></param>
        /// <param name="reOther"></param>
        /// <param name="other"></param>
        public void CompletePFSAssets(string bankAccts, string investments, string rePrimary, string reOther, string other)
        {
            finAssBankAcctsPFS.SendKeys(bankAccts);
            finAssInvestPFS.SendKeys(investments);
            finAssREPrimaryPFS.SendKeys(rePrimary);
            finAssREOthersPFS.SendKeys(reOther);
            finAssOthersPFS.SendKeys(other);
        }

        /// <summary>
        /// Completes PFS liabilities
        /// </summary>
        /// <param name="finLiaCC"></param>
        /// <param name="finLiaTaxes"></param>
        /// <param name="finLiaPersonal"></param>
        /// <param name="finLOC"></param>
        /// <param name="mortPrimary"></param>
        /// <param name="mortOther"></param>
        /// <param name="other"></param>
        public void CompletePFSLiabilitiesAmounts(string finLiaCC, string finLiaTaxes, string finLiaPersonal, string finLOC, string mortPrimary, string mortOther, string other)
        {
            finLiaCCPFS.SendKeys(finLiaCC); 
            finLiaTaxesPFS.SendKeys(finLiaTaxes);
            finLiaPersonalLoanPFS.SendKeys(finLiaPersonal);
            finLiaLOCPFS.SendKeys(finLOC);
            finLiaMortPrimaryPFS.SendKeys(mortPrimary);
            finLiaMortOtherPFS.SendKeys(mortOther);
            finLiaOtherPFS.SendKeys(other);
        }

        /// <summary>
        /// Completes PFS liabilities payments
        /// </summary>
        /// <param name="finLiaCCPmt"></param>
        /// <param name="finLiaTaxesPmt"></param>
        /// <param name="finLiaPersonalPmt"></param>
        /// <param name="finLOCPmt"></param>
        /// <param name="mortPrimaryPmt"></param>
        /// <param name="mortOtherPmt"></param>
        /// <param name="otherPmt"></param>
        public void CompletePFSLiablitiesPayments(string finLiaCCPmt, string finLiaTaxesPmt, string finLiaPersonalPmt, string finLOCPmt, string mortPrimaryPmt, string mortOtherPmt, string otherPmt)
        {
            finLiaCCPmtPFS.SendKeys(finLiaCCPmt);
            finLiaTaxesPmtPFS.SendKeys(finLiaTaxesPmt);
            finLiaPersonalLoanPmtPFS.SendKeys(finLiaPersonalPmt);
            finLiaLOCPmtPFS.SendKeys(finLOCPmt);
            finLiaMortPrimaryPmtPFS.SendKeys(mortPrimaryPmt);
            finLiaMortOtherPmtPFS.SendKeys(mortOtherPmt);
            finLiaOtherPmtPFS.SendKeys(otherPmt);
        }



        /// <summary>
        /// Completes guarantor name
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        public void CompleteGuarantorName(string fName, string mName, string lName)
        {
            guarantorFirstName.SendKeys(fName);
            guarantorMiddleName.SendKeys(mName);
            guarantorLastName.SendKeys(lName);
        }

        /// <summary>
        /// Completes guarantor address
        /// </summary>
        /// <param name="hAddress"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        public void CompleteGuarantorAddress(string hAddress, string city, string state, string zip)
        {
            guarantorAddress1.SendKeys(hAddress);
            guarantorCity.SendKeys(city);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorStateDDL, state);
            guarantorPostalCode.SendKeys(zip);
        }

        /// <summary>
        /// Completes guarantor personal information
        /// </summary>
        /// <param name="guarantorTitle"></param>
        /// <param name="guarantorBirthDay"></param>
        /// <param name="ssn"></param>
        /// <param name="email"></param>
        public void CompleteGuarantorPersonalInformation(string guarantorTitle, string guarantorBirthDay, string ssn, string email)
        {
            WebControlsExtension.SelectItemByTextFromDDL(guarantorBusinessTitleDDL, guarantorTitle);
            guarantorBirthdate.Clear();
            guarantorBirthdate.SendKeys(guarantorBirthDay);
            guarantorSSN.SendKeys(ssn);
            guarantorEmail.SendKeys(email);
        }

        /// <summary>
        /// Filss in the guarantor medical speciality, license, and income as well as credit release
        /// </summary>
        /// <param name="primIncomeSource">Guarantor's primary income</param>
        /// <param name="secIncomeSource">Guarantor's secondary income</param>
        /// <param name="specialty">Guarantor's specialty</param>
        /// <param name="state">Guarantor's medical license state</param>
        /// <param name="creditAnswer">Answer to credit release question</param>
        public void CompleteGuarantorMedicalAndIncome(string primIncomeSource, string secIncomeSource, string specialty, string state, string creditAnswer)
        {
            WebControlsExtension.SelectItemByTextFromDDL(guarantorPrimIncSource, primIncomeSource);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorSecIncSource, secIncomeSource);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorSpecialty, specialty);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorCurLicenseStateDDL, state);
            WebControlsExtension.SelectItemByTextFromDDL(guarantoCreditReleaseObtainedDDL, creditAnswer);
        }

        #region  Guarantor Information two methods

        //ToDo Need To add mehtods 
        /// <summary>
        /// Filss in the guarantor medical speciality, license, and income as well as credit release
        /// </summary>
        /// <param name="primIncomeSource">Guarantor's primary income</param>
        /// <param name="secIncomeSource">Guarantor's secondary income</param>
        /// <param name="specialty">Guarantor's specialty</param>
        /// <param name="state">Guarantor's medical license state</param>
        /// <param name="creditAnswer">Answer to credit release question</param>
        public void CompleteGuarantorMedicalAndIncomeTwo(string primIncomeSource, string secIncomeSource, string specialty, string state, string creditAnswer)
        {
            WebControlsExtension.SelectItemByTextFromDDL(guarantorPrimIncSource2, primIncomeSource);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorSecIncSource2, secIncomeSource);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorSpecialty2, specialty);
            WebControlsExtension.SelectItemByTextFromDDL(guarantorCurLicenseStateDDL2, state);
            WebControlsExtension.SelectItemByTextFromDDL(guarantoCreditReleaseObtainedDDL2, creditAnswer);
        }


        /// <summary>
        /// Completes guarantor name
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="mName"></param>
        /// <param name="lName"></param>
        public void CompleteGuarantorNameTwo(string fName, string mName, string lName)
        {
            guarantorFirstName2.SendKeys(fName);
            guarantorMiddleName2.SendKeys(mName);
            guarantorLastName2.SendKeys(lName);
        }

        /// <summary>
        /// Completes guarantor personal information
        /// </summary>
        /// <param name="guarantorTitle"></param>
        /// <param name="guarantorBirthDay"></param>
        /// <param name="ssn"></param>
        /// <param name="email"></param>
        public void CompleteGuarantorPersonalInformationTwo(string guarantorTitle, string guarantorBirthDay, string ssn, string email)
        {
            WebControlsExtension.SelectItemByTextFromDDL(guarantorBusinessTitleDDL2, guarantorTitle);
            guarantorBirthdate2.Clear();
            guarantorBirthdate2.SendKeys(guarantorBirthDay);
            guarantorSSN2.SendKeys(ssn);
            guarantorEmail.SendKeys(email);
        }

        #endregion

        /// <summary>
        /// Fills in the personal income
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="rentalIncome"></param>
        /// <param name="otherIncome"></param>
        public void CompletePersonalIncome(string salary, string rentalIncome, string otherIncome)
        {
            salaryAnnualIncome.SendKeys(salary);
            rentalAnnualIncome.SendKeys(rentalIncome);
            otherAnnualIncome.SendKeys(otherIncome);
        }

        /// <summary>
        /// Clicks the autofill button on the page
        /// </summary>
        public void ClickAutoFillButton()
        {
            btnAutoFill.Click();
        }

        /// <summary>
        /// Clicks the Score button on the page
        /// </summary>
        public void ClickScoreButton()
        {
           btnSubmit.Click();
        }

        public void WaitForPageReload()
        {
            DriverWait.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("btnSubmit2")));
        }

        /// <summary>
        /// Waits for the message "Application updated"
        /// </summary>
        public void WaitForPageUpdate()
        {
            DriverWait.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("sessioninfo")));
            //Assert.IsTrue(ExpectedConditions.ElementIsVisible(By.ClassName("sessioninfo")));
        }

        /// <summary>
        /// Verifies first score text appears
        /// </summary>
        public void VerifyFirstScoreText()
        {
            
           // DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(validatePFSandScoreH3, "Validate PFS and Rescore"));
            WebControlsExtension.VerifySelectedTextFromDDL(appStatusDDL, "Core Scored");


        }
        /// <summary>
        /// Verifies Contingent Approve text appears
        /// </summary>
        public void VerifyContingentApprovalText()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(contingentApproveH3, "Contingent Approve"));
            WebControlsExtension.VerifySelectedTextFromDDL(appStatusDDL, "Core Scored");
        }

        /// <summary>
        /// Verifies Contingent Approve two  text appears
        /// </summary>

        public void VerifyContingentApprovalTwoText()
        {
            
          //  DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(ContingentApprovalTwo, "CA 2 - 0 Days"));
            WebControlsExtension.VerifySelectedTextFromDDL(appStatusDDL, "Core Scored");
        }

        public void VerifyContingentApprovalTwoMaybe()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(ContingentApprovalTwoMaybe, "CA 2 - Maybe"));
            WebControlsExtension.VerifySelectedTextFromDDL(appStatusDDL, "Core Scored");
        }

        #region verify contingent approval pricing groups

        public void VerifyContingentTwoPricingGroupOne()
        {
           // DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "1"));   
        }

        public void VerifyContingentTwoPricingGroupTwo()
        {
           // DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "2"));          
        }

        public void VerifyContingentTwoPricingGroupThree()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "3"));      
        }

        public void VerifyContingentTwoPricingGroupFour()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "4"));
        }

        public void VerifyContingentTwoPricingGroupSix()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "6"));
        }

        public void VerifyContingentTwoPricingGroupSeven()
        {
            //DriverWait.Wait.Until(ExpectedConditions.TextToBePresentInElement(CATwoPricingGroups, "7"));      
        }
        #endregion

        public void VerifyPersonalConsumerDebt()
        {
            
            /*var pcdAnnual = this.pcdAnnual.Text;
            var pcdMonthly = this.pcdMonthly.Text;
            var pcdItemization = this.cmsDSPersDebtItems.Text;
            var perMortMonthly = this.perMortMonthly.Text;
            var perMortAnnual = this.perMortAnnual.Text;*/
            //var perMortItemization = this.perMortItemization.Text;
            var mortConcat = finLiaMortPrimaryPmtPFS.Text + "+" + finLiaMortOtherPFS.Text;
            Assert.AreEqual(mortConcat , perMortItemization.Text);

            /*
            double pcdAnnualDbl = 0;
            double pcdMonthlyDbl = 0;
            pcdAnnualDbl = double.Parse(pcdAnnual);
            pcdMonthlyDbl = double.Parse(pcdMonthly);
            Asert.AreEqual(this.finLiaMortPrimaryPmtPFS);*/

        }

        public void IsAt()
        {
            //DriverWait.wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("screentitle")));
            DriverWait.WaitForPageLoaded();
            Assert.IsTrue(appStatusDDL.Displayed);
        }

        public void resetVisionApplicationToInitialEntry()
        {

            DatabaseHelper.SqlExecuteCommand("Data Source=BHG-COLO-SQ05;" + "Initial Catalog=Vision;" + "Integrated Security=True;",
         @" DECLARE @ApplicationNum int = 211553 
            UPDATE tApplication
            SET ApplicationStatus='E'
            WHERE ApplicationNum = @ApplicationNum");


        }
    }
}
