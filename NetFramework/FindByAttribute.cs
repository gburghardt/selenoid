using OpenQA.Selenium;
using System;

namespace Selenoid
{
    public class FindByAttribute : Attribute, IElementSearchStrategy
    {
        private string className;
        private string cssSelector;
        private string id;
        private string linkText;
        private string name;
        private string partialLinkText;
        private string tagName;
        private string xpath;

        private By FindStrategy { get; set; }

        public string ClassName
        {
            get => className;
            set => FindStrategy = By.ClassName(className = value);
        }

        public string CssSelector
        {
            get => cssSelector;
            set => FindStrategy = By.CssSelector(cssSelector = value);
        }

        public string Id
        {
            get => id;
            set => FindStrategy = By.Id(id = value);
        }

        public string LinkText
        {
            get => linkText;
            set => FindStrategy = By.LinkText(linkText = value);
        }

        public string Name
        {
            get => name;
            set => FindStrategy = By.Name(name = value);
        }

        public string PartialLinkText
        {
            get => partialLinkText;
            set => FindStrategy = By.PartialLinkText(partialLinkText = value);
        }

        public string TagName
        {
            get => tagName;
            set => FindStrategy = By.TagName(tagName = value);
        }

        public string XPath
        {
            get => xpath;
            set => FindStrategy = By.XPath(xpath = value);
        }

        public IWebElement FindElement(IWebDriver driver)
        {
            return driver.FindElement(FindStrategy);
        }
    }
}