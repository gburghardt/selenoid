using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenoid.Tests
{
    [TestClass]
    public class FindingFormFieldTests
    {
        private static readonly string webPage = Fixture.GetFullPath("FindingFormFields.html");
        private FindingFormFieldsPageModel form;
        private ChromeDriver driver;

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(webPage);
            form = new FindingFormFieldsPageModel(driver);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void FindsDescendantField_TextOccursAfterField()
        {
            Assert.AreEqual("input", form.DescendantFieldAfter.TagName);
        }

        [TestMethod]
        public void FindsDescendantField_TextOccursBeforeField()
        {
            Assert.AreEqual("input", form.DescendantFieldBefore.TagName);
        }

        [TestMethod]
        public void FindsDescendantTextarea()
        {
            Assert.AreEqual("textarea", form.DescendantTextarea.TagName);
        }

        [TestMethod]
        public void FindsDescendantSelect()
        {
            Assert.AreEqual("select", form.DescendantSelect.TagName);
        }

        [TestMethod]
        public void FindsAssociatedField()
        {
            Assert.AreEqual("input", form.AssociatedTextField.TagName);
        }
    }

    public class FindingFormFieldsPageModel : PageModel
    {
        public FindingFormFieldsPageModel(IWebDriver driver) : base(driver)
        {
        }

        [FormField("Textfield After")]
        public IWebElement DescendantFieldAfter { get; protected set; }

        [FormField("Textfield Before")]
        public IWebElement DescendantFieldBefore { get; protected set; }

        [FormField("Textarea Inside")]
        public IWebElement DescendantTextarea { get; protected set; }

        [FormField("Select Box Inside")]
        public IWebElement DescendantSelect { get; protected set; }

        [FormField("Associated Text Field")]
        public IWebElement AssociatedTextField { get; protected set; }
    }
}
