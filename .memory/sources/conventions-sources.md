---
title: Source Code Conventions
tags:
  - source
  - reference
  - documentation

status: draft
---


Coding standards and conventions used throughout the Alis solution.

## Language Version

- **C# 13** - Latest language features
- **Nullable** - Disabled (`<Nullable>disable</Nullable>`)
- **WarningsAsErrors** - Enabled (`<WarningsAsErrors>true</WarningsAsErrors>`)
- **TreatWarningsAsErrors** - Enabled (`<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`)

## File Organization

### Source Files
- **Location**: `src/` subdirectory
- **Naming**: PascalCase for types, camelCase for members
- **Structure**: One public type per file (where practical)

### Test Files
- **Location**: `test/` subdirectory
- **Naming**: `<TypeName>Test.cs` or `<TypeName>Tests.cs`
- **Pattern**: xUnit test classes with `[Fact]` or `[Theory]` attributes

### Generated Files
- **Location**: `obj/<Target>/generated/` (excluded from source control)
- **Naming**: `<GeneratorName>.<Type>.g.cs`

## Naming Conventions

| Type | Convention | Example |
|------|------------|---------|
| Classes | PascalCase | `EntityManager`, `MovementSystem` |
| Interfaces | IPascalCase | `IComponent`, `ISystem` |
| Methods | PascalCase | `Initialize()`, `Update()` |
| Properties | PascalCase | `EntityCount`, `DeltaTime` |
| Parameters | camelCase | `deltaTime`, `entityId` |
| Private fields | _camelCase | `_entityManager`, `_query` |
| Constants | PascalCase | `MAX_ENTITIES`, `DEFAULT_UPDATE_RATE` |

## Documentation Requirements

- **XML Comments** (`///`) required for all public/protected APIs
- **No inline comments** (`//` or `/* */`) in code
- **Documentation file** generated: `<GenerateDocumentationFile>true</GenerateDocumentationFile>`

## Code Style

### Type Declarations
```csharp
// Use records for immutable data
public record Position(float X, float Y);

// Use structs for components (value types)
public struct Velocity : IComponent
{
    public float X;
    public float Y;
}

// Use interfaces for abstractions
public interface ISystem
{
    void Update(float deltaTime);
}
```

### Async Patterns
```csharp
// Use async/await for I/O operations
public async Task<Resource<T>> LoadAsync<T>(string path)
{
    // Async loading logic
}

// Return Task for fire-and-forget operations
public async Task InitializeAsync()
{
    // Initialization logic
}
```

### Extension Methods
```csharp
// Use extension methods for fluent APIs
public static class EntityExtensions
{
    public static T AddComponent<T>(this Entity entity) where T : IComponent
    {
        // Extension logic
    }
}
```

## See Also
- [[Build System Configuration]]
- [[Quality Assurance]]
