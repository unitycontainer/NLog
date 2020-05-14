[![Build status](https://ci.appveyor.com/api/projects/status/tr7ykk0g5jgieon2/branch/v5.x?svg=true)](https://ci.appveyor.com/project/unitycontainer/nlog-9y7y3/branch/v5.x)
[![License](https://img.shields.io/badge/license-apache%202.0-60C060.svg)](https://github.com/IoC-Unity/NLog/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.NLog.svg)](https://www.nuget.org/packages/Unity.NLog)
[![NuGet](https://img.shields.io/nuget/v/Unity.NLog.svg)](https://www.nuget.org/packages/Unity.NLog)

# NLog adapter for Unity container

Unity extension to integrate with popular [NLog](https://github.com/nlog/nlog) logger.

## Getting Started

- Reference the `Unity.NLog` package from NuGet.

```shell
Install-Package Unity.NLog
```

## Registration:

- Add `NLogExtension` extension to the container

```C#
container = new UnityContainer();
container.AddNewExtension<NLogExtension>();
```

- Where required add `ILogger` interface to resolved constructor. 

```C#
public class LoggedType
{
    public LoggedType(ILogger log)
    {
    }
  ...
}
```

- If you want to custom the extension (In this case, get only the class name instead of the full name), you have to 
instantiate NLogExtension to set properties and add this extension to Unity

```C#
var ext = new NLogExtension{
    GetName = (t, n) => t.Name
};
container.AddExtension(ext);
```

- Log normally...

## Code of Conduct

This project has adopted the code of conduct defined by the [Contributor Covenant](https://www.contributor-covenant.org/) to clarify expected behavior in our community. For more information, see the [.NET Foundation Code of Conduct](https://www.dotnetfoundation.org/code-of-conduct)

## Contributing

See the [Contributing guide](https://github.com/unitycontainer/unity/blob/master/CONTRIBUTING.md) for more information.

## .NET Foundation

Unity Container is a [.NET Foundation](https://dotnetfoundation.org/projects/unitycontainer) project
