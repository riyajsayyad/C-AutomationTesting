using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTestingUdemy;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        TestContext.Progress.WriteLine("Setup methods execution");
    }

    [Test]
    public void Test1()
    {
        TestContext.Progress.WriteLine("This is Test 1");
    }
    [Test]
    public void Test2()
    {
        TestContext.Progress.WriteLine("This is Test2");
    }

    [TearDown]
    public void CloseBrowser()
    {
        TestContext.Progress.WriteLine("Tear Down methods execution");
    }
}
