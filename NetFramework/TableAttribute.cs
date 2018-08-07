using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenoid
{
    public class TableAttribute : Attribute, IElementSearchStrategy
    {
        public string Caption { get; private set; }

        public TableAttribute(string caption)
        {
            if (string.IsNullOrEmpty(caption))
                throw new ArgumentNullException(nameof(caption));

            Caption = caption;
        }

        public IWebElement FindElement(IWebDriver driver)
        {
            return driver.FindElement(By.XPath($"//table/caption[contains(., '{Caption}')]/.."));
        }
    }
}
