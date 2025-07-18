# CaseStudy

## Setup Instructions

1. **Requirements**
   - [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
   - SQL Server (or compatible connection string)

2. **Database Setup**
   - Update your `appsettings.json` or user secrets with a valid `DefaultConnection` string for your SQL Server instance.
   - Apply migrations (if available) or ensure the database schema matches the expected models.

3. **Running the Project**
   - Open the solution in Visual Studio 2022.
   - Set `CaseStudy.Host` as the startup project.
   - Press `F5` or run:
     ```sh
     dotnet run --project CaseStudy.Host
     ```
   - Swagger UI will be available at `https://localhost:<port>/swagger` for API exploration.

---

## Folder Structure and Layers
- I have Implemented Clean architecture as showen along with CQRS below:
- **CaseStudy.Host**: Entry point, API host, and configuration.
- **CaseStudy.Infrastructure.API**: API layer, controllers, and HTTP endpoints.
- **CaseStudy.Application.Commands/Queries**: Application logic, MediatR commands and queries.
- **CaseStudy.Domain**: Domain models and interfaces.
- **CaseStudy.Infrastructure.DataBase**: Entity Framework Core context, repositories, and database logic.
- **CaseStudy.SharedModels**: Shared DTOs and models.

---

## Filters, Sorting, and Logging

- **Filters & Sorting**:  
  Implemented in the query repositories (see `CaseStudy.Application.Queries.Repositories`). Filtering and sorting logic is typically handled in repository methods using LINQ and MediatR queries.

- **Logging**:  
  Logging is configured using `DebugLoggerProvider` in `Program.cs`:
