# CityMart.Domain

Project: Domain Layer (Core Entities & Identity)

Purpose
- Defines the core domain entities and enums used across the application.
- Contains the `ApplicationUser` identity model under `Domain.Identity` for ASP.NET Identity integration.

Key folders & files
- `Entities/` — domain entities:
  - `Product`, `Category` — product catalog.
  - `Cart`, `CartItem` — shopping cart entities.
  - `Order`, `OrderItem` — order entities; `OrderStatus` enum defines statuses.
- `Identity/` — `ApplicationUser` extends IdentityUser to add `FullName`.
- `Enums/` — `OrderStatus` enum.

Guidelines
- Entities are POCOs. Do not include cross-cutting concerns here.
- Navigation properties should be set as nullable and collections initialized to empty lists to avoid accidental EF behavior.

Notes
- This layer is referenced by `CityMart.Application`, `CityMart.Persistence`, and `CityMart.Infrastructure`.