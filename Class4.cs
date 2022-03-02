/*2022-02-28
 *1 Namu darbai
 **/
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Autotest
{
    internal class Class4
    {
        [Test]

        public static void TestCrome()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chrome.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10)); //Explicit wait-laukia konkretaus elemento
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed); //sita salyga laukia kol pasirodys elementas kuri norima uzdaryti
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click(); //kai tik elementas pasirodo, ji uzdaromas sia komanda

            IWebElement inputField = chrome.FindElement(By.Id("sum1"));
            inputField.SendKeys("2");
            
            //Thread.Sleep(1000);

            //IWebElement popupclose = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            //popupclose.Click();

            IWebElement inputField2 = chrome.FindElement(By.CssSelector("#sum2"));
            inputField2.SendKeys("2");

            IWebElement GetTotal = chrome.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            int sum = 2 + 2;
            string sum1 = Convert.ToString(sum);
            Assert.AreEqual(sum1, result.Text, "blogas atsakymas");
            chrome.Quit();
        }

        [Test]

        public static void TestCrome2()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chrome.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10)); //Explicit wait-laukia konkretaus elemento
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed); //sita salyga laukia kol pasirodys elementas kuri norima uzdaryti
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click(); //kai tik elementas pasirodo, ji uzdaromas sia komanda

            IWebElement inputField = chrome.FindElement(By.Id("sum1"));
            inputField.SendKeys("-5");
            
            //Thread.Sleep(1000);

            //IWebElement popupclose = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            //popupclose.Click();

            IWebElement inputField2 = chrome.FindElement(By.CssSelector("#sum2"));
            inputField2.SendKeys("3");

            IWebElement GetTotal = chrome.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            int sum = -5 + 3;
            string sum1 = Convert.ToString(sum);
            Assert.AreEqual(sum1, result.Text, "blogas atsakymas");
            chrome.Quit();
        }

        [Test]

        public static void TestCrome3()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            chrome.Manage().Window.Maximize();

            WebDriverWait wait = new WebDriverWait(chrome, TimeSpan.FromSeconds(10)); //Explicit wait-laukia konkretaus elemento
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed); //sita salyga laukia kol pasirodys elementas kuri norima uzdaryti
            chrome.FindElement(By.Id("at-cv-lightbox-close")).Click(); //kai tik elementas pasirodo, ji uzdaromas sia komanda

            IWebElement inputField = chrome.FindElement(By.Id("sum1"));
            inputField.SendKeys("a");

            //Thread.Sleep(1000);

            //IWebElement popupclose = chrome.FindElement(By.Id("at-cv-lightbox-close"));
            //popupclose.Click();

            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            inputField2.SendKeys("b");

            IWebElement GetTotal = chrome.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            string ats = "NaN";
            Assert.AreEqual(ats, result.Text, "Klaidingas atsakymas");
            chrome.Quit();
        }
    }
}
