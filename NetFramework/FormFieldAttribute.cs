using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenoid
{
    public class FormFieldAttribute : Attribute, IElementSearchStrategy
    {
        public string LabelText { get; private set; }

        public FormFieldAttribute(string labelText)
        {
            if (string.IsNullOrEmpty(labelText))
                throw new ArgumentNullException(nameof(labelText));

            LabelText = labelText;
        }

        public IWebElement FindElement(IWebDriver driver)
        {
            var label = driver.FindElement(By.XPath($"//label[contains(., '{LabelText}')]"));

            throw new NotImplementedException();
        }
    }
}
