---
title: Architecture Decision Records
tags:
  - decisions
  - architecture
  - adr
status: Draft
license: GPLv3
---

# Architecture Decision Records

## ADR-001: 6-Layer Clean Architecture

**Status**: Accepted

**Context**: Need to organize 140+ projects in a monorepo with clear dependency rules.

**Decision**: Organize into 6 strict layers (Presentation -> Application -> Structuration -> Operation -> Declaration -> Ideation) with top-down dependency flow.

**Consequences**:
- Clear ownership boundaries
- Enforced dependency direction
- Easy to reason about module isolation
- More complex build system required

---

## ADR-002: Source File Merging in Release Mode

**Status**: Accepted

**Context**: NuGet packaging benefits from single-assembly distribution.

**Decision**: In Release builds, compile source files from lower layers directly into higher-layer assemblies using MSBuild `<Compile Include>`.

**Consequences**:
- Single assembly per NuGet package
- Loss of assembly-level separation
- Simplified deployment
- Conditional compilation complexity

---

## ADR-003: Roslyn Source Generators for Boilerplate

**Status**: Accepted

**Context**: ECS patterns and serialization require significant boilerplate code.

**Decision**: Use Roslyn source generators (12 projects) for compile-time code generation.

**Consequences**:
- No runtime reflection or emit
- AOT-compatible
- Deterministic builds
- Build-time overhead
- Complex generator debugging

---

## ADR-004: Multi-Framework Support

**Status**: Accepted

**Context**: Engine needs to support diverse .NET runtimes (legacy to modern).

**Decision**: Target 15+ .NET frameworks from single codebase using conditional compilation.

**Consequences**:
- Broad platform compatibility
- Complex conditional code
- Large build matrix
- Legacy compatibility packages needed

---

## ADR-005: ECS as Core Architecture Pattern

**Status**: Accepted

**Context**: Game engines benefit from data-oriented ECS design.

**Decision**: Implement ECS as core game object model in `Alis.Core.Ecs` with entity archetypes, component storage, and system execution.

**Consequences**:
- Cache-friendly data layouts
- Clear separation of data and logic
- Performance and flexibility
- Learning curve for developers

---

## ADR-006: Pluggable Graphics Backends

**Status**: Accepted

**Context**: Need cross-platform graphics support without vendor lock-in.

**Decision**: Abstract graphics behind a common interface (`Alis.Core.Graphic`) with pluggable backends (SDL2, SFML, GLFW, Vulkan).

**Consequences**:
- Platform flexibility
- Backend selection at build time
- Multiple native dependency sets
- Consistent API across backends

---

## ADR-007: MSBuild-Based Asset Packing

**Status**: Accepted

**Context**: Game assets need to be embedded in assemblies for distribution.

**Decision**: Use MSBuild targets to SHA-256 hash, ZIP, and Base64-encode assets into compiled assemblies.

**Consequences**:
- No runtime asset packing
- Integration with build pipeline
- Incremental rebuild support
- Build-time overhead

---

## ADR-008: No External NuGet in Core

**Status**: Accepted

**Context**: Core layers must remain lightweight and dependency-free.

**Decision**: Forbid external NuGet packages in Layers 2-6. Only Layer 1 extensions may use specific approved packages.

**Consequences**:
- Minimal core dependencies
- Clear dependency ownership
- Limited external functionality in core
- Extension pattern for third-party integration

---

## Related

- [[Architecture Overview]]
- [[Architecture Rules]]
- [[Build System]]
