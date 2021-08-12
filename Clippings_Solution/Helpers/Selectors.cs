using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clippings_Solution.Helpers
{
    public static class Selectors
    {
        public static By minValueSelector = By.CssSelector(@"#currentPriceInCurrency\.EUR-inputMin");
        public static By maxValueSelector = By.CssSelector(@"#currentPriceInCurrency\.EUR-inputMax");
        public static By valueFilterSubmitButton = By.CssSelector("section[data-title='Price'] button");
        public static By itemPrice = By.CssSelector("div[data-testid='component-price']");
        public static By currencyDropdown = By.CssSelector("#mui-component-select-currency");
        public static By currencyDropdownOptionEuro = By.XPath("//li[contains(text(), 'Euro')]");
        public static By closeNotificationButton = By.CssSelector("button[id*=putinbay]");
    }
}
