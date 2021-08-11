using Clippings_Solution.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Clippings_Solution.Steps
{
    [Binding]
    public sealed class SearchSteps
    {

        private readonly ScenarioContext _scenarioContext;
        IWebDriver _driver;
        SearchPage searchPage;

        public SearchSteps(Hooks hook)
        {
            _driver = hook.GetDriver();
            searchPage = new SearchPage(_driver);
        }

        [Given(@"I navigate to the search page")]
        public void GivenINavigateToTheSearchPage()
        {
            searchPage.NavigateTo();
        }

        [Given(@"I change currency to ""(.*)""")]
        public void GivenIChangeCurrencyTo(string currency)
        {
            searchPage.ChangeCurrency(currency);
        }

        [When(@"I enter ""(.*)"" in the min value input")]
        public void WhenIEnterInTheMinValueInput(string minValue)
        {
            searchPage.EnterMinValue(minValue);
        }

        [When(@"I enter ""(.*)"" in the max value input")]
        public void WhenIEnterInTheMaxValueInput(string maxValue)
        {
            searchPage.EnterMaxValue(maxValue);
        }

        [When(@"I select the search button")]
        public void WhenISelectTheSearchButton()
        {
            searchPage.SelectSearchButton();
        }

        [Then(@"the page should display filtered results")]
        public void ThenThePageShouldDisplayFilteredResults()
        {
            searchPage.ResultsAreFilteredByPrice(100, 300);
        }


    }
}
