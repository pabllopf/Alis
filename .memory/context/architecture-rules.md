---
title: Architecture Rules
tags:
  - context
  - architecture
  - rules
  - constraints
status: Draft
license: GPLv3
---

# Architecture Rules

## Layer Dependency Rules

1. **Strict Top-Down Flow**: Dependencies flow strictly from Layer 1 (Presentation) down to Layer 6 (Ideation)
2. **No Reverse Dependencies**: No project in a lower layer may reference a project in a higher layer
3. **No Cross-Layer Skips**: A layer must depend on the adjacent layer below it (no skipping)
4. **Generator Inclusion**: All layers may reference generators from lower layers as analyzers

## Build Mode Rules

### Debug Mode
- Standard MSBuild ProjectReference chain
- Each layer explicitly references the layer below
- All source generators run at compile time

### Release Mode
- Source files from lower layers are compiled into higher-layer assemblies
- No assembly boundary between layers at runtime
- Enables single-assembly distribution

## Project Structure Rules

1. Every project must follow: `src/`, `test/`, `sample/`, `generator/` layout
2. `.csproj` must import `$(SolutionDir).config/Config.props`
3. Test projects must be named `{ProjectName}.Test`
4. Generator projects must target `netstandard2.0`
5. Sample projects must be excluded from main NuGet package

## Third-Party Dependency Rules

1. No external NuGet dependencies in core projects (Layers 2-6)
2. Extension projects (Layer 1) may use NuGet only for their specific integration
3. Approved exceptions listed in `Config.props`
4. Native dependencies must be included in `runtimes/` directory

## Performance Rules

1. No LINQ in hot paths (use raw loops, `Span<T>`)
2. No boxing (prefer generics, structs)
3. No reflection at runtime (use source generators instead)
4. No `System.Reflection.Emit`
5. Prefer value types for performance-critical data
6. Use data-oriented design patterns

## Related

- [[Coding Conventions]]
- [[Architecture Overview]]
- [[Dependency Graph]]
- [[Repository Overview]]
