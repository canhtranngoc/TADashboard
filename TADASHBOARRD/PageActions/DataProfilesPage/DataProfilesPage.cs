﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TADASHBOARRD.Common;

namespace TADASHBOARRD.PageActions.DataProfilesPage
{
    public class DataProfilesPage : GeneralPage.GeneralPage
    {
        public void OpenCreateProfilePageFromDataProfilesPage()
        {
            Sleep(1);
            Click("add new link");
        }

        public void DeleteProfile(string name)
        {
            string xpathLinkDelete = string.Format("//tbody//a[.='{0}']/../..//a[.='Delete']", name);
            WebDriver.driver.FindElement(By.XPath(xpathLinkDelete)).Click();
            AcceptAlert();
        }
        public void DeleteAllProfiles()
        {
            try
            {
                Click("check all link");
                Click("delete link");
                AcceptAlert();
            }
            catch (WebDriverException)
            {
                Console.WriteLine("no profile displays");
            }
        }

        public void CheckDataProfileOtherSettingPages(string name)
        {
            // Wait for page loads
            Sleep(1);
            string xpathDataProfile = string.Format("//a[.='{0}']", name);
            WebDriver.driver.FindElement(By.XPath(xpathDataProfile)).Click();
            Click("display fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.displayFields, GetText("fields header"));
            Click("sort fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.sortFields, GetText("fields header"));
            Click("filter fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.filterFields, GetText("fields header"));
            Click("statistic fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.statisticFields, GetText("fields header"));
            Click("display sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.displaySubFields, GetText("fields header"));
            Click("sort sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.sortSubFields, GetText("fields header"));
            Click("filter sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.filterSubFields, GetText("fields header"));
            Click("statistic sub-fields tab");
            // Wait for page loads
            Sleep(1);
            CheckTextDisplays(TestData.statisticSubFields, GetText("fields header"));
        }
    }
}
