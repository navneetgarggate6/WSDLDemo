# WSDLDemo
Its a simple worker application using .net core 3 to consume a wsdl service.

> Need to install svcutil tool

```
dotnet tool install --global dotnet-svcutil
```

> To generate Service Reference

```
dotnet svcutil http://www.dneonline.com/calculator.asmx?WSDL

```

> More details about svcutil

https://docs.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-svcutil-guide?tabs=dotnetsvcutil2x