
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
    internal class Class5
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-first-form-demo.html";
            driver.Manage().Window.Maximize();
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); //Explicit wait-laukia konkretaus elemento
            wait.Until(d => d.FindElement(By.Id("at-cv-lightbox-close")).Displayed); //sita salyga laukia kol pasirodys elementas kuri norima uzdaryti
            driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]

        public static void TestCrome()
        {
            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            inputField.SendKeys("2");          
            IWebElement inputField2 = driver.FindElement(By.CssSelector("#sum2"));
            inputField2.Clear();
            inputField2.SendKeys("2");

            IWebElement GetTotal = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = driver.FindElement(By.Id("displayvalue"));
            int sum = 2 + 2;
            string sum1 = Convert.ToString(sum);
            Assert.AreEqual(sum1, result.Text, "blogas atsakymas");            
        }

        [Test]
        public static void TestCrome2()
        {
            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            inputField.SendKeys("-5");

            IWebElement inputField2 = driver.FindElement(By.CssSelector("#sum2"));
            inputField2.Clear();
            inputField2.SendKeys("3");

            IWebElement GetTotal = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = driver.FindElement(By.Id("displayvalue"));
            int sum = -5 + 3;
            string sum1 = Convert.ToString(sum);
            Assert.AreEqual(sum1, result.Text, "blogas atsakymas");           
        }

        [Test]

        public static void TestCrome3()
        {
            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            inputField.SendKeys("a");

            IWebElement inputField2 = driver.FindElement(By.Id("sum2"));
            inputField2.Clear();
            inputField2.SendKeys("b");

            IWebElement GetTotal = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement result = driver.FindElement(By.Id("displayvalue"));
            string ats = "NaN";
            Assert.AreEqual(ats, result.Text, "Klaidingas atsakymas");           
        }
        //--------------------------------------------------------------------------------------------------

        //Kitas budas, kai nereikia kartoti kodo

        [TestCase("2", "2", "4", TestName = "2+2=4")]
        [TestCase("-5", "3", "-2", TestName = "-5+3=-2")]
        [TestCase("a", "b", "NaN", TestName = "a+b=NaN")]

        public static void TestSuma(string firstParam, string secondParam, string sumResult) //(2, 2, 4)
        {
            IWebElement inputField = driver.FindElement(By.Id("sum1"));
            inputField.Clear();
            inputField.SendKeys(firstParam); //priima tik string tipa
            IWebElement inputField2 = driver.FindElement(By.CssSelector("#sum2"));
            inputField2.Clear();
            inputField2.SendKeys(secondParam);

            IWebElement GetTotal = driver.FindElement(By.CssSelector("#gettotal > button"));
            GetTotal.Click();

            IWebElement resultFromPage = driver.FindElement(By.Id("displayvalue"));
            int sum = 2 + 2;
            string sum1 = Convert.ToString(sum);
            Assert.AreEqual(sumResult, resultFromPage.Text, "blogas atsakymas");
        }       
    }
}
