# AGENTS.md

# Alis.Core.Graphic.Generator Agent Rules

## Project Overview

Alis is a fully managed high-performance multimedia and game development framework written entirely in C#.

This agent works specifically on the generator module:

- `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj`

The purpose of this project is to provide deterministic compile-time code generation for the graphics subsystem.

This module is responsible for:
- Source generation
- Compile-time metadata generation
- API generation
- Rendering bindings generation
- Interop generation
- Boilerplate reduction
- Compile-time validation
- Reflection elimination strategies
- Performance-oriented code emission
- Deterministic code production

The generator project is considered critical infrastructure for the graphics framework architecture.

Generated code must behave exactly as if it were manually written production-quality code.

---

# Repository Structure

## Graphics Runtime Module
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

Contains:
- Graphics abstractions
- Rendering systems
- Backend implementations
- Rendering pipelines
- Resource management
- Platform integrations

Generated code must integrate seamlessly with the runtime module.

---

## Graphics Generator
- `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj`

Contains:
- Source generators
- Compile-time generation systems
- Syntax analysis systems
- Semantic analysis systems
- Metadata generation systems
- Code emission systems

This project is responsible for deterministic code generation across the graphics stack.

---

## Graphics Samples
- `4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj`

Contains:
- Runtime examples
- Backend demonstrations
- Graphics API showcase implementations

Generated APIs must remain usable and understandable inside sample projects.

---

## Graphics Tests
- `4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj`

Contains:
- Generator validation tests
- API validation tests
- Regression tests
- Integration tests

Generated code must always remain fully testable.

---

# Generator Philosophy

Generators are considered production infrastructure.

Generated code must:
- Be deterministic
- Be readable
- Be maintainable
- Be stable
- Be performant
- Be allocation-aware
- Be backend-safe
- Be cross-platform compatible
- Be multi-framework compatible

Generated code quality must match manually written production code.

---

# Deterministic Generation Rules

Generation must always produce identical output for identical input.

Generators must avoid:
- Non-deterministic ordering
- Time-based generation
- Environment-based generation
- Machine-specific output
- Randomized behavior

Generated output must remain stable across:
- Machines
- Runtimes
- Operating systems
- Build environments

---

# Platform Compatibility

Generated code must remain compatible with all supported platforms.

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

Generators must avoid generating platform-specific assumptions into shared APIs.

---

# Framework Compatibility

Generated code must remain compatible with all supported frameworks.

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

Generators must not emit APIs unsupported by older targets unless guarded through conditional compilation.

Backward compatibility is mandatory.

---

# Source Generator Rules

Generators must:
- Produce valid C# code
- Produce compilable code
- Produce deterministic code
- Produce XML documentation
- Avoid hidden allocations
- Avoid reflection-heavy runtime paths
- Avoid runtime code generation
- Prefer compile-time resolution

Generated code must:
- Follow repository naming conventions
- Follow repository architecture rules
- Follow repository documentation rules
- Follow repository performance rules

---

# Roslyn Usage Rules

Generators may use:
- Roslyn syntax analysis
- Roslyn semantic analysis
- Incremental generation patterns
- Compile-time symbol analysis

Generators should:
- Minimize semantic model usage
- Cache analysis results when possible
- Avoid repeated tree traversal
- Prefer incremental generation patterns

Avoid unnecessary compiler overhead.

---

# Code Emission Rules

Generated code must:
- Use deterministic ordering
- Use stable formatting
- Use explicit naming
- Avoid ambiguous APIs
- Avoid hidden behavior
- Avoid runtime reflection dependencies

Generated members must remain understandable for developers debugging generated code.

---

# Documentation Rules

All generated APIs must contain XML documentation comments.

Only XML documentation comments are allowed.

## Allowed
```csharp
/// <summary>
/// Represents a generated graphics binding.
/// </summary>
public sealed partial class GeneratedGraphicBinding
{
}
```

## Forbidden
```csharp
// Single-line comments

/* Multi-line comments */
```

Do not generate:
- `//`
- `/* */`

Documentation must remain technical and maintainable.

---

# Language Rules

Everything must be written entirely in English.

## Mandatory English Usage
- Generated APIs
- Generated identifiers
- XML documentation
- Diagnostics
- Exception messages
- Variable names
- Type names

Mixed-language generated code is forbidden.

---

# Diagnostics Rules

Generators should produce:
- Clear diagnostics
- Actionable diagnostics
- Deterministic diagnostics
- Stable diagnostic identifiers

Diagnostics must:
- Explain the issue clearly
- Avoid ambiguous wording
- Avoid unnecessary verbosity

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden
- External NuGet packages
- Third-party code generators
- External templating engines
- External serialization libraries
- Community utilities

## Allowed
- Standard .NET libraries
- Roslyn APIs
- Internal framework modules

The framework must remain fully self-contained.

---

# Performance Rules

Performance is a first-class requirement.

Generators should minimize:
- Memory allocations
- Semantic model usage
- String allocations
- Repeated syntax traversal
- Reflection usage

Avoid:
- LINQ in hot generation paths
- Unnecessary boxing
- Repeated parsing
- Excessive temporary allocations

Generated runtime code should also remain allocation-aware.

---

# Architecture Rules

Generators must:
- Respect backend abstraction
- Respect platform abstraction
- Preserve API consistency
- Avoid leaking implementation details
- Preserve deterministic architecture behavior

Generated APIs must remain backend-agnostic whenever possible.

---

# Testing Rules

All generator changes must include validation.

Required validation may include:
- Snapshot validation
- Generated syntax validation
- Semantic validation
- Compilation validation
- API contract validation
- Regression validation

Generated code must always compile successfully.

---

# File Generation Rules

Only C# source files may be generated.

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
- Generated summaries

Do not generate auxiliary documentation files.

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
- PascalCase for public APIs
- camelCase for locals and parameters
- Use meaningful names
- Avoid unclear abbreviations

---

## Code Quality Rules
- Prefer explicit generation
- Prefer maintainable generation logic
- Keep generated APIs understandable
- Keep generation deterministic
- Keep generation pipelines predictable

---

# Generator Stability Rules

Generators must remain:
- Stable across builds
- Stable across runtimes
- Stable across operating systems
- Stable across framework targets

Generated output instability is considered a regression.

---

# Agent Behavior Rules

The agent must:
- Respect repository architecture
- Preserve deterministic generation
- Preserve compatibility
- Maintain generator readability
- Maintain API consistency
- Prefer incremental safe changes

The agent must never:
- Introduce external dependencies
- Introduce non-deterministic generation
- Generate undocumented APIs
- Generate unsupported files
- Reduce portability

---

# Validation Checklist

Before finishing any task verify:

- Generated code compiles
- All tests pass
- XML documentation exists
- No forbidden comments exist
- No external dependencies were added
- Platform compatibility is preserved
- Multi-framework compatibility is preserved
- Generated output remains deterministic
- Performance characteristics were considered
- Public APIs remain coherent
- No unnecessary allocations were introduced
- Backend abstraction integrity is preserved
- Generated code remains stable across builds
