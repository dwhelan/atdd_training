# Installing Web Drivers


### Firefox
More recent versions of Firefox (e.g. v48) are incompatible with the selenium
drivers used with `coypu`. So you will need to install an earlier version
of Firefox such as v35. You can download Firebox v35 from [here](https://ftp.mozilla.org/pub/firefox/releases/35.0.1/win32/en-US/). Download `Firefox Setup 35.0.1.exe` and run it.

### Chrome
You will need to download the lastest chrome driver from
[here](http://chromedriver.storage.googleapis.com/index.html?path=2.23/).
Download the `chromedriver_win32.zip` file copy the `chromedriver.exe` file to a folder in your path.

### Phantomjs
The phantomjs driver should already be included via NuGet. If you need to add it for VS 2015, it can be installed via the 
`Tools` | `NuGet Package Manager` | `Manage NuGet Packages for Solution`.

For VS 2013, run `Tools` | `NuGet Package Manager` | `Packages Manager Console` and enter the following:

```
PM> Install-Package phantomjs
```

### Internet Explorer with WatiN
If you get an error like

```
System.IO.FileNotFoundException : Could not load file or assembly 'Interop.SHDocVw, Version=1.1.0.0, Culture=neutral, PublicKeyToken=db7cfd3acb5ad44e' or one of its dependencies. The system cannot find the file specified.
```

... then you should find the `InteropSHDocVw` reference in your project, view its properties
and change `Embed Interop Types` to `false`.

If you get an error like

```
System.Threading.ThreadStateException : The CurrentThread needs to have it's ApartmentState set to ApartmentState.STA to be able to automate Internet Explorer.
```

... then make sure that you add the `RequiresSTA` attribute for all tests like:

```
[TestFixture, RequiresSTA]
```

or on specific tests like this:
```
[Test, RequiresSTA]
```


### Others
Check out [selenium downloads](http://www.seleniumhq.org/download/) for other drivers or updates.

