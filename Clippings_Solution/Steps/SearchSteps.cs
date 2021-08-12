using Clippings_Solution.Helpers;
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
        Context _context;
        SearchPage searchPage;
        int _minValue;
        int _maxValue;

        public SearchSteps(Context context)
        {
            _context = context;
            searchPage = new SearchPage(_context.Driver);
        }

        [Given(@"I navigate to the search page")]
        public void GivenINavigateToTheSearchPage()
        {
            searchPage.NavigateTo();
        }

        [Given(@"I change currency to euro")]
        public void GivenIChangeCurrencyTo()
        {
            searchPage.ChangeCurrency();
        }

        [When(@"I enter ""(.*)"" in the min value input")]
        public void WhenIEnterInTheMinValueInput(string minValue)
        {
            searchPage.EnterMinValue(minValue);
            _minValue = int.Parse(minValue);
        }

        [When(@"I enter ""(.*)"" in the max value input")]
        public void WhenIEnterInTheMaxValueInput(string maxValue)
        {
            searchPage.EnterMaxValue(maxValue);
            _maxValue = int.Parse(maxValue);
        }

        [When(@"I select the search button")]
        public void WhenISelectTheSearchButton()
        {
            searchPage.SelectSearchButton();
        }

        [Then(@"the page should display filtered results")]
        public void ThenThePageShouldDisplayFilteredResults()
        {
            searchPage.ResultsAreFilteredByPrice(_minValue, _maxValue);
        }


    }
}
