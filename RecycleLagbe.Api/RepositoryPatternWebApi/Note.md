
# Log level

```csharp
	_logger.LogInformation("This is the information log");

	_logger.LogWarning("This is the warning!");

	_logger.LogError("This is the error");

	_logger.LogCritical("This is the critical!");
```


## Object and Array Logging

In built-in log
 - JsonSerializer.Serialize(dto)
 - JsonSerializer.Serialize(list.Take(10)) # upto 10


In Serilog
- {@Object} or {@Collection} destructures objects/array automatically.


# Dependency Injection 
## Key Concepts
- Loose Coupling
- Inversion of Control (IoC)
- Interfaces: Dependencies are typically defined and injected through interfaces rather than concrete implementations

## Inversion of Control (IoC)
Inversion of Control (IoC) in C# is a design principle that inverts the traditional flow of control in an application. 
]Instead of objects being responsible for creating and managing their own dependencies, a framework or container takes on this responsibility. 
This leads to a more loosely coupled and testable codebase

### Key aspects of IoC in C#:
- Reduced Coupling: IoC promotes decoupling by having components depend on abstractions (interfaces) rather than concrete implementations. 
  This allows for easier swapping of implementations without modifying the dependent code.

- Increased Testability: By injecting dependencies, it becomes straightforward to replace real implementations with mock objects during testing,
  isolating the component under test and simplifying unit testing.

- Dependency Injection (DI) as an Implementation: Dependency Injection is a common technique to achieve IoC. 
  Instead of a class instantiating its dependencies, those dependencies are "injected" into the class, typically through its 
  - constructor, 
  - property, 
  - or method.

- IoC Containers: IoC containers (also known as DI containers) are frameworks that automate the process of managing and injecting dependencies. 
  They handle the registration of types and their corresponding implementations, and then resolve these dependencies when needed. 
  Popular IoC containers in C# include Autofac, Unity, Ninject, and the built-in DI container in .NET Core.
    

## How DI Works (with an IoC Container):
- Define Services and Interfaces: Create interfaces for your dependencies and concrete implementations of those interfaces.
- Register Services: In your application's startup (e.g., Program.cs in .NET Core), register your services with the IoC container. 
  This tells the container how to create instances of your services and their dependencies.

```csharp
    // Example registration in Program.cs
    builder.Services.AddSingleton<IEngine, PetrolEngine>(); // Register IEngine to use PetrolEngine
    builder.Services.AddTransient<Car>(); // Register Car
```
- Resolve Dependencies: When a class (e.g., a controller in a web API) requires a dependency, 
  the IoC container automatically resolves and injects the appropriate instance based on the registrations.

  