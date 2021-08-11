using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clippings_Solution.Pages
{
    public class SearchPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;

        private string pageUrl = "https://clippings.com/search?next=%2F&hierarchicalMenu%5BcategoryList.lvl0%5D=Lighting%2FLight%20Bulbs&page=1";
        
        // selectors
        private By minValueSelector = By.CssSelector(@"#currentPriceInCurrency\.EUR-inputMin");
        private By maxValueSelector = By.CssSelector(@"#currentPriceInCurrency\.EUR-inputMax");
        private By valueFilterSubmitButton = By.CssSelector("section[data-title='Price'] button");
        private By itemPrice = By.CssSelector("div[data-testid='component-price']");
        private By currencyDropdown = By.CssSelector("input[name='currency']");
        private By currencyDropdownOptions = By.CssSelector("li[data-value]");

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        internal void EnterMinValue(string minValue)
        {
            IWebElement minValueInput = wait.Until(ExpectedConditions.ElementIsVisible(minValueSelector));
            minValueInput.SendKeys(minValue);
        }

        internal void EnterMaxValue(string maxValue)
        {
            IWebElement maxValueInput = wait.Until(ExpectedConditions.ElementIsVisible(maxValueSelector));
            maxValueInput.SendKeys(maxValue);
        }

        internal void SelectSearchButton()
        {
            _driver.FindElement(valueFilterSubmitButton).Click();
        }

        internal void ChangeCurrency(string currency)
        {
            IWebElement currencyInput = wait.Until(ExpectedConditions.ElementExists(currencyDropdown));
            currencyInput.Click();
            var elements = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(currencyDropdownOptions));

            foreach (var option in elements)
            {
                if (option.Text.Contains(currency))
                {
                    option.Click();
                }
            }
        }

        internal void ResultsAreFilteredByPrice(double minValue, double maxValue)
        {
            var items = _driver.FindElements(itemPrice);

            foreach (var item in items)
            {
                double itemPrice = double.Parse(item.Text);
                Assert.IsTrue(itemPrice >= minValue && itemPrice <= maxValue);
            }
        }
    }
}
