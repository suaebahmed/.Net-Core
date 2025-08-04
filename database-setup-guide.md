# Revolv3 Database Setup Guide

## Quick Start for New Developers

### Prerequisites
- ✅ SQL Server installed and running
- ✅ SQL Server Management Studio (SSMS)
- ✅ Connection string updated in appsettings.json

### Database Setup Options

## Option 1: Get Database Backup (RECOMMENDED)
1. Contact your team lead for a development database backup (.bak file)
2. Restore it to your local SQL Server
3. Update connection string to point to your local database

## Option 2: Use Database Project (Visual Studio Required)
1. Open `Revolv3.sln` in Visual Studio
2. Right-click `Revolv3.Infrastructure.Database` project
3. Select "Publish..."
4. Configure connection to your local server
5. Click "Publish"

## Option 3: Entity Framework Database Creation
If you need to create from scratch:

```bash
# migration command
dotnet ef migrations add InitialCreate --context Revolv3DbContext --project Infrastructure/Revolv3.Infrastructure.DataAccess --startup-project Presentation/Revolv3.WebApi

# Apply the migration to create the database schema
dotnet ef database update --context Revolv3DbContext --project Infrastructure/Revolv3.Infrastructure.DataAccess --startup-project Presentation/Revolv3.WebApi
```
