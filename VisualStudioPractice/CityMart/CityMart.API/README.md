# CityMart.API

Project: Presentation / Web API

Purpose
- ASP.NET Core Web API that exposes HTTP endpoints for the CityMart application (catalog, auth, cart, orders, admin).
- Acts as the entry point for clients (web / mobile) and wires together application services, infrastructure, and persistence.

Key folders & files
- `Controllers/` — MVC controllers for each module:
  - `AuthController.cs` — signup/login endpoints, token generation.
  - `ProductsController.cs` — public and admin product APIs.
  - `CartController.cs` — authenticated cart operations.
  - `OrdersController.cs` — checkout, user orders, admin dashboard & order management.
  - `AdminController.cs` — admin utilities and debug endpoints.
- `Program.cs` — app startup: DI registrations, Identity/JWT configuration, role seeding (Admin/Customer).
- `appsettings.json` — configuration including `Jwt` settings and `ConnectionStrings:DefaultConnection`.

How it wires to other projects
- Depends on `CityMart.Application` (interfaces, DTOs) and `CityMart.Infrastructure` (service implementations).
- `CityMart.Persistence` handles EF Core DbContext and migrations.

Running locally
1. Ensure SQL Server connection is configured in `appsettings.json`.
2. From solution root run migrations:
   - `dotnet ef database update --project CityMart.Persistence --startup-project CityMart.API`
3. Run API:
   - `dotnet run --project CityMart.API`

Authentication & Authorization
- Uses ASP.NET Core Identity (ApplicationUser) + JWT tokens.
- Admin role is seeded on startup; admin credentials: `admin@gmail.com` / `Admin@123` (seeded).
- Protect endpoints with `[Authorize]` and role restrictions like `[Authorize(Roles = "Admin")]`.

Testing
- Use Postman for flows: register/login to get JWT, use `Authorization: Bearer <token>` header to call protected APIs.
- Example endpoints: `/api/auth/login`, `/api/products`, `/api/cart`, `/api/orders/checkout`, `/admin/dashboard`.

Notes
- Controllers use DTOs from `CityMart.Application.DTOs` and services from DI.
- For debugging, console logs are emitted during checkout to help diagnose revenue/order item creation.