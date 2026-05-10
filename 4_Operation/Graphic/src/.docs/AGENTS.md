# AGENTS.md

## Project Overview

Alis is a fully managed high-performance multimedia and game development framework written entirely in C#.

This agent will work specifically on the module:

- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

The `Alis.Core.Graphic` module provides the abstracted graphics implementation layer for multiple rendering backends and operating systems. The architecture is designed to support platform abstraction, low-level rendering interoperability, performance-oriented rendering pipelines, and future extensibility without relying on third-party dependencies.

The project follows a strict cross-platform and multi-framework compatibility strategy.

---

# Platform Compatibility

The graphics module must remain compatible with all supported runtime identifiers and architectures.

## Supported Platforms

### Windows
- `win-x64`
- `win-x86`
- `win-arm64`

### Linux
- `linux-x64`
- `linux-musl-x64`
- `linux-arm`
- `linux-arm64`
- `linux-musl-arm`
- `linux-musl-arm64`

### macOS
- `osx-x64`
- `osx-arm64`

### Web
- `browser-wasm`

### Mobile (Planned)
- `android`
- `ios`

All implementations must be written with portability and platform abstraction in mind.

Platform-specific logic must always be isolated behind abstractions and never leak into shared APIs.

---

# Framework Compatibility

All code added to this repository must remain compatible with every supported framework target.

## Supported Frameworks

### .NET Core
- `netcoreapp2.0`
- `netcoreapp2.1`
- `netcoreapp2.2`
- `netcoreapp3.0`
- `netcoreapp3.1`

### .NET
- `net5.0`
- `net6.0`
- `net7.0`
- `net8.0`
- `net9.0`
- `net10.0`

### .NET Standard
- `netstandard2.0`
- `netstandard2.1`

### .NET Framework
- `net471`
- `net472`
- `net48`
- `net481`

Do not use APIs unavailable in older targets unless guarded through conditional compilation.

Avoid runtime-specific assumptions.

Backward compatibility is mandatory.

---

# Repository Structure

## Graphics Module
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

Contains the graphics abstraction layer and rendering implementation logic.

## Code Generator
- `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj`

Contains all automatic code generation systems used by the graphics module.

Generated code must also comply with all repository rules.

## Samples
- `4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj`

Contains validation samples, rendering demonstrations, platform validation utilities, and usage examples.

Samples must compile and execute on every supported platform whenever possible.

## Tests
- `4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj`

Contains:
- Unit tests
- Integration tests
- Performance tests
- Stress tests
- Regression tests

All new production code must include corresponding tests.

---

# Language Rules

- All source code must be written entirely in English.
- All identifiers must use English naming.
- All APIs must use English naming.
- All documentation must use English.

No mixed-language code is allowed.

---

# Documentation Rules

Every public, protected, and internal API must contain XML documentation comments.

Only XML documentation comments are allowed.

## Allowed
```csharp
/// <summary>
/// Represents a graphics device.
/// </summary>
public sealed class GraphicDevice
{
}
````

## Forbidden

```csharp
// Simple comment
/* Complex comment */
```

Do not use:

* `//`
* `/* */`

Only XML documentation comments are permitted.

Documentation must be precise, technical, and maintainable.

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden

* External NuGet packages
* Third-party frameworks
* External helper libraries
* Community packages

## Allowed

* Native platform APIs
* System libraries
* Standard .NET libraries
* OpenGL
* Vulkan
* DirectX bindings implemented internally
* Metal interop implemented internally

The framework must remain fully self-contained.

---

# Architecture Guidelines

## Core Principles

* High performance
* Low allocations
* Zero unnecessary abstractions
* Cross-platform portability
* Predictable memory behavior
* Deterministic execution
* Minimal overhead
* API consistency
* Backend abstraction
* Extensible rendering architecture

## Design Rules

* Prefer `readonly struct` where appropriate.
* Avoid boxing allocations.
* Avoid reflection unless strictly required.
* Avoid LINQ in hot paths.
* Avoid hidden allocations.
* Avoid unnecessary heap allocations.
* Prefer spans and memory-efficient APIs when target frameworks allow.
* Keep APIs deterministic.
* Use aggressive inlining carefully and only when measurable.
* Maintain thread safety where required.
* Keep rendering abstractions backend-agnostic.

---

# Graphics Backend Rules

The graphics system must support abstract rendering backends.

Possible backend integrations include:

* OpenGL
* Vulkan
* DirectX
* Metal
* WebGL

Backend-specific implementations must remain isolated.

Public APIs must never expose backend-specific implementation details.

---

# TDD Requirements

All development must follow strict Test-Driven Development practices.

## Mandatory Workflow

1. Write failing tests.
2. Implement functionality.
3. Validate all tests.
4. Refactor safely.

No production code may be added without tests.

Every new feature, optimization, bug fix, or regression fix must include:

* Unit tests
* Integration tests when applicable
* Performance tests when applicable

---

# Testing Rules

Before completing any task:

* Run all tests.
* Ensure zero compilation errors.
* Ensure zero warnings whenever possible.
* Ensure compatibility across target frameworks.
* Ensure compatibility across supported platforms.

Performance-sensitive changes should include benchmarking or performance validation tests.

---

# File Generation Rules

Only C# source files may be created.

## Allowed

* `.cs`

## Forbidden

* `.md`
* `.txt`
* `.rst`
* `.docx`
* Temporary summary files
* Generated explanation files

Do not generate repository summary documents.

Do not generate migration documents.

Do not generate report files.

---

# Coding Standards

## Naming

* Use PascalCase for public members.
* Use camelCase for local variables and parameters.
* Use meaningful names.
* Avoid abbreviations unless industry standard.

## API Design

* Keep APIs explicit.
* Avoid ambiguous overloads.
* Avoid hidden behavior.
* Avoid magic values.

## Exceptions

* Use exceptions only for exceptional situations.
* Avoid exceptions in performance-critical paths.

## Threading

* Ensure thread safety where applicable.
* Avoid unnecessary synchronization overhead.

---

# Performance Rules

Performance is a first-class requirement.

All implementations should consider:

* CPU cache locality
* Allocation reduction
* SIMD opportunities
* Data-oriented design
* Rendering throughput
* Predictable frame timing

Do not introduce abstractions that significantly impact performance.

---

# Generator Rules

The generator project:

* Must generate deterministic code.
* Must not generate invalid code.
* Must preserve compatibility across frameworks.
* Must generate XML documentation.
* Must not introduce third-party dependencies.

Generated code quality must match manually written code quality.

---

# Sample Project Rules

Samples must:

* Demonstrate real usage
* Validate platform compatibility
* Remain minimal and maintainable
* Avoid unnecessary complexity

Samples are part of validation and must compile successfully.

---

# Agent Behavior Rules

The agent must:

* Respect existing architecture
* Avoid unnecessary refactors
* Preserve backward compatibility
* Minimize breaking changes
* Maintain API consistency
* Maintain deterministic behavior
* Prefer incremental safe changes

The agent must never:

* Introduce external dependencies
* Reduce compatibility targets
* Add undocumented APIs
* Add non-tested code
* Generate non-C# files

---

# Validation Checklist

Before finishing any task, verify:

* All tests pass
* All code compiles
* XML documentation exists
* No forbidden comments exist
* No external dependencies were added
* Cross-platform compatibility is preserved
* Multi-framework compatibility is preserved
* Performance characteristics were considered
* Public APIs remain coherent
* No unnecessary allocations were introduced

---

