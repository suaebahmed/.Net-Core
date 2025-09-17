# ASP.NET Core Web API with Entity Framework Core

@Author: Suaeb Ahmed @Date: 2025-08-03


# Migration

Add-Migration is a Package Manager Console (PMC) command, not a generic PowerShell/terminal command. You likely ran it in a normal terminal.
Options:
1.	Use PMC in Visual Studio
•	View > Other Windows > Package Manager Console
•	Set Default project to RecycleLagbe.Api (the one containing ItemsDbContext)
•	Run: Add-Migration Mig1
2.	Or use CLI instead of PMC
•	Install tools (once): dotnet tool install --global dotnet-ef
•	Then run in the WebAPI project folder: dotnet ef migrations add Mig1


Commend to create migration and update database
```
Add-Migration "initial migration"
Update-Database
```
# Understanding the ASP.NET Core Web API 8 Project Structure
In .NET 8, the project structure is simpler and more intuitive. Here’s an overview of the main components you’ll encounter:

- Controllers Folder: Contains the controllers that handle HTTP requests and responses.
- Models Folder: Defines the data structures used by your API.
- Program.cs: The entry point for the API, where you configure services and the request pipeline (note that in .NET 8, Startup.cs is no longer used).


##### My Learning topics:
- Entity Framework Core
- DbContext		
- Dependency Injection
- Migrations
- DTOs(Data Transfer Objects) and Domain Model
- and etc.

