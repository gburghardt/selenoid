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
                        if (!property.CanWrite)
                            throw new InvalidOperationException($"Cannot set property {property.Name} of type {GetType().FullName}. Make sure it is a protected set.");

                        if (property.PropertyType != typeof(IWebElement))
                            throw new InvalidOperationException($"Cannot set property {property.Name} of type {GetType().FullName}. Make sure its declaring type is {typeof(IWebElement).FullName}");

                        property.SetValue(this, new LazyWebElement(driver, searchStrategy));
                    }
                }
            }
        }

        protected IWebDriver Driver { get; private set; }
    }
}
