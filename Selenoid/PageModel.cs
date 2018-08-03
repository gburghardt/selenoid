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
                var findBy = (FindByAttribute)property.GetCustomAttributes(typeof(FindByAttribute), true).FirstOrDefault();

                if (findBy == null)
                    // Skip properties that are not annotated with the `FindBy` attribute
                    continue;

                if (!property.CanWrite)
                    throw new InvalidOperationException($"Unable to set element property {GetType().FullName}.{property.Name}. Make sure theis property is marked virtual and has a protected setter.");

                if (property.PropertyType != typeof(IWebElement))
                    throw new InvalidOperationException($"Element property {GetType().FullName}.{property.Name} must be of type {typeof(IWebElement).FullName}");

                property.SetValue(this, new LazyWebElement(driver, findBy));
            }
        }

        protected IWebDriver Driver { get; private set; }
    }
}
