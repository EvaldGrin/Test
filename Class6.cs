/*Paskaitos metu
 * 2022-02-28
 * */
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotest
{
    internal class Class6
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo.seleniumeasy.com/basic-checkbox-demo.html";
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [Test]
        public static void TestOneCheckbox()
        {
            IWebElement checkbox = driver.FindElement(By.Id("isAgeSelected")); //susiradome chackboxa
            IWebElement resultElement = driver.FindElement(By.Id("txtAge")); //susiradome texta kuti tikrinsime
            if (!checkbox.Selected)  // geroji praktika - jeigu checkbox nepazymetas, tai ji pazymiu, o jeigu pazymetas, tai nepatnku i if ir einama toliau 
            {
                checkbox.Click();
            }
            ClickOnCheckbox(true);
            Assert.IsTrue("Success - Check box is checked".Equals(resultElement.Text), $"Text is not the same text is " +
                $"{resultElement.Text}");
            /*Assert.AreEqual("Success - Check bo is checked", resultElement.Text, $"Text is not the same text is " +
                $"{resultElement.Text}");*/
        }

        [Test]
        public static void TestManyCheckboxes()
        {
            ClickOnCheckbox(false);

            IWebElement firstcheckbox = driver.FindElement(By.Id("isAgeSelected")); //atzymimas check boxas, jegu buna pazymetas
            if (firstcheckbox.Selected)
            {
                firstcheckbox.Click();
            }

            IReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector(".cb1-element")); // sukuriame checkbox kolekcija
            foreach (IWebElement checkbox in checkboxes) //einam per kiekviena checkboxa zymedami
            {
                checkbox.Click();
            }
            IWebElement button = driver.FindElement(By.Id("check1"));
            //IWebElement button = driver.FindElement(By.Id("#check1"));
            Assert.IsTrue(button.GetAttribute("value").Equals("Uncheck All"), "Text is not correct"); //patikrino mygtuka ar jo reiksme "Uncheck All" gera
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")), "Text is not correct");
        }

        private static void ClickOnCheckbox(bool shouldBeCheck)
        {
            IWebElement firstcheckbox = driver.FindElement(By.Id("isAgeSelected")); //atzymimas check boxas, jegu buna pazymetas
            if (firstcheckbox.Selected != shouldBeCheck) //man reikia zymeti tada, kai man nesutampa ka as turiu puslapyje ir ko noriu
            {
                firstcheckbox.Click();
            }



            /*Pvz: kaip galima rasant if patikrinti bool ar jeigu pazymeta reikia atzymet, ar jeigu nepazymeta - pazymeti

            if (firstcheckbox.Selected //true
                                       && shouldBeCheck) //true

                if (firstcheckbox.Selected //false
                                           && shouldBeCheck) //false

                    if (firstcheckbox.Selected //false  (nepazymetas ir norim pazymeti)
                                               && shouldBeCheck) //true -> click (tada paspaudziame)

                        if (firstcheckbox.Selected //true (jeigu pazymetas tada norime nuzymeti)
                                                   && shouldBeCheck)//false -> click (tada spaudziame)*/

        }

        [Test]
        public static void UncheckAll()
        {
            ClickOnCheckbox(false);
            IWebElement button = driver.FindElement(By.Id("check1"));
            IReadOnlyCollection<IWebElement> checkboxes = driver.FindElements(By.CssSelector(".cb1 - element"));
            if (!IsButtonWithValue(button, "Uncheck All"))
            {
                CheckAllCheckboxes(checkboxes);
            }
            button.Click();
            
            foreach (IWebElement checkbox in checkboxes)
            {
                Assert.IsTrue(!checkbox.Selected);
            }
            Assert.IsTrue(IsButtonWithValue(button, "Check All"), "Text not correct");
        }


        private static bool IsButtonWithValue(IWebElement button, string value)
        {
            return value.Equals(button.GetAttribute("value"));
        }

        private static void CheckAllCheckboxes(IReadOnlyCollection<IWebElement> checkboxes)
        {
            foreach (IWebElement checkbox in checkboxes)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }


    }
}
