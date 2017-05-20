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
    public class OlxLoginCmnt
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.olx.ba/";
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
        public void TheOlxLoginCmntTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("searchinput")).Clear();
            driver.FindElement(By.Id("searchinput")).SendKeys("mercedes");
            driver.FindElement(By.CssSelector("button.btn.btn-mainsearch")).Click();
            driver.FindElement(By.CssSelector("#art_25562332 > div.naslov > a > p.na")).Click();
            driver.FindElement(By.Id("pitanja_btn")).Click();
            driver.FindElement(By.Id("loginbtn")).Click();
            driver.FindElement(By.Id("btnlogin1")).Click();
            driver.FindElement(By.Id("searchinput")).Clear();
            driver.FindElement(By.Id("searchinput")).SendKeys("mercedes");
            driver.FindElement(By.CssSelector("button.btn.btn-mainsearch")).Click();
            driver.FindElement(By.CssSelector("#art_25562332 > div.naslov > a > p.na")).Click();
            Assert.AreEqual("", driver.FindElement(By.Id("pitanje_tekst")).Text);
            Assert.AreEqual("", driver.FindElement(By.Id("pitanje_tekst")).Text);
            Boolean predobar = IsElementPresent(By.Id("pitanje_tekst"));
            driver.FindElement(By.CssSelector("#pitanja_btn > span.brojpitanja")).Click();
            driver.FindElement(By.Id("pitanje_tekst")).Clear();
            driver.FindElement(By.Id("pitanje_tekst")).SendKeys("predobar");
            driver.FindElement(By.LinkText("Postavi pitanje!")).Click();
            driver.FindElement(By.Id("piklogo")).Click();
            driver.FindElement(By.Id("u_h")).Click();
            driver.FindElement(By.LinkText("Odjavite se")).Click();
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
