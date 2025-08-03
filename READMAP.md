# Installation and Setup
- Install .NET SDK from [Microsoft's official site](https://dotnet.microsoft.com/download)
- Install Visual Studio Code from [Visual Studio Code's official site](https://code.visualstudio.com/)


# Beginner's Guide to C# and .NET
    - C# Foundations: LINQ, Async/Await
    - .NET Basics – CLI, Dependency Injection, Configuration
    
# Intermediate Topics
    - ASP.NET Core: Middleware, Authentication
    - Database Access: Entity Framework Core, Migrations

### Unit Testing: xUnit, Moq, Integration Tests


Great! Here's a structured plan to help you learn these .NET basics step by step:

---

### ✅ 1. **.NET CLI (Command Line Interface)**

**Goal:** Understand how to create, build, run, and manage .NET projects using the CLI.

#### Key Commands:

* `dotnet new console -n MyApp` – Create a new console project.
* `dotnet build` – Compile the project.
* `dotnet run` – Run the app.
* `dotnet add package <package-name>` – Add NuGet package.
* `dotnet restore` – Restore dependencies.
* `dotnet clean` – Clean the build output.

📘 Learn:

* [.NET CLI Docs](https://learn.microsoft.com/en-us/dotnet/core/tools/)

🧪 Practice:

* Create and run a simple “Hello World” console app.
* Add a NuGet package (e.g., `Newtonsoft.Json`) using CLI.

---

### ✅ 2. **Dependency Injection (DI)**

**Goal:** Understand how services are registered and used through DI.

#### Concepts:

* `AddSingleton`, `AddScoped`, `AddTransient`
* Constructor injection
* Service lifetime

#### Example:

```csharp
builder.Services.AddSingleton<IMyService, MyService>();

public class MyController
{
    private readonly IMyService _service;

    public MyController(IMyService service)
    {
        _service = service;
    }
}
```

📘 Learn:

* [.NET Dependency Injection Guide](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)

🧪 Practice:

* Create an interface and implement a service.
* Inject it into a controller or class and use it.

---

### ✅ 3. **Configuration in .NET**

**Goal:** Understand how to load and use configuration from `appsettings.json`, environment variables, etc.

#### Key Files:

* `appsettings.json`
* `appsettings.Development.json`

#### Example:

```json
// appsettings.json
{
  "MyAppSettings": {
    "SiteName": "My Cool App"
  }
}
```

```csharp
builder.Services.Configure<MyAppSettings>(
    builder.Configuration.GetSection("MyAppSettings"));
```

```csharp
public class MyAppSettings {
    public string SiteName { get; set; }
}
```

📘 Learn:

* [.NET Configuration Guide](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration)

🧪 Practice:

* Create an `appsettings.json`
* Bind a POCO class with it and use it in your app.

---


# Data Transfer Object
- DTOs are simple classes that represent data structures
- Used to transfer data between layers (e.g., from API to service)


# LINQ
- LINQ (Language Integrated Query) allows querying collections in a readable way
- Example: `var users = dbContext.Users.Where(u => u.IsActive).ToList();`

For example, LINQ to SQL provider will convert the LINQ queries to SQL statements, which the SQL Server database can understand. Similarly, the LINQ to XML provider will convert the queries into a format the XML document can understand.

### LINQ Architecture
- In Memory Objects
- ADO.NET DataSet
- Entity Framework
- SQL Server DataBase
- XML & other data sources



```json
{
  "LINQ": {
    "Description": "Language Integrated Query for querying collections",
    "Example": "var users = dbContext.Users.Where(u => u.IsActive).ToList();",
    "Benefits": [
      "Readable syntax",
      "Strongly typed queries",
      "Supports filtering, sorting, and grouping"
    ]
  }
}
```


