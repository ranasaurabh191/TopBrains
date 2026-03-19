# CityMart.Infrastructure

Project: Infrastructure Layer (Service Implementations & External Integrations)

Purpose
- Implements the service interfaces defined in `CityMart.Application`.
- Contains helper services like `JwtService`, `EmailService` (if present), and integration with external services.

Key folders & files
- `Services/` — concrete implementations:
  - `AuthService` — user registration / login using `UserManager<ApplicationUser>` and `JwtService`.
  - `ProductService` — CRUD and filtering for products.
  - `CartService` — add/update/remove cart items.
  - `OrderService` — checkout, order retrieval, admin/report logic.
  - `AdminService` — admin-specific operations.
- `JwtService.cs` — generates JWT tokens using config values.

Notes on implementation
- Services use `ApplicationDbContext` (from `CityMart.Persistence`) via DI.
- Keep services focused on business logic; avoid direct HTTP concerns (controllers handle that).
- Prefer minimal entity tracking where possible for performance (e.g., using select projections).

Testing
- Mock `ApplicationDbContext` or use an in-memory provider for integration tests.

Security
- AuthService assigns the default role `Customer` on registration.
- Services respect role-based access controlled by controllers using `[Authorize]` attributes.