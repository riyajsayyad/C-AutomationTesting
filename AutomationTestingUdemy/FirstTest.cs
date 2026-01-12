using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestingUdemy
{
	

    public class FirstTest
	{
		IWebDriver driver;

        //[SetUp]
		public void SetUp()
		{
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--incognito");

            driver = new ChromeDriver();
			//driver.Navigate().GoToUrl("");
			driver.Manage().Window.Maximize();
			driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
		}

		[Test]
		public void Test1()
		{
			TestContext.Progress.WriteLine("This is the titile of page :" + driver.Title);
			TestContext.Progress.WriteLine("This is the URL : " + driver.Url);
		}

		//[TearDown]
		public void TearDown()
		{
			driver.Close();
		}
	}
}

