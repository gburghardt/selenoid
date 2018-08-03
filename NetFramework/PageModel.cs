using OpenQA.Selenium;
using System;
using System.Linq;

namespace Selenoid
{
    public abstract class PageModel
    {
        protected PageModel(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));

            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);

                foreach (var attribute in attributes)
                {
                    if (attribute is IElementSearchStrategy searchStrategy)
                    {
                        property.SetValue(this, new LazyWebElement(driver, searchStrategy));
                    }
                }
            }
        }

        protected IWebDriver Driver { get; private set; }
    }
}
