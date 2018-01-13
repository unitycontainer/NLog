[![License](https://img.shields.io/badge/license-apache%202.0-60C060.svg)](https://github.com/IoC-Unity/NLog/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.NLog.svg)](https://www.nuget.org/packages/Unity.NLog)
[![NuGet](https://img.shields.io/nuget/v/Unity.NLog.svg)](https://www.nuget.org/packages/Unity.NLog)


# NLog adapter for Unity container
Unity extension to integrate with popular [NLog](https://github.com/nlog/nlog) logger.

## Getting Started
- Reference the `Unity.NLog ` package from NuGet.
```
Install-Package Unity.NLog 
```

## Registration:
- Add `NLogExtension` extension to the container

```C#
container = new UnityContainer();
container.AddNewExtension<NLogExtension>();
```
- Where required add `ILog` interface to resolved constructor. 

```C#
public class LoggedType
{
    public LoggedType(ILog log)
    {
    }
  ...
}
```
- Log normally...
