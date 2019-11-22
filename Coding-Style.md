# Coding Style Guidelines

To ensure that all engineers are productive in every application we design on IPA 5.0 we must adhere to a long list of coding style guidelines. This ensures consistency while switching between projects and will make it easy for everyone to get up to speed fast regardless of whether or not they've ever seen a project.

Project linting will also be a requirement, so be sure to adhere to the following guidelines to ensure that your pull request gets reviewed in a timely manner. To achieve this we will be using [**Code Formatter**](https://github.com/dotnet/codeformatter) during the pre-build process.

We are also going to use [**Editor Config**](https://editorconfig.org/) to help with auto formatting of our project files.

* All internal class fields should be **camelCased** and should have an accessor of **private** or **internal** specified.

* The usage of **this** is restricted to only the constructor or method when you have an obvious scoping conflict. No other usage of the **this** keyword is acceptable. See the example below:

```csharp
internal class Vector3 
{
    private readonly float x;
    private readonly float y;
    private readonly float z;

    internal Vector3(float x, float y, float y) 
    {
        // The following usage of "this" is acceptable to properly distinguish between class fields and local fields.
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void CalculateSomethingElse(int product) 
    {
        // This usage "this" is not acceptable because it conflicts with no locally scoped fields.
        this.x = (product * Math.PI) / 180;
    }
}
```

* Visibility of a field, method or class must always be specified for completeness.

```csharp
internal class Vector3
{
    readonly float x; // <-- bad
    private readonly float y; // <-- good
}
```

* Be mindful of your spacing and do not leave unnecessary spacing between code statements. For example:

```csharp
public void DoSomething()
{
    // BAD
    int results = 0;
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("....");



        // Too much spacing here ^^^
        results += ((i + 10) >> 1)
    }

    // GOOD
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("...");

        // This is adequate spacing and makes the code cleaner.
        results += ((i + 10) >> 1);
    }
}
```

* If there is existing code that was created prior to this style guide and it has a certain pattern in place, you **must** follow that pattern. Only new code or agreed upon refactorings must follow our style guide.

* The usage of **var** should be limited to obvious types or complex generic types. This is C#, not JavaScript and we must ensure that we are not abusing the keyword out of lazyness :).

* Please take advantage of **nameof(type)** when possible instead of typing out the parameter name. This is useful when you want the name of the parameter to pass to an exception class.

```csharp
public void DoSomething(int number) 
{
    // GOOD
    if (number <= 0) 
        throw new ArgumentException(nameof(number), "Cannot be less than or equal to zero.");

    // BAD
    if (number <= 0)
        throw new ArgumentException("number", "Cannot be less than or equal to zero.");
}
```

* No usage of BCL classes are allowed (Int32, Int64, String, Single). Prefer the usage CLR keyword types as the standard.

* Class accessisble fields should be declared at the top of a class and not at the bottom or anywhere else in the class to make it easy for engineers to find all field declarations quickly.

* No usage of the **goto** statement is allowed in the codebase.

* Pascal Casing is the preferred approach when defining a class and any methods.

* Camel Casing is the preferred approach for method arguments.

* No Hungarian notation should be used in our code base. Microsoft used this a lot in their original C API for Windows and it still lives in there for backwards compatibility. However, new code being developed is moving away from that practice. For more information please [**Click Here**](http://web.mst.edu/~cpp/common/hungarian.html) to learn more about what Hungarian Notation is.

* Constants should not be declared in all uppercase. 

```csharp
// GOOD
public const string Mp3FileExt = ".mp3";

// BAD
public const string MP3_FILE_EXT = ".mp3";
```

* Ensure that variable names are meaningful and can be easily understood by first glance.

* No abbreviations should be used when declaring variable names.

* Ensure that you create separate class files and do not embed inner classes unless the class is directly tied to the structure of privately run methods.

* Enumerations should have singular names but **Flags** should always be plural.

```csharp
public enum Color {
    Red,
    Green,
    Blue
}

[Flags]
public enum Colors {
    Red, 
    Gree,
    Blue
}
```

* Suffix your class names appropriately if they are derived from a .NET type other than object at the first level hierarchy.

```csharp
// ALL OF THE FOLLOWING ARE GREAT :)
public class DeviceEventArguments : EventArgs { ... }

public delegate void DeviceChipReadEventHandler(object sender, DeviceEventArguments e);

public class IPADeviceException : Exception { ... }
```

# Revisions

More coding style guidelines will be added on a regular basis as the project evolves. If you believe there are some good guidelines that aren't covered in this guide then be sure to open a discussion on it prior to making changes and opening a pull request.