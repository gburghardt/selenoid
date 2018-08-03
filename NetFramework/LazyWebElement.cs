using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace Selenoid
{
    class LazyWebElement : IWebElement
    {
        public LazyWebElement(IWebDriver driver, IElementSearchStrategy searchStrategy)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.searchStrategy = searchStrategy ?? throw new ArgumentNullException(nameof(searchStrategy));
        }

        private readonly IWebDriver driver;
        private readonly IElementSearchStrategy searchStrategy;

        private IWebElement wrappedElement;

        public IWebElement WrappedElement
        {
            get
            {
                if (wrappedElement == null)
                {
                    wrappedElement = searchStrategy.FindElement(driver);
                }

                return wrappedElement;
            }
        }

        public string TagName => WrappedElement.TagName;

        public string Text => WrappedElement.Text;

        public bool Enabled => WrappedElement.Enabled;

        public bool Selected => WrappedElement.Selected;

        public Point Location => WrappedElement.Location;

        public Size Size => WrappedElement.Size;

        public bool Displayed => WrappedElement.Displayed;

        public void Clear()
        {
            WrappedElement.Clear();
        }

        public void Click()
        {
            WrappedElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            return WrappedElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return WrappedElement.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return WrappedElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return WrappedElement.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            return WrappedElement.GetProperty(propertyName);
        }

        public void SendKeys(string text)
        {
            WrappedElement.SendKeys(text);
        }

        public void Submit()
        {
            WrappedElement.Submit();
        }
    }
}