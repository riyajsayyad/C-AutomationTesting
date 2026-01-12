using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace AutomationTestingUdemy
{
	public class AlertAction
	{
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            //driver.Navigate().GoToUrl("");
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }

        [Test]
        public void Test_Alert()
        {
            string name = "Riyaz";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick='displayConfirm()']")).Click();
            string alertText = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();

            
            StringAssert.Contains(name, alertText);

        }

        [Test]
        public void Test_AutoSuggestiveDropDown()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            IList<IWebElement> matchingCountries = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach(IWebElement ele in matchingCountries)
            {
                if (ele.Text.Equals("India"))
                {
                    ele.Click();
                }
            }


            // Get the entered text from textbox
            string enterdText = driver.FindElement(By.Id("autocomplete")).GetAttribute("value");
            TestContext.Progress.WriteLine(enterdText);
        }

        [Test]
        public void Test_Actions()
        {
            driver.Url = "https://www.flipkart.com/";
            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.CssSelector("[title='Login']"))).Perform();
            driver.FindElement(By.CssSelector("[title='My Profile'] li")).Click();
        }

        [Test]
        public void Frame()
        {
            //scroll to the specific frame or element
            IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameScroll);

            // id, name, index - switch into the frame and perform action on that
            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.XPath("(//a[@href='lifetime-access'])[2]")).Click();
        }

        //[TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}

