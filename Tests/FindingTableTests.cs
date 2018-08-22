using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenoid.Tests
{
    [TestClass]
    public class FindingTableTests
    {
        private static readonly string webPage = Fixture.GetFullPath("FindingTables.html");
        private ChromeDriver driver;
        private TablePageModel page;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(webPage);
            page = new TablePageModel(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void FindsTablesByCaptionText()
        {
            Assert.IsNotNull(page.Table);
        }

        [TestMethod]
        public void ActuallyFindsTheTable()
        {
            Assert.AreEqual("table", page.Table.TagName);
        }
    }

    public class TablePageModel : PageModel
    {
        public TablePageModel(IWebDriver driver) : base(driver)
        {
        }

        [Table("Test Table")]
        public IWebElement Table { get; protected set; }
    }
}
