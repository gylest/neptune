# learncsharp Solution

This solution contains multiple C# projects demonstrating various features, including basic programming concepts, data import, and unit testing with xUnit.

## Projects

### 1. learncsharp.Dev
- **Type:** Console Application
- **Description:** Main project demonstrating basic C# features, data import, and record types.
- **Key Files:**
  - `Program.cs`: Entry point, runs demos and imports data.
  - `BasicFeatures.cs`: Contains utility methods and record demonstrations.
  - `DataImport.cs`: Handles importing data from JSON files.
  - `Person.cs`: Defines the Person class used for data import.
- **Packages:**
  - `Newtonsoft.Json`

### 2. learncsharp.Tests
- **Type:** xUnit Test Project
- **Description:** Contains unit tests for the main project, using the xUnit framework.
- **Key Files:**
  - `UnitTest1.cs`: Example unit tests for methods in `BasicFeatures`.
- **Packages:**
  - `xunit`, `xunit.runner.visualstudio`, `Microsoft.NET.Test.Sdk`, `coverlet.collector`

## How to Build
Run the following command in the solution directory:
```
dotnet build
```

## How to Run Tests
Run the following command in the solution directory:
```
dotnet test
```

## How to Debug
Use the provided `launch.json` configuration for .NET debugging in VS Code. Make sure each project builds an executable and is referenced in the solution.

## Notes
- Each project is in its own subfolder for clarity and to avoid build issues.
- Data files (e.g., `person_jd.json`) should be placed in the output directory or configured to copy on build.
- The solution demonstrates best practices for organizing code and tests in a multi-project C# solution.
- To add a package to a project file use command "dotnet add package Newtonsoft.Json"
