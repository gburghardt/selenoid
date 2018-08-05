# Selenoid

Dead simple page objects for Selenium .NET

## Getting Started

After importing this into your test project, start creating your own page object classes using the `Selenoid.PageModel` class:

```csharp
public class PersonForm : Selenoid.PageModel
{
    [FindBy(Id = "Person_FirstName")]
    public IWebElement FirstName { get; protected set;}

    [FormField("Last Name")]
    public IWebElement LastName { get; protected set; }

    public PersonForm(IWebDriver driver) : base(driver)
    {
    }

    public void Edit(string firstName, string lastName)
    {
        FirstName.Clear();
        FirstName.SendKeys(firstName);
        LastName.Clear();
        LastName.SendKeys(firstName);
    }
}
```

Then start using it:

```csharp
var personForm = new PersonForm(driver);

personForm.Edit("John", "Doe");
```