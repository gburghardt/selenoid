using OpenQA.Selenium;
using System;

namespace Selenoid
{
    public class FindByAttribute : System.Attribute
    {
        private By findStrategy;

        public By FindStrategy
        {
            get => findStrategy;

            set
            {
                if (findStrategy != null)
                    throw new InvalidOperationException($"Strategy for finding an element has already been set ({typeof(By).FullName})");

                findStrategy = value;
            }
        }

        public string ClassName
        {
            set => FindStrategy = By.ClassName(value);
        }

        public string CssSelector
        {
            set => FindStrategy = By.CssSelector(value);
        }

        public string Id
        {
            set => FindStrategy = By.Id(value);
        }

        public string LinkText
        {
            set => FindStrategy = By.LinkText(value);
        }

        public string Name
        {
            set => FindStrategy = By.Name(value);
        }

        public string PartialLinkText
        {
            set => FindStrategy = By.PartialLinkText(value);
        }

        public string TagName
        {
            set => FindStrategy = By.TagName(value);
        }

        public string XPath
        {
            set => FindStrategy = By.XPath(value);
        }
    }
}