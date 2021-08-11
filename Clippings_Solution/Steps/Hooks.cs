using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace Clippings_Solution.Steps
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
