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
🔁 Service Lifetimes in .NET

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

Great! Let’s dive into the **core concepts of Dependency Injection (DI)** in .NET:

---

## 🔁 **Service Lifetimes in .NET**

When you register a service with DI in .NET, you must choose a **lifetime** that determines:

* How long the service object exists.
* When a new instance is created.

### 1. 🟦 `AddSingleton<TInterface, TImplementation>()`

* **Lifetime:** One instance **for the entire application.**
* Created **once**, shared across **all requests** and **all classes** that depend on it.

✅ **Use When:**

* The service holds no user-specific state.
* Expensive to create and should be reused.

📌 Example:

```csharp
builder.Services.AddSingleton<ILogger, ConsoleLogger>();
```

---

### 2. 🟩 `AddScoped<TInterface, TImplementation>()`

* **Lifetime:** One instance **per HTTP request.**
* Shared within a single request but a **new one for each new request.**

✅ **Use When:**

* You need **request-specific data**, like a user ID.

📌 Example:

```csharp
builder.Services.AddScoped<IUserService, UserService>();
```

---

### 3. 🟨 `AddTransient<TInterface, TImplementation>()`

* **Lifetime:** A **new instance every time** it is requested.

✅ **Use When:**

* The service is **lightweight**.
* Doesn’t store any state or resource that needs to be shared or reused.

📌 Example:

```csharp
builder.Services.AddTransient<IReportGenerator, PdfReportGenerator>();
```

---

## 🧱 **Constructor Injection**

.NET automatically **injects dependencies** via constructor parameters when using DI.

📌 Example:

```csharp
public class MyController
{
    private readonly IEmailService _emailService;

    public MyController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void Send()
    {
        _emailService.SendEmail("hello@example.com");
    }
}
```

When `MyController` is instantiated by the framework (e.g., ASP.NET Core), it will **resolve and pass in the implementation** of `IEmailService` based on how you registered it (`Singleton`, `Scoped`, or `Transient`).

---

## 🔁 **Putting it All Together**

Let’s say you have the following service interfaces and implementations:

```csharp
public interface IMessageService { void Send(string msg); }
public class EmailService : IMessageService {
    public void Send(string msg) => Console.WriteLine($"Sending: {msg}");
}
```

### Register it:

```csharp
builder.Services.AddScoped<IMessageService, EmailService>();
```

### Inject into a class:

```csharp
public class NotificationManager
{
    private readonly IMessageService _messageService;

    public NotificationManager(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string msg) => _messageService.Send(msg);
}
```

---

## 🚀 Summary Table

| Lifetime  | Created          | Shared      | Scope       |
| --------- | ---------------- | ----------- | ----------- |
| Singleton | Once             | App-wide    | Whole app   |
| Scoped    | Once per request | Per-request | Web request |
| Transient | Always           | Never       | Everywhere  |

---

Let me know if you want to build a small project (like a user notification service) to see these in action — or if you'd like diagrams or interview-style questions to test yourself.


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

# LINQ queries can be written in two ways:
- 1. Query Syntax: 
```csharp
var query = from user in dbContext.Users
            where user.IsActive
            orderby user.Name
            select user;
```
- 2. Method Syntax
```csharp
var query = dbContext.Users
                     .Where(u => u.IsActive)
                     .OrderBy(u => u.Name);
```
 - 3. Mixed Syntax (Query + Method)

 