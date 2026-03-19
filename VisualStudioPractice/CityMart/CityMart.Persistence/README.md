# CityMart.Persistence

Project: Persistence Layer (EF Core + Migrations)

Purpose
- Contains `ApplicationDbContext`, EF Core entity configurations, and database migrations.
- Responsible for mapping domain entities to the database schema and running migrations.

Key folders & files
- `Context/ApplicationDbContext.cs` — EF Core DbContext; DbSets for `Products`, `Categories`, `Carts`, `CartItems`, `Orders`, `OrderItems`.
- `Configurations/` — Fluent API entity configurations (e.g., `ProductConfig`, `OrderConfig`).
- `Migrations/` — EF Core migrations produced by `Add-Migration`.

Usage
- Update connection string in `CityMart.API/appsettings.json` under `DefaultConnection`.
- Run migrations:
  - `dotnet ef migrations add <Name> --project CityMart.Persistence --startup-project CityMart.API`
  - `dotnet ef database update --project CityMart.Persistence --startup-project CityMart.API`

Notes
- `OnModelCreating` uses `ApplyConfigurationsFromAssembly` to automatically register configurations.
- Configure value conversions (e.g., `Order.Status` enum stored as string) in the configuration classes.

Best practices
- Keep complex mapping logic here; do not mix business rules with mapping.
- Seed minimal data (roles) from `CityMart.API` startup if needed.