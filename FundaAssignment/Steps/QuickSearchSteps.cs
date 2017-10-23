using System;
using TechTalk.SpecFlow;
using FundaAssignment.Pages;
using NUnit.Framework;

namespace FundaAssignment.Steps
{
    [Binding]
    public class QuickSearchSteps : BaseSteps
    {
        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            HomePage homePage = new HomePage(Driver);
            Assert.True(homePage.IsPageDisplayed());
        }
        
        [Given(@"'(.*)' is selected")]
        public void GivenIsSelected(string category)
        {            
            HomePage homePage = new HomePage(Driver);
            homePage.CategoryIsSelected(category);
        }
        
        [When(@"I do a search")]
        public void WhenIDoASearch()
        {
            HomePage homePage = new HomePage(Driver);
            homePage.SearchButton().Click();
        }
        
        [Then(@"result page is shown")]
        public void ThenResultPageIsShown()
        {
            SearchPage searchPage = new SearchPage(Driver);
            Assert.True(searchPage.IsPageDisplayed());

        }
        
        [Then(@"I can see '(.*)'")]
        public void ThenICanSee(string serachResult)
        {
            SearchPage searchPage = new SearchPage(Driver);
            Assert.True(searchPage.IsSearchResulstDisplayed(serachResult));
        }
    }
}
