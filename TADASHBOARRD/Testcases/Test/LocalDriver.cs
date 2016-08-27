﻿using Fenton.Selenium.SuperDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TADASHBOARRD.Testcases.Test
{
   public class LocalDriver
    {   
        public static IWebDriver GetDriver(Browser browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case Browser.SuperWebDriver:
                    driver = new SuperWebDriver(GetDriverSuite());
                    break;
                case Browser.Chrome:
                    driver = new ChromeDriver();
                    break;
                case Browser.InternetExplorer:
                    driver = new InternetExplorerDriver(new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true });
                    break;
                case Browser.MicrosoftEdge:
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new FirefoxDriver();
                    break;
            }

            return driver;
        }


        public static IList<IWebDriver> GetDriverSuite()
        {
            // Allow some degree of parallelism when creating drivers, which can be slow
            IList<IWebDriver> drivers = new List<Func<IWebDriver>>
            {
                () => { return GetDriver(Browser.Chrome); },
                () => { return GetDriver(Browser.Firefox); },
                () => { return GetDriver(Browser.InternetExplorer); },
                () => { return GetDriver(Browser.MicrosoftEdge); },
            }.AsParallel().Select(d => d()).ToList();

            return drivers;
        }
    }
}
