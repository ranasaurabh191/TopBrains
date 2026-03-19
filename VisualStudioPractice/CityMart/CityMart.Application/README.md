# CityMart.Application

Project: Application Layer (Business Logic Contracts & DTOs)

Purpose
- Defines the public contracts (interfaces) for application services, DTOs used across layers, and shared validation or utility classes.
- Keeps business-facing models separate from persistence models.

Key folders & files
- `DTOs/` — Data Transfer Objects used between API and services (e.g., `ProductDto`, `OrderDto`, `CartDto`, `CheckoutDto`, `RegisterDto`, `LoginDto`).
- `Interfaces/` — Service interfaces (e.g., `IProductService`, `ICartService`, `IOrderService`, `IAuthService`, `IAdminService`) that define application operations.
- `Common/` — Shared helpers like `ApiResponse<T>`.

Responsibilities
- DTOs ensure that API controllers don't expose domain entities directly and allow flexibility in changing persistence details.
- Interfaces enable dependency inversion: `CityMart.API` depends on these abstractions and concrete implementations are in `CityMart.Infrastructure`.

How it fits in the solution
- `CityMart.API` references this project to use DTOs and call services by interface.
- `CityMart.Infrastructure` implements these interfaces.

Testing
- Unit tests should target implementations of interfaces by mocking dependencies (e.g., mock `ApplicationDbContext` or repositories).

Notes
- Keep DTOs simple and avoid business logic here. Business logic belongs in service implementations.