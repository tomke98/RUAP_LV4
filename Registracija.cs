using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Registracija
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheRegistracijaTest()
        {
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/?logout=1");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Order online at your favourite artisan'])[1]/preceding::a[1]")).Click();
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/register");
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys("to3953mimadjare3qwevic@gmail.com");
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Tomislav");
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Miskovic");
            driver.FindElement(By.Name("password")).Click();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("kornjace");
            driver.FindElement(By.Name("password-repeat")).Click();
            driver.FindElement(By.Name("password-repeat")).Clear();
            driver.FindElement(By.Name("password-repeat")).SendKeys("kornjace");
            driver.FindElement(By.Name("telephone")).Click();
            driver.FindElement(By.Name("telephone")).Clear();
            driver.FindElement(By.Name("telephone")).SendKeys("+385995178119");
            driver.FindElement(By.XPath("//div[@id='app']/main/div/section/div/footer")).Click();
            driver.FindElement(By.XPath("//button[@name='']")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
            driver.FindElement(By.XPath("//div[@id='app']/main/div[2]/div/div/div[2]/button")).Click();
            driver.Navigate().GoToUrl("https://bakeronline.be/be-en/");
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
