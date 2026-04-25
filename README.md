# AuthShield

A clean-architecture .NET 8 starter that bundles auth & identity into reusable Application/Domain/Infrastructure/Persistence projects so a new service can drop them in and get JWT-based auth, user management, and password handling without rewriting the boilerplate.

## Stack

- .NET 8 / ASP.NET Core
- MediatR for CQRS-style request handling
- JWT bearer authentication
- EF Core (separate `Persistance` project)
- Swashbuckle

## Solution layout

```
AuthShield.Api            — HTTP entry point + Auth controller
AuthShield.Application    — request/response models, MediatR handlers
AuthShield.Domain         — entities, common types
AuthShield.Infrastructure — cross-cutting services (token, hashing)
AuthShield.Persistance    — EF Core DbContext + repositories
```

## Running

```bash
dotnet ef --project AuthShield.Persistance --startup-project AuthShield.Api database update
dotnet run --project AuthShield.Api
```

Swagger UI at `/swagger` once running.
