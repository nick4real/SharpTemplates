# ASP.NET Microservice Template

Template for creating a Clean Architecture–style ASP.NET Core Web API project.

## Features

- **Clean Architecture layout** (API / Application / Domain / Infrastructure)
- **Health checks** wired in API startup
- **OpenAPI + Scalar** support (optional)
- **WeatherForecast** sample  logic (optional)

## Parameters

| Parameter | Type | Default | Description |
|---|---|---|---|
| `Framework` | choice | `net10.0` | Target framework (currently .NET 10.0). |
| `EnableScalarSupport` | bool | `true` | Enables OpenAPI + Scalar API reference integration. |
| `IncludeSampleLogic` | bool | `false` | Includes the WeatherForecast sample controller, DTOs, services, and repository. |

### Generated values
- **http/https ports** are generated at template creation time (not user-provided).

## Third‑party libraries

| Library | Where used | Purpose |
|---|---|---|
| `Microsoft.AspNetCore.OpenApi` | API | OpenAPI/Swagger support |
| `Scalar.AspNetCore` | API | Scalar API reference UI |
| `Microsoft.AspNetCore.Http` | Application | HTTP abstractions |
| `Microsoft.Extensions.DependencyInjection` | Application | DI abstractions |

## Patterns used

- **Clean Architecture**
- **Dependency Injection**
- **Extension methods for service registration**
- **Repository & Service abstractions**
- **Result pattern**