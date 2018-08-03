using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Selenoid.Tests
{
    [TestClass]
    public class PageModelTests
    {
        [TestMethod]
        public void DoesNotRequireElementProperties()
        {
            var mock = new Moq.Mock<IWebDriver>();
            var pageModel = new EmptyPageModel(mock.Object);

            mock.VerifyAll();
        }

        [TestMethod]
        public void AllowsOtherTypesOfProperties()
        {
            var mock = new Moq.Mock<IWebDriver>();
            var pageModel = new EmptyPageModelWithOtherProperties(mock.Object);

            mock.VerifyAll();
        }

        [TestMethod]
        public void IgnoresIWebElementPropertiesWithoutFindByAnnotation()
        {
            var mock = new Moq.Mock<IWebDriver>();
            var pageModel = new WithIWebElementNoFindBy(mock.Object);

            Assert.IsNull(pageModel.Heading);
            mock.VerifyAll();
        }

        [TestMethod]
        public void InitializesElementProperty()
        {
            var mock = new Moq.Mock<IWebDriver>();
            var pageModel = new TestPageModel(mock.Object);

            Assert.IsNotNull(pageModel.Element);
            mock.VerifyAll();
        }
    }

    public class EmptyPageModel : PageModel
    {
        public EmptyPageModel(IWebDriver driver) : base(driver)
        {
        }
    }

    public class EmptyPageModelWithOtherProperties : PageModel
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public EmptyPageModelWithOtherProperties(IWebDriver driver) : base(driver)
        {
        }
    }

    public class WithIWebElementNoFindBy : PageModel
    {
        public IWebElement Heading { get; protected set; }

        public WithIWebElementNoFindBy(IWebDriver driver) : base(driver)
        {
        }
    }

    public class TestPageModel : PageModel
    {
        [FindBy(TagName = "table")]
        public IWebElement Element { get; protected set; }

        public TestPageModel(IWebDriver driver) : base(driver)
        {
        }
    }
}
