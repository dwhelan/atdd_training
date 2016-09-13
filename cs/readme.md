# `C#`

Training exercises and katas in C#. There is a single `katas.sln` created with separate folders and namespaces for each kata.

The solution is targeted for .NET 4.0 and will work with Visual Studio 2013 or 2015.

Acceptance tests use [SpecFlow](http://www.specflow.org/) `v1.9.0` with
[NUnit](http://www.nunit.org/) `v3.0.0`.
## Getting started
All dependencies are resolved using NuGet.

For VS 2015, these `SpecFlow` and `NUnit` can be installed via the 
`Tools` | `NuGet Package Manager` | `Manage NuGet Packages for Solution`.

For VS 2013, run `Tools` | `NuGet Package Manager` | `Packages Manager Console` and enter the following:

```
PM> Install-Package NUnit -Version 3.0.0
PM> Install-Package SpecFlow -Version 1.9.0
```
`SpecFlow for Visual Studio 201x` is required for Visual Studio to recognize SpecFlow feature files and also
provides runtime abilities. Please install via the `Tools | Extensions and Updates` menu option.

## Additional tools
The following tools are not required but are recommended.

### ReSharper
ReSharper is recommended due to its excellent refactoring and unit test support.
If you don't have ReSharper installed you can download a 30 day trial version [here](https://www.jetbrains.com/resharper/download/).

### Markdown support
Markdown support is not built into Visual Studio. To enable better viewing of the kata descriptions
you may want to install the
[Markdown Editor](https://visualstudiogallery.msdn.microsoft.com/eaab33c3-437b-4918-8354-872dfe5d1bfe)
plugin. You can install it with the `Tools | Extensions and Updates` menu option.