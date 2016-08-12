﻿using System.Configuration;

namespace TADASHBOARRD.Common
{
    public class TestData :CommonActions
    {
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string dashBoardURL = ConfigurationManager.AppSettings["url"];
        public static string validUsername = "administrator";
        public static string validPassword = "";
        public static string defaulRepository = "SampleRepository";
        public static string testRepository = "TestRepository";
        public static string invalidUsername = "abc";
        public static string invalidPassword = "abc";
        public static string errorLoginMessage = "Username or password is invalid";
        public static string testUsername = "test";
        public static string testUppercasePassword = "TEST";
        public static string testLowercasePassword = "test";
        public static string uppercaseUsername = "UPPERCASEUSERNAME";
        public static string lowercasePassword = "uppercaseusername";
        public static string lowercaseUsername = "uppercaseusername";
        public static string specialUsername = "specialCharsPassword";
        public static string specialCharactersPassword = "`!@^&*(+_=[{;'\",./<?";
        public static string specialCharactersUsername = "`~!@$^&()',.";
        public static string specialPassword = "specialCharsUser";
        public static string blankUsername = "";
        public static string blankPassword = "";
        public static string errorBlankUsernameLoginMessage = "Please enter username";
        public static string addPageName = "test123";
        public static string panelName = "test"+GetDateTime();
    }
}
