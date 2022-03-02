using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest
{
    internal class Class3
    {
        [Test]
        public static void TestChrome()
        {
            IWebDriver chrome = new ChromeDriver(); //paledzia narsykle
            chrome.Url = "https://login.yahoo.com/"; //ivedmas url
            chrome.Manage().Window.Maximize();
            IWebElement inputField = chrome.FindElement(By.Id("login-username")); //sukuriamas kintamasis ir parodome ko ieskome kabutese tekstas is konsoles, skilties id
            inputField.SendKeys("test");
            IWebElement nextButton = chrome.FindElement(By.CssSelector("#login-signin"));  //sukuriamas su kitu kopijavimo tipu css selector ir reikia grotazimiu
            nextButton.Click();
            //chrome.Quit();
        }

        [Test]
        public static void TestFirefox()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://login.yahoo.com/";
            firefox.Manage().Window.Maximize();
            firefox.Quit();
        }

        [Test]
        public static void TestSeleniumFirstInput()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            chrome.Manage().Window.Maximize();

            /*IWebElement inputField = chrome.FindElement(By.Id("login-username"));
            IWebElement nextButton = chrome.FindElement(By.CssSelector("#login-signin"));
            IWebElement nextButton = chrome.FindElement(By.CssSelector("#login-signin"));*/
            //Assert
            //chrome.Quit();

        }
    }
}