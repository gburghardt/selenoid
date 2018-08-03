using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenoid
{
    interface IElementSearchStrategy
    {
        IWebElement FindElement(IWebDriver driver);
    }
}
