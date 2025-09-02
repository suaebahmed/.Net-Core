# Learning Topic on C#
https://devskill.com/course/detail/professional-programming-with-csharp

- Property
- Execution step in inheritance


- Interface and abstraction
  ** An interface is a completely "abstract class", which can only contain abstract methods and properties (with empty bodies):
  ** multiple inheritance is possible with interfaces.

- Lambda expressions and anonymous functions
  We use lambda expressions to create an anonymous function and others(delegates or expression tree types)
- Delegates
  

### Need to learn

- Mediatr library - with command behavioral pattern 
- CQRS
- Unit Test - https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
- DI - Instantiated
- Middleware
- What are instantiated or injected (e.g., in controllers, handlers, or services) in dotnet?
- Collections: Learn to use lists, dictionaries, and arrays to manage data.



### Understanding Fintech
https://rocketwave.co/understanding-payment-processors/

my playlist on youtube!

### Best Practice

Naming Conventions in C# / .Net Core | by Andreas 🎧 Kagoshima | Medium
https://medium.com/@a.kago1988/naming-conventions-in-c-crafting-clean-and-declarative-code-14812e1d4c6b

https://stackoverflow.com/questions/150479/order-of-items-in-classes-fields-properties-constructors-methods


### Project stucture

```bash
	WebApi is our main project with controllers. Function is secondary, but not needed now. 
	Application.Core holds queries, commands, and services with business logic. 
	Database contains schemas, tables, and procedures. 
	Domain.Core or Common has shared entities. 
	The integration folder includes processor folders with integrated processors.
```
