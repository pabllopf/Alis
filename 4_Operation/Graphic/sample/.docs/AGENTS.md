# AGENTS.md

# Alis.Core.Graphic.Sample Agent Rules

## Project Overview

Alis is a fully managed high-performance multimedia and game development framework written entirely in C#.

This agent works specifically on the sample module:

- `4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj`

The purpose of this project is to provide:
- Real graphics usage examples
- Rendering demonstrations
- Platform validation scenarios
- Backend integration demonstrations
- Graphics API showcase implementations
- Runtime validation examples
- Developer reference implementations
- Manual testing environments

The sample project acts as both:
- A practical documentation layer
- A runtime validation layer

Samples must demonstrate correct usage patterns for the graphics framework.

---

# Repository Structure

## Graphics Runtime Module
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

Contains:
- Graphics abstractions
- Rendering systems
- Resource management
- Rendering pipelines
- Backend implementations
- Platform integrations

---

## Graphics Generator
- `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj`

Contains:
- Source generators
- Automatic code generation systems
- Compile-time utilities

Generated code must remain compatible with all sample scenarios.

---

## Graphics Samples
- `4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj`

Contains:
- Rendering examples
- Graphics demonstrations
- Platform validation scenarios
- Backend validation samples
- Resource lifecycle demonstrations
- Rendering loop examples
- API showcase implementations

This project is the primary developer-facing graphics example environment.

---

## Graphics Tests
- `4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj`

Contains:
- Unit tests
- Integration tests
- Performance tests
- Regression tests
- Stress tests

Sample implementations should remain compatible with test validation rules.

---

# Sample Philosophy

Samples are considered production-quality reference implementations.

They must:
- Demonstrate correct architecture
- Demonstrate correct API usage
- Demonstrate best practices
- Remain maintainable
- Remain deterministic
- Remain minimal
- Remain portable

Samples are not experimental playgrounds.

Samples should teach proper framework usage.

---

# Platform Compatibility

All samples must remain compatible with supported platforms whenever possible.

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

Samples must avoid runtime assumptions tied to a single platform.

Platform-specific examples must remain isolated.

---

# Framework Compatibility

All sample code must remain compatible with all supported frameworks.

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

Do not use APIs unavailable on older targets unless protected through conditional compilation.

Backward compatibility is mandatory.

---

# Sample Design Rules

Samples must:
- Be easy to understand
- Be deterministic
- Be self-contained
- Avoid unnecessary complexity
- Avoid unnecessary abstractions
- Prefer clarity over cleverness
- Demonstrate intended usage patterns

Samples should remain concise while still demonstrating realistic usage.

---

# Demonstration Requirements

Samples should demonstrate:
- Graphics initialization
- Rendering loops
- Resource creation
- Resource disposal
- Backend abstraction usage
- Platform abstraction usage
- Rendering state management
- Buffer usage
- Texture usage
- Shader usage
- Frame lifecycle management

Examples should represent real-world framework usage.

---

# Rendering Rules

Samples should validate:
- Correct rendering behavior
- Stable frame execution
- Correct resource lifecycle management
- Backend portability
- Deterministic rendering flows

Rendering examples must remain backend-agnostic whenever possible.

---

# Backend Validation Rules

The graphics framework may support:
- OpenGL
- Vulkan
- DirectX
- Metal
- WebGL

Samples must not expose backend-specific implementation details through public APIs.

Backend-specific demonstrations must remain isolated.

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden
- External NuGet packages
- Third-party frameworks
- External helper libraries
- Community utilities
- External rendering wrappers

## Allowed
- Standard .NET libraries
- Native platform APIs
- OpenGL
- Vulkan
- DirectX
- Metal
- Internal framework modules

The framework must remain fully self-contained.

---

# Language Rules

Everything must be written entirely in English.

## Mandatory English Usage
- Source code
- APIs
- XML documentation
- Example names
- Window titles
- Variables
- Type names
- Exception messages

Mixed-language code is forbidden.

---

# Documentation Rules

Only XML documentation comments are allowed.

## Allowed
```csharp
/// <summary>
/// Demonstrates texture rendering.
/// </summary>
public sealed class TextureRenderingSample
{
}
```

## Forbidden
```csharp
// Single-line comments

/* Multi-line comments */
```

Do not use:
- `//`
- `/* */`

Documentation must remain technical and maintainable.

---

# File Generation Rules

Only C# source files may be created.

## Allowed
- `.cs`

## Forbidden
- `.md`
- `.txt`
- `.json`
- `.yaml`
- `.xml`
- `.docx`
- Temporary reports
- Summary files

Do not generate additional documentation files.

---

# Performance Rules

Performance is a first-class requirement.

Samples should demonstrate:
- Efficient rendering usage
- Proper resource reuse
- Predictable frame execution
- Minimal allocations
- Stable rendering loops

Avoid:
- LINQ in hot paths
- Hidden allocations
- Reflection
- Excessive abstractions
- Unnecessary object creation

---

# Architecture Rules

Samples must:
- Respect backend abstraction
- Respect platform abstraction
- Preserve API consistency
- Avoid leaking implementation details
- Demonstrate intended architecture patterns

Do not bypass framework abstractions.

---

# Testing and Validation Rules

All sample changes should be validated through:
- Compilation validation
- Runtime validation
- Cross-platform validation when possible
- Rendering validation
- Integration validation

Samples must compile successfully at all times.

Broken samples are considered repository failures.

---

# Project Rules

Agents must never:
- Create new projects
- Modify solution structure
- Modify `.csproj` configuration unless explicitly requested
- Introduce external dependencies
- Reduce compatibility targets

The repository structure is convention-driven and automated.

---

# Coding Standards

## Naming Rules
- PascalCase for public members
- camelCase for locals and parameters
- Use meaningful names
- Avoid unclear abbreviations

---

## Code Quality Rules
- Prefer readability
- Prefer maintainability
- Keep initialization explicit
- Keep rendering flows understandable
- Avoid unnecessary helper abstractions

---

# Sample UX Rules

Samples should:
- Start predictably
- Shut down cleanly
- Dispose resources correctly
- Avoid hidden state
- Avoid unexpected runtime behavior

Window behavior and rendering behavior should remain deterministic.

---

# Agent Behavior Rules

The agent must:
- Respect repository architecture
- Preserve compatibility
- Preserve determinism
- Maintain sample readability
- Maintain API consistency
- Prefer incremental safe changes

The agent must never:
- Introduce external dependencies
- Introduce backend leaks
- Add undocumented APIs
- Add unsupported files
- Reduce portability

---

# Validation Checklist

Before finishing any task verify:

- All samples compile
- All code compiles
- XML documentation exists
- No forbidden comments exist
- No external dependencies were added
- Platform compatibility is preserved
- Multi-framework compatibility is preserved
- Rendering behavior remains deterministic
- Performance characteristics were considered
- Public APIs remain coherent
- No unnecessary allocations were introduced
- Backend abstraction integrity is preserved

