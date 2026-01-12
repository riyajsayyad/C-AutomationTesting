using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestingUdemy
{
	public class ChildWindowHandle
	{
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("");
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void Test_WindowHandle()
        {

            String expectedEmail = "mentor@rahulshettyacademy.com";
            string parentWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
            string childWindow = driver.WindowHandles[1];
            driver.SwitchTo().Window(childWindow);

            string RedText = driver.FindElement(By.CssSelector(".red")).Text;
            TestContext.Progress.WriteLine(RedText);

            // Extract an email - Please email us at mentor@rahulshettyacademy.com with below template to receive response

            string[] splittedText = RedText.Split("at");
            string[] trimmedString = splittedText[1].Trim().Split(" ");
            string actualEmail = trimmedString[0];

            // NUnit does not display messages on success. The message appears only if the assertion fails.
            Assert.That(actualEmail, Is.EqualTo(expectedEmail), $"Email mismatch. Expected: {expectedEmail}, but Actual: {actualEmail}");
            TestContext.WriteLine("Email assertion passed successfully.");
            TestContext.Progress.WriteLine(actualEmail);

            // Switch the parent window and paste that email
            driver.SwitchTo().Window(parentWindow);
            driver.FindElement(By.Id("username")).SendKeys(actualEmail);

            //driver.Quit();
        }
    }
}

