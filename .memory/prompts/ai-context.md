---
title: AI Context — ALIS Game Engine Framework
tags:
  - prompt
  - ai
  - reference

status: draft

license: GPLv3
---


> Quick reference card for AI agents working with the ALIS codebase.

## Repository Facts

| Fact | Value |
|------|-------|
| Language | C# 13 |
| SDK | .NET 10.0+ |
| Total Projects | ~140 unique (335 in slnx) |
| Architectural Layers | 6 (strict dependency flow) |
| Extensions | 19 |
| Game Samples | 13 (Desktop + Web each) |
| Source Generators | 8 |
| Test Framework | xUnit 2.6.6 + Moq 4.20.70 |
| Code Analysis | SonarQube + .NET Analyzers |
| License | GPLv3 |

## Architecture Rules (CRITICAL)

1. **Dependency flow is STRICT**: `1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration ← 6_Ideation`
2. **Never create upward references** (e.g., 4_Operation → 3_Structuration)
3. **Aggregator projects have ZERO hand-written code** (Alis.Core, Alis.Core.Aspect)
4. **Source generators cascade downward** from 6_Ideation through all layers
5. **No external NuGet packages** — only standard .NET, system libraries, native APIs

## Layer Responsibilities

| Layer | Purpose | Key Projects |
|-------|---------|-------------|
| 1_Presentation | User-facing apps & extensions | Engine, Hub, Installer, 19 Extensions |
| 2_Application | Core app & game samples | Alis, 13 Samples |
| 3_Structuration | Core aggregator (zero code) | Alis.Core |
| 4_Operation | Engine subsystems | ECS, Graphic, Audio, Physic |
| 5_Declaration | Aspect aggregator (zero code) | Alis.Core.Aspect |
| 6_Ideation | Aspect definitions + generators | Memory, Fluent, Data, Math, Time, Logging |

## Naming Conventions

| Type | Pattern | Example |
|------|---------|---------|
| Projects | `Alis.{Layer}.{Module}.{Sub}` | `Alis.Core.Ecs` |
| Namespaces | Mirror project structure | `Alis.Core.Ecs` |
| Test Projects | `{ProjectName}.Test` | `Alis.Core.Ecs.Test` |
| Extensions | `Alis.Extension.{Category}.{Name}` | `Alis.Extension.Graphic.Sfml` |
| Samples | `Alis.Sample.{GameName}` | `Alis.Sample.Flappy.Bird` |
| Generators | `Alis.*.Generator` | `Alis.Core.Ecs.Generator` |

## Build Commands

```bash
dotnet restore                    # Restore dependencies
dotnet build alis.slnx            # Build all
dotnet test alis.slnx             # Run all tests
dotnet pack -c Release            # Create NuGet packages
```

## Project Structure Template

Each engine subsystem follows this pattern:
```
4_Operation/{Name}/
├── src/          # Source library
├── test/         # xUnit tests
├── sample/       # Usage examples
└── generator/    # Roslyn source generator (optional)
```

## Files to Check

| File | Purpose |
|------|---------|
| `Directory.Build.props` | Shared build properties (AssemblyVersion, analyzers) |
| `.config/Config.props` | Multi-targeting, RIDs, generator references, dependencies |
| `global.json` | SDK version requirements |
| `alis.slnx` | Solution structure (all projects) |
| `AGENTS.md` | Agent rules and conventions |

## Anti-Patterns to Avoid

- ❌ Cross-layer references (e.g., 1_Presentation → 3_Structuration)
- ❌ Upward references (e.g., 4_Operation → 3_Structuration)
- ❌ Hand-written code in aggregator projects
- ❌ Modifying generated code directly (edit the generator instead)
- ❌ Adding external NuGet packages without approval
- ❌ Using `System.Reflection.Emit` (breaks AOT compatibility)

## Performance Patterns

- Use `Span<T>` and `Memory<T>` for zero-allocation slicing
- Prefer value types (structs) for hot paths
- Use `StructLayout(Pack=1)` for cache-efficient data structures
- Leverage archetype-based ECS for cache-friendly iteration
- Use `ArrayPool<T>` for temporary buffer management

## Testing Patterns

```csharp
// Standard test pattern
public class MyTest
{
    [Fact]
    public void Should_DoSomething()
    {
        // Arrange
        // Act
        // Assert
    }
}
```

---

## Related Documentation

- [[prompts/code-review-checklist]] — Code review guidelines
- [[conventions/naming-conventions]] — Naming rules
- [[architecture/repository-overview]] — Architecture overview
