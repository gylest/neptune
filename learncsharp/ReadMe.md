# learncsharp Solution

This solution contains multiple C# projects demonstrating various features, including basic programming concepts, data import, and unit testing with xUnit.  

This solution uses `dotnet` commands for package management, tool management, building and testing.  

## Projects

### 1. learncsharp.Dev

- **Type:** Console Application
- **Description:** Main project demonstrating basic C# features, data import, and record types.
- **Key Files:**
  - `Algorithm.cs`: LeetCode problem solutions.
  - `BasicFeatures.cs`: Contains utility methods and record demonstrations.
  - `ControlPatterns.cs`: Patterns used with switch expressions.
  - `DataImport.cs`: Handles importing data from JSON files.
  - `Person.cs`: Defines the Person class used for data import.
  - `Program.cs`: Entry point, runs demos and imports data.

- **Packages:**
  - `Newtonsoft.Json`

### 2. learncsharp.Tests

- **Type:** xUnit Test Project
- **Description:** Contains unit tests for the main project, using the xUnit framework.
- **Key Files:**
  - `AlgorithmTests.cs`: Unit tests for methods in `Algorithm`.
  - `BasicfeaturesTests.cs`: Unit tests for methods in `BasicFeatures`.
  - `ControlPatternsTests.cs`: Unit tests for methods in `ControlPatterns`.
- **Packages:**
  - `xunit`, `xunit.runner.visualstudio`, `Microsoft.NET.Test.Sdk`, `coverlet.collector`
- **Notes:**
  - To view code coverage report open file `coverage-report/index.html` with Live Server

## Build and Test Commands

| Command | Description |
| --- | --- |
| `dotnet list package`|List all NuGet packages in project|
| `dotnet list package --outdated`|Check for outdated NuGet packages|
| `dotnet add package Newtonsoft.Json --version 13.0.4`|Update a package|
| `dotnet clean`|Clean solution|
| `dotnet build`|Build solution|
| `dotnet test`|Run tests|
| `dotnet test --logger "console;verbosity=detailed"`|Run tests with detailed logging|
| `dotnet test --collect:"XPlat Code Coverage"`|Generate code coverage XML file for .NET and xUnit|
| `dotnet tool install -g dotnet-reportgenerator-globaltool`|Install report generator tool|
| `dotnet tool list -g`|Check .NET tools installed|

## Report Generator Commands

Convert XML code coverage report into HTML report:  

```cmd
reportgenerator -reports:"**\TestResults\**\coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html
```  

## How to Debug

Use the provided `launch.json` configuration for .NET debugging in VS Code. Make sure each project builds an executable and is referenced in the solution.

## Notes

- Each project is in its own subfolder for clarity and to avoid build issues.
- Data files (e.g., `person_jd.json`) should be placed in the output directory or configured to copy on build.
- The solution demonstrates best practices for organizing code and tests in a multi-project C# solution.
- To add a package to a project file use command "dotnet add package Newtonsoft.Json"
