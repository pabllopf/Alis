---
title: Coding Conventions
tags:
  - context
  - conventions
  - coding-standards
status: Draft
license: GPLv3
---

# Coding Conventions

## Language Features

| Feature | Setting |
|---|---|
| LangVersion | 13 (latest) |
| Nullable | Disabled |
| Unsafe | Disabled |
| WarningsAsErrors | Enabled |

## Naming Conventions

| Element | Convention | Example |
|---|---|---|
| Private fields | _camelCase | `_entityManager` |
| Private static readonly | PascalCase | `DefaultConfiguration` |
| Constants | PascalCase | `MaxEntities` |
| Properties | PascalCase | `EntityId` |
| Methods | PascalCase | `UpdateEntities` |
| Parameters | camelCase | `entityId` |
| Local variables | camelCase | `entityCount` |
| Interfaces | IPascalCase | `IEntitySystem` |
| Type parameters | T PascalCase | `TEntity` |
| Namespaces | PascalCase dot-notation | `Alis.Core.Ecs` |

## Code Style

- Expression-bodied members preferred for methods, constructors, destructors, local functions
- Block-scoped namespaces (`namespace Alis.Core.Ecs { }`)
- Maximum line length: 392 characters
- All code, docs, and comments in English
- No `//` or `/* */` comments — use XML doc comments (`///`) only
- No `var` for built-in types or when type is apparent

## Architecture Rules

- Strict 6-layer dependency direction (1 -> 2 -> 3 -> 4 -> 5 -> 6)
- No reverse cross-layer dependencies
- No external NuGet dependencies in core projects (only in specific extensions)
- Source generators must be AOT-safe and deterministic
- No LINQ in hot paths
- No boxing, no reflection, no runtime emit
- Prefer `Span<T>`, data-oriented design, SIMD, allocation-free paths

## Build Rules

- All `.csproj` files must share common `Config.props`
- Generator projects target `netstandard2.0`
- Test projects auto-reference the corresponding source project
- Test results stored in `.test/<TargetFramework>/`

## File Structure

- Mandatory file header on every `.cs` file
- Header template defined in `.editorconfig`
- One project per directory with `src/`, `test/`, `sample/`, `generator/` subdirectories

## Related

- [[Architecture Rules]]
- [[AI Coding Standards]]
- [[Repository Overview]]
