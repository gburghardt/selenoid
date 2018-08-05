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
            var xpathForDescendantField = $"//label[contains(., '{LabelText}')]//[self::input or self::textarea or self::select]";
            var xpathForAssociatedField = $"//label[contains(., '{LabelText}')][@for]";
            var xpath = $"({xpathForDescendantField}) or ({xpathForAssociatedField})";
            var labelOrField = driver.FindElement(By.XPath(xpath));

            if (labelOrField.TagName == "label")
            {
                var associatedFieldId = labelOrField.GetAttribute("for");

                return driver.FindElement(By.Id(associatedFieldId));
            }

            return labelOrField;
        }
    }
}
