using Clippings_Solution.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Clippings_Solution.Pages
{
    public class SearchPage
    {
        private IWebDriver _driver;
        private WebDriverWait wait;

        private string pageUrl = "https://clippings.com/search?next=%2F&hierarchicalMenu%5BcategoryList.lvl0%5D=Lighting%2FLight%20Bulbs&page=1";

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
            IWebElement minValueInput = wait.Until(ExpectedConditions.ElementIsVisible(Selectors.minValueSelector));
            minValueInput.SendKeys(minValue);
        }

        internal void EnterMaxValue(string maxValue)
        {
            IWebElement maxValueInput = wait.Until(ExpectedConditions.ElementIsVisible(Selectors.maxValueSelector));
            maxValueInput.SendKeys(maxValue);
        }

        internal void SelectSearchButton()
        {
            _driver.FindElement(Selectors.valueFilterSubmitButton).Click();
        }

        internal void ChangeCurrency()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            IWebElement closeButton = wait.Until(ExpectedConditions.ElementToBeClickable(Selectors.closeNotificationButton));
            closeButton.Click();
            IWebElement currencyInput = wait.Until(ExpectedConditions.ElementToBeClickable(Selectors.currencyDropdown));
            currencyInput.Click();
            IWebElement euroOption = wait.Until(ExpectedConditions.ElementToBeClickable(Selectors.currencyDropdownOptionEuro));
            euroOption.Click();
        }

        internal void ResultsAreFilteredByPrice(double minValue, double maxValue)
        {
            Thread.Sleep(3000);
            var items = _driver.FindElements(Selectors.itemPrice);

            foreach (var item in items)
            {
                var itemText = item.Text.Replace('€', ' ').Trim();
                double itemPrice = double.Parse(itemText);
                Assert.IsTrue(itemPrice >= minValue && itemPrice <= maxValue);
            }
        }
    }
}
