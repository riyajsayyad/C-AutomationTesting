using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestingUdemy
{
	public class Locators
	{

        IWebDriver driver;


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("");
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void Test1()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("larning");
            IList<IWebElement> radios = driver.FindElements(By.CssSelector("[type='radio']"));
            foreach(IWebElement radioButton in radios)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
            }

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();

            IWebElement DropDown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement select = new SelectElement(DropDown);
            select.SelectByValue("consult");

            driver.FindElement(By.Id("terms")).Click();
            IWebElement SignInBtn = driver.FindElement(By.Id("signInBtn"));
            SignInBtn.Click();

            //Thread.Sleep(3000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(SignInBtn, "Sign In"));

            string ErrorText = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(ErrorText);

            IWebElement LinkText = driver.FindElement(By.PartialLinkText("Free Access to"));
            string? ActualResult = LinkText.GetAttribute("href");
            string ExpectedResult = "https://rahulshettyacademy.com/documents-request";

            Assert.AreEqual(ExpectedResult, ActualResult);


        }

        //[TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}

