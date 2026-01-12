using System;
using System.Collections;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestingUdemy
{
	public class SortWebTables
	{
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //driver.Navigate().GoToUrl("");
            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void Test1()
        {
            

            IWebElement DropDown = driver.FindElement(By.Id("page-menu"));
            SelectElement sel = new SelectElement(DropDown);
            sel.SelectByText("20");

            //step 1 - grab all the veggies into one arraylist A
            ArrayList a = new ArrayList();
            IList<IWebElement> UnSortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in UnSortedVeggies)
            {
                a.Add(veggie.Text);
            }
    
            //step 2 - Sort the unsorted list
            a.Sort();
            
            foreach (string ele in a)
            {
                TestContext.Progress.WriteLine(ele);
            }

            //step 3 - Click on column header to sort the list
            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            // step 4 - now after sorting get all veggie name into arraylist B 
            ArrayList b = new ArrayList();
            IList<IWebElement> SortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));
            foreach (IWebElement veggie in SortedVeggies)
            {
                b.Add(veggie.Text);
            }

            // Arraylist A to B = Equals
            Assert.AreEqual(a, b);

        }

        //[TearDown]
        public void TearDown()
        {
            driver.Close();
        }

    }
}

