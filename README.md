# MicroservicesTemplateAPI

A production-grade **.NET microservices starter template** I created and open-sourced after leading a large-scale monolith-to-microservices migration.

### Purpose
Spinning up new services consistently was a major pain point during our migration. This template was built to solve that — every new .NET service at my company was generated from this starter, dramatically improving developer velocity and architectural consistency.

### Key Features
- Clean Architecture + CQRS with MediatR
- Full vertical slice structure (Commands, Queries, Handlers)
- Built-in resilience with Polly (circuit breakers, retries, timeouts)
- Automatic OpenAPI/Swagger generation on build
- Structured logging + New Relic monitoring hooks
- xUnit + integration test skeleton
- Docker + multi-stage Dockerfile ready
- Shared NuGet middleware package for consistent auth, logging, and exception handling
- Terraform-ready infrastructure placeholders

### Tech Stack
- .NET (C#)
- MediatR + FluentValidation
- Entity Framework Core
- Serilog + New Relic
- Docker
- xUnit + Testcontainers

### How to Use
1. Clone the repo
2. Run the setup script (or just copy the folder and rename)
3. Update `appsettings.json` and add your domain
4. `dotnet run` — Swagger UI opens automatically

All services in our company were created from this exact template.

### Why This Template?
- Enforces **Clean Architecture** and **SOLID** principles from day one
- Reduces onboarding time for new engineers
- Built-in observability and resilience patterns
- Proven in production (handled high-volume CRE transactions)

---
