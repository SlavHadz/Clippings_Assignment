using Clippings_Solution.Helpers;
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
        private Context _context;

        public Hooks(Context context)
        {
            _context = context;
        }

        [BeforeScenario]
        public void SetUp()
        {
            _context.Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _context.Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            _context.Driver.Close();
            _context.Driver.Quit();
        }
    }
}
