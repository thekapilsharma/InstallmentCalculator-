# CSharp Project

## Requirements
```
Visual Studio Code
Dotnet SDK 6.0
```

## Install
```
cd Zip.InstallmentsApi
dotnet restore
```

## Quick Start
```
cd Zip.InstallmentsApi
dotnet run
```

## Run Tests
```
cd Zip.InstallmentsService
dotnet test Zip.InstallmentsService.sln
```



# Zip Software Engineer Interview

## Overview

This application has services for Zip Software to calculate installments for purchase amount based on Frequency Type ex: Monthaly and Daly basis. This solution has multiple projects:

- Web API with Swager documentation
- Services to calculate installments
- Entity to store in databse
- Models to represent entity to UI
- Cotracts for services
- Test project for unit test


## Exception Handling
Middleware is configured for global exception handling in .NET 6 program.cs

## HTTP Response Code

Multiple response code return based on request type. Exception can be logged from one place in application

