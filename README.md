[![License](https://img.shields.io/badge/license-apache%202.0-60C060.svg)](https://github.com/IoC-Unity/log4net/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)
[![NuGet](https://img.shields.io/nuget/v/Unity.log4net.svg)](https://www.nuget.org/packages/Unity.log4net)


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
