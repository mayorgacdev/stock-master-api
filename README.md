# StockMaster API

An **ASP.NET Core inventory API learning project** for products, suppliers, warehouses and customers.

**Status:** learning project. The repository contains API endpoints and persistence code; a reproducible demo and automated verification are still needed.

## What's implemented

- Customer creation and filtered, paginated customer queries.
- Queries and creation endpoints for products, suppliers, warehouses, product brands and product types.
- Accessory and part-related endpoints.
- Entity Framework Core mappings and an initial SQL Server migration.
- Swagger UI in the Development environment.

The existing solution and namespaces use `Training`, the project's original name.

## Structure

| Project | Responsibility |
| --- | --- |
| `Training.Domain` | Inventory and sales domain models |
| `Training.Application` | Application services, requests, validation and mapping |
| `Training.Infraestructure` | EF Core, SQL Server, repositories and migrations |
| `Training.Common` | Shared types and helpers |
| `Training.WebApi` | Controllers, dependency registration and HTTP middleware |

## Local development

You need the **.NET 8 SDK**, a development **SQL Server** instance and the **EF Core 8 CLI tools**.

```bash
git clone https://github.com/mayorgacdev/stock-master-api.git
cd stock-master-api
dotnet restore Training.sln
dotnet build Training.sln
```

Configure your own development database through user secrets:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your-development-connection-string>" --project src/Training.WebApi
```

Apply the existing migration to that development database, then start the API:

```bash
dotnet ef database update --project src/Training.Infraestructure --startup-project src/Training.WebApi
dotnet run --project src/Training.WebApi --launch-profile http
```

The HTTP launch profile uses [localhost:5185/swagger](http://localhost:5185/swagger).

## Explore the API

- [Customer endpoints](src/Training.WebApi/Controllers/CustomersController.cs): `/api/Customers`.
- [Warehouse and catalog endpoints](src/Training.WebApi/Controllers/WarehouseController.cs): `/api/Warehouse`.
- [Database configuration](src/Training.WebApi/Extensions/ServicesExtensions.cs).
- [Existing migrations](src/Training.Infraestructure/Migrations).

## Next milestones

- Verify setup from a fresh checkout with sample data.
- Add tests for business rules and API behavior, then run them in CI.
- Validate inventory workflows with a real small-business use case.

Built by [Paulo Jirón](https://vulcanobyte.com).
