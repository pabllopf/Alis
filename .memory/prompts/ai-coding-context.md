---
title: AI Coding Context
tags:
  - prompt
  - ai
  - context
  - coding
status: Draft
license: GPLv3
---

# AI Coding Context

## Repository Identity

- **Name**: Alis Game Engine
- **Language**: C# (.NET 10, LangVersion 13)
- **Architecture**: 6-layer clean architecture monorepo
- **License**: GPLv3
- **Author**: Pablo Perdomo Falcón

## Architecture Rules

1. **Strict 6-layer dependency**: 1_Presentation -> 2_Application -> 3_Structuration -> 4_Operation -> 5_Declaration -> 6_Ideation
2. **No reverse dependencies** between layers
3. **No external NuGet** in core layers (only in specific extensions)
4. **No LINQ** in hot paths, no boxing, no reflection, no runtime emit
5. **Source generators** for compile-time code generation
6. **Multi-framework** support (net461 through net10.0)

## Naming Conventions

- System: `_camelCase`
- Methods: `PascalCase`
- Interfaces: `IPascalCase`
- No `var` for built-in types
- No `//` comments (use `///` XML doc only)
- Block-scoped namespaces

## Build Commands

```bash
# Build all
dotnet restore alis.slnx
dotnet build alis.slnx -c Debug

# Run tests (quick)
dotnet test alis_design.sln -c Release -f net8.0

# Run all tests
./docs/scripts/macos/run_tests.sh
```

## Project Location

All source projects are in numbered layer directories. Each has `src/`, `test/`, `sample/`, and `generator/` subdirectories.

## Key Architectural Patterns

- **ECS**: Entity-Component-System in `Alis.Core.Ecs`
- **Aspect-Oriented**: Cross-cutting concerns via `Alis.Core.Aspect`
- **Source Generators**: Roslyn-based code generation
- **Pluggable Backends**: Graphics via SDL2/SFML/GLFW abstractions

## Related

- [[Repository Overview]]
- [[Architecture Rules]]
- [[Coding Conventions]]
- [[Projects Index]]
