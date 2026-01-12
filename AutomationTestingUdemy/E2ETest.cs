using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestingUdemy
{
	public class E2ETest
	{
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");


            driver = new ChromeDriver(options);
            //driver.Navigate().GoToUrl("");
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void Test1()
        {
            

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");


            //Click on one of the radio button
            IList<IWebElement> radios = driver.FindElements(By.CssSelector("[type='radio']"));
            foreach (IWebElement radioButton in radios)
            {
                if (radioButton.GetAttribute("value").Equals("user"))
                {
                    radioButton.Click();
                }
            }

            // Handle the popup
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();


            // Select the dropdown
            IWebElement DropDown = driver.FindElement(By.XPath("//select[@class='form-control']"));
            SelectElement select = new SelectElement(DropDown);
            select.SelectByValue("consult");

            // Click on teams and condition checkbox
            driver.FindElement(By.Id("terms")).Click();

            //Click on signin button
            IWebElement SignInBtn = driver.FindElement(By.Id("signInBtn"));
            SignInBtn.Click();

            // Verify that the Checkout button is visible
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));


            // get the list of cards
            String[] expectedProd = { "iphone X", "Blackberry" };

            // Create a new array for storing the element from cart
            String[] actualProd = new string[2];


            foreach (string item in expectedProd)
            {
                // Get the all the list of products
                IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

                foreach (IWebElement product in products)
                {
                    string title = product
                        .FindElement(By.CssSelector(".card-title a")).Text;

                    if (title.Equals(item))
                    {
                        product
                            .FindElement(By.CssSelector(".card-footer button"))
                            .Click();
                        break;
                    }
                }
            }
            //Click on checkout button
            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            //TestContext.Progress.WriteLine(ProdTitle.Text);


            // Get the all cart items and compare with expected items.
            IList<IWebElement> checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for(int i = 0; i < checkoutCards.Count; i++)
            {
                actualProd[i] = checkoutCards[i].Text;
            }
            Assert.That(actualProd, Is.EqualTo(expectedProd));

            driver.Quit();

        }
    }
}

