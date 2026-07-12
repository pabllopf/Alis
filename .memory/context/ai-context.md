---
title: AI Context
tags:
  - ai
  - context
  - coding
  - reference
status: Draft
license: GPLv3
---

# AI Context — Alis Game Engine

## Repository Identity

| Property | Value |
|---|---|
| Name | Alis |
| Type | Cross-platform C# game framework |
| License | GPLv3 |
| Author | Pablo Perdomo Falcón |
| Website | www.alisengine.com |
| Repository | https://github.com/pabllopf/Alis |

## Architecture Rules

1. **6-Layer Strict Dependency** — `1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation`
2. **Never reverse dependency direction** — enforced via MSBuild Config.props
3. **No external NuGet in core** — only SourceLink; exceptions: Stripe, GoogleAds, GoogleDrive, DropBox (extensions only)
4. **No `var` for built-in types** — use explicit type names
5. **No comments** — only XML doc comments (`///`)
6. **Expression-bodied members** preferred
7. **Block-scoped namespaces** (`namespace Foo { }`)
8. **No LINQ in hot paths**, no boxing, no reflection, no runtime emit
9. **AOT compatibility mandatory** — no `Reflection.Emit`, no runtime codegen
10. **Prefer `Span<T>`**, data-oriented design, SIMD, allocation-free paths
11. **Max line length**: 392 characters
12. **LangVersion**: 13, **Nullable**: disabled
13. **Warnings as errors**: enabled globally

## Layer Responsibilities

| Layer | Name | Contains |
|---|---|---|
| 1 | Presentation | Apps (Engine, Hub, Installer), Benchmarks, 19 Extensions |
| 2 | Application | Main `Alis` assembly — facade, builders, managers, components |
| 3 | Structuration | `Alis.Core` — structural placeholder (empty src/) |
| 4 | Operation | Audio, ECS, Graphic, Physics engines |
| 5 | Declaration | `Alis.Core.Aspect` — structural placeholder (empty src/) |
| 6 | Ideation | Data, Fluent, Logging, Math, Memory, Time (foundation libs) |

## Project Template Pattern

Every module follows:
```
<module>/
├── generator/     (Roslyn source generator, netstandard2.0)
├── sample/        (usage example project)
├── src/           (main library source)
└── test/          (xUnit test project)
```

## Build Commands

```bash
dotnet restore alis.slnx
dotnet build alis.slnx -c Debug
dotnet test alis_design.sln -c Release -f net8.0
```

## Coding Conventions

- **Private fields**: `_camelCase`
- **Private static readonly/const**: `PascalCase`
- **Public APIs**: `PascalCase`
- **Files**: match type name
- **Namespaces**: match folder structure
- **No `var`** when type is apparent or for built-in types

## Key Source Files

| File | Location | Purpose |
|---|---|---|
| Config.props | `.config/Config.props` | Central MSBuild configuration |
| VideoGame.cs | `2_Application/Alis/src/Core/Ecs/Systems/` | Main entry point |
| GameObject.cs | `4_Operation/Ecs/src/` | Core ECS entity |
| Scene.cs | `4_Operation/Ecs/src/` | Scene container |
| Player.cs | `4_Operation/Audio/src/` | Audio facade |
| Gl.cs | `4_Operation/Graphic/src/OpenGL/` | OpenGL bindings |
| DynamicTree.cs | `4_Operation/Physic/src/Collisions/` | Physics broadphase |
| AssetRegistry.cs | `6_Ideation/Memory/src/` | Asset loading |

## Anti-Patterns to Avoid

- Never add external NuGet dependencies to core projects
- Never create new `.csproj` or `.sln` files
- Never use `var` for built-in types
- Never use `//` or `/* */` comments (use `///` XML docs)
- Never use `Reflection.Emit` or runtime codegen
- Never put platform-specific code in shared projects without conditional compilation
- Never reverse the layer dependency direction

## Related

- [[conventions-overview]]
- [[architecture-overview]]
- [[coding-conventions]]
- [[dependency-constraints]]
