﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TADASHBOARRD.PageActions.LoginPage;
using TADASHBOARRD.PageActions.GeneralPage;
using TADASHBOARRD.Common;
using TADASHBOARRD.PageActions.PanelsPage;
using System.Threading;

namespace TADASHBOARRD.Testcases
{
    [TestClass]
    public class MainPageTestCases : BaseTest
    {
        private LoginPage loginPage;
        private GeneralPage generalPage;
        private NewPageDialog newPageDialog;

        [TestMethod]
        public void DA_MP_TC020_Verify_that_user_is_able_to_delete_sibbling_page_as_long_as_that_page_has_not_children_page_under_it()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.DeleteAllPages();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName1 = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName1, TestData.overviewPage, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName2 = CommonActions.GetDateTime();
            newPageDialog.CreateNewPage(pageName2, pageName1, TestData.blankNumberOfColumns, TestData.blankDisplayAfter, TestData.statusPublic);
            generalPage.goToPage(TestData.overviewPage + "/" + pageName1);
            generalPage.PerformDelete();
            string actualMessage = generalPage.GetTextPopup();
            //VP: Check message "Can't delete page "page 1" since it has children page"
            generalPage.CheckDynamicTextDisplays(pageName1, actualMessage);
        }

        [TestMethod]
        public void DA_MP_TC026_Verify_that_page_column_is_correct_when_user_edit_Number_of_Columns_field_of_a_specific_page()
        {
            loginPage = new LoginPage();
            loginPage.Login(TestData.defaulRepository, TestData.validUsername, TestData.validPassword);
            generalPage = new GeneralPage();
            generalPage.OpenAddPageDialog();
            newPageDialog = new NewPageDialog();
            string pageName = GetDateTime();
            newPageDialog.CreateNewPage(pageName, TestData.defaultParentPage, TestData.defaultNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenPage(pageName);
            generalPage.OpenEditPageDialog();
            newPageDialog.EditPage(TestData.newPageName, TestData.defaultParentPage, TestData.newNumberOfColumns, TestData.defaultDisplayAfter, TestData.statusNotPublic);
            generalPage.OpenEditPageDialog();
            string numberOfColumns = newPageDialog.GetSelectedValueInNumberOfColumns();
            // VP: There are 3 columns on the above created page
            CheckTextDisplays(numberOfColumns, TestData.newNumberOfColumns);
            // Post-Condition
            generalPage.DeleteAllPages();
            generalPage.Logout();
        }
    }
}
