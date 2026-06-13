[README.md](https://github.com/user-attachments/files/28912070/README.md)
# Unit Conversion API

## Overview
This solution is a layered `.NET 9` Web API for unit conversion.

It includes:
- `UnitConversion.Api` � HTTP API endpoints and app startup
- `UnitConversion.Application` � conversion use-cases, DTOs, and service contracts
- `UnitConversion.Domain` � core domain models (for example, `UnitCategory`)
- `UnitConversion.Infrastructure` � infrastructure extension point
- `UnitConversion.Tests` � unit tests for converter behavior

Supported conversions currently include:
- Length: `meter`, `foot`, `kilometer`
- Weight: `kilogram`, `pound`
- Temperature: `celsius`, `fahrenheit`

## Run locally
### Prerequisites
- .NET SDK `9.0`

### 1) Restore dependencies
From the repository root:

```bash
dotnet restore
```

### 2) Run the API

```bash
dotnet run --project UnitConversion.Api/UnitConversion.Api.csproj
```

The API starts on URLs defined in `UnitConversion.Api/Properties/launchSettings.json` (typically `https://localhost:7125` and `http://localhost:5042` in Development).

### 3) Open Swagger UI
- `https://localhost:7125/swagger`

### 4) Sample request
`POST /api/v1/conversion/convert`

```json
{
  "value": 1,
  "fromUnit": "meter",
  "toUnit": "foot"
}
```

## Run tests

```bash
dotnet test
```

## Design decisions and trade-offs
- **Layered structure**: API, application, domain, and tests are separated to keep responsibilities clear.
- **Strategy-based converters**: each conversion type implements `IUnitConverter`; `ConversionService` selects a converter via explicit `CanConvert(...)` matching.
- **Fail-fast input validation**: request DTO uses data annotations so unsupported units are rejected before business logic.
- **Error contract**: controller returns `400` for known input/domain issues and allows unexpected failures to surface as `500`.
- **Current trade-off**: supported units are hardcoded in converter dictionaries and validation regex for simplicity. A future enhancement is moving unit metadata to configuration or persistent storage.

<img width="1792" height="898" alt="image" src="https://github.com/user-attachments/assets/4a3e7f33-34cf-4c82-a0f4-4855fe74c84a" />

