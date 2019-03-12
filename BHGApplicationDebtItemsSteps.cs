using BHG.Test.MasterFramework.BHGBaseObjects;
using BHGVision.Pages;


namespace BHGVision.Test
{
   
    public class BHGApplicationDebtItemsSteps : BHGBaseSteps
    {
        //[Given(@"I have entered PFS data")]
        public void GivenIHaveEnteredPFSData()
        {
            _CurrentPage.As<BHGApplicationPage>().CompleteInterviewQuestionsSecondScore("No", "No", "Yes", "No", "Yes", "No", "Texas", "No", "No", "No", "Yes", "Yes", "No", "05/05/2005");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSAssets("25000", "85000", "200000", "0.00", "0.00");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiabilitiesAmounts("15000", "2000", "0.00", "0.00", "100000", "10000", "1000");
            _CurrentPage.As<BHGApplicationPage>().CompletePFSLiablitiesPayments("900", "150", "0.00", "0.00", "750", "200", "50");
        }
        
       // [Then(@"All the PFS debt is copied into the Debt Service area")]
        public void ThenAllThePFSDebtIsCopiedIntoTheDebtServiceArea()
        {
            _CurrentPage.As<BHGApplicationPage>().VerifyPersonalConsumerDebt();
        }

       // [When(@"I press Score and wait for the Update completed successfully message")]
        public void WhenIPressScoreAndWaitForTheUpdateCompletedSuccessfullyMessage()
        {
            _CurrentPage.As<BHGApplicationPage>().ClickScoreButton();
            _CurrentPage.As<BHGApplicationPage>().WaitForPageUpdate();
        }


    }
}
