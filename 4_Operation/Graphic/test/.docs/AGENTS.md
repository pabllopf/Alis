# AGENTS.md

# Alis.Core.Graphic.Test Agent Rules

## Project Overview

Alis is a fully managed high-performance multimedia and game development framework written entirely in C#.

This agent works specifically on the test module:

- `4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj`

The purpose of this project is to validate the entire graphics subsystem of the Alis framework across all supported frameworks, runtimes, architectures, rendering backends, and operating systems.

This module is responsible for:
- Unit testing
- Integration testing
- Rendering validation
- Performance validation
- Regression prevention
- API contract validation
- Allocation validation
- Thread safety validation
- Cross-platform compatibility validation
- Backend abstraction validation

This project is a critical quality gate for the graphics stack.

All changes inside `Alis.Core.Graphic` must be validated through this test project.

---

# Repository Structure

## Graphics Runtime Module
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

Contains:
- Graphics abstractions
- Rendering systems
- Backend implementations
- Resource management
- Rendering pipelines
- Platform integrations

---

## Graphics Generator
- `4_Operation/Graphic/generator/Alis.Core.Graphic.Generator.csproj`

Contains:
- Automatic code generation systems
- Source generators
- Compile-time generation utilities

Generated code must also be validated through tests.

---

## Graphics Samples
- `4_Operation/Graphic/sample/Alis.Core.Graphic.Sample.csproj`

Contains:
- Runtime validation samples
- Rendering examples
- Platform validation examples
- Backend demonstrations

Samples are used as validation references for integration tests.

---

## Graphics Tests
- `4_Operation/Graphic/test/Alis.Core.Graphic.Test.csproj`

Contains:
- Unit tests
- Integration tests
- Regression tests
- Performance tests
- Stress tests
- Platform validation tests
- Rendering validation tests
- API contract tests
- Allocation tests

This is the authoritative validation project for the graphics module.

---

# Platform Compatibility

All tests must validate compatibility across supported platforms whenever possible.

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

Tests must avoid assumptions tied to a single runtime or operating system.

Platform-specific behavior must be isolated and explicitly validated.

---

# Framework Compatibility

All tests must remain compatible with every supported framework target.

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

Tests must not use APIs unavailable on older targets unless protected through conditional compilation.

Backward compatibility validation is mandatory.

---

# Testing Philosophy

Testing is considered a first-class architecture component.

The graphics module must prioritize:
- Deterministic behavior
- Predictable execution
- Rendering consistency
- Stable API contracts
- Low allocation patterns
- Backend abstraction integrity

Tests must validate all of these guarantees.

---

# TDD Rules

All development must follow strict Test-Driven Development practices.

## Mandatory Workflow

1. Create failing tests
2. Implement production code
3. Validate all tests
4. Refactor safely

No production feature is considered complete without tests.

---

# Mandatory Test Coverage

Every new change must include appropriate validation.

## Required Coverage
- Public APIs
- Internal behavior
- Rendering logic
- Resource lifecycle
- Error handling
- Thread safety
- Platform abstraction
- Backend abstraction
- Allocation behavior
- Performance-sensitive paths

---

# Required Test Types

## Unit Tests
Validate isolated behavior.

Examples:
- State transitions
- Resource validation
- Parameter validation
- Mathematical correctness
- API contracts

---

## Integration Tests
Validate collaboration between systems.

Examples:
- Backend integration
- Resource pipelines
- Rendering flows
- Window integrations
- Command submission

---

## Regression Tests
Prevent previously fixed issues from reappearing.

Every bug fix should include a regression test whenever possible.

---

## Performance Tests
Validate:
- Allocation behavior
- CPU overhead
- Rendering throughput
- Resource creation costs
- Synchronization overhead

Performance regressions are considered failures.

---

## Stress Tests
Validate:
- High-frequency rendering
- Resource exhaustion
- Large-scale resource creation
- Thread contention
- Repeated initialization and disposal

---

# Test Architecture Rules

Tests must:
- Remain deterministic
- Avoid flaky behavior
- Avoid timing-sensitive assumptions
- Avoid hidden dependencies
- Avoid shared mutable state
- Avoid platform assumptions when unnecessary

Tests must be isolated and reproducible.

---

# Test Naming Rules

Test names must clearly describe:
- The scenario
- The condition
- The expected result

## Recommended Pattern
```text
MethodName_StateUnderTest_ExpectedBehavior
```

Example:
```text
CreateTexture_WithInvalidDimensions_ShouldThrowException
```

---

# Assertion Rules

Assertions must:
- Be explicit
- Validate exact behavior
- Avoid ambiguous checks
- Avoid overly broad validation

Do not create weak assertions.

---

# Performance Validation Rules

Performance-sensitive tests should validate:
- Allocation counts
- Resource reuse
- Execution cost
- Frame stability
- Rendering overhead

Avoid hidden allocations in hot paths.

Avoid unnecessary object creation.

---

# Graphics Backend Validation Rules

Tests should validate backend abstraction behavior for:
- OpenGL
- Vulkan
- DirectX
- Metal
- WebGL

Backend-specific implementations must remain isolated.

Shared APIs must remain backend-agnostic.

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden
- External NuGet packages
- Third-party testing libraries beyond repository-approved dependencies
- Benchmark frameworks not already present in the repository
- External mocking frameworks not already used in the repository

## Allowed
- Standard .NET libraries
- Internal framework modules
- Existing repository-approved test infrastructure

Do not introduce new dependencies.

---

# Language Rules

Everything must be written entirely in English.

## Mandatory English Usage
- Source code
- Tests
- XML documentation
- Assertion messages
- Exception messages
- Identifiers
- Variables
- Type names

Mixed-language code is forbidden.

---

# Documentation Rules

Only XML documentation comments are allowed.

## Allowed
```csharp
/// <summary>
/// Validates texture creation behavior.
/// </summary>
public sealed class TextureCreationTest
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
- Temporary report files
- Generated summaries

Do not generate additional documentation files.

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
- Keep tests readable
- Keep assertions explicit
- Keep setups minimal
- Avoid duplicated validation logic
- Prefer deterministic helpers

---

# Performance Rules

Performance is a critical validation target.

Tests must help detect:
- Hidden allocations
- Boxing
- Reflection overhead
- Synchronization bottlenecks
- Rendering stalls

Avoid:
- LINQ in performance-sensitive tests
- Unnecessary allocations
- Non-deterministic waits

---

# Agent Behavior Rules

The agent must:
- Respect repository architecture
- Preserve compatibility
- Preserve determinism
- Preserve backend abstraction
- Maintain test reliability
- Maintain test readability
- Prefer incremental safe changes

The agent must never:
- Add flaky tests
- Add timing-dependent tests
- Add undocumented APIs
- Introduce external dependencies
- Generate unsupported files

---

# Validation Checklist

Before finishing any task verify:

- All tests pass
- All code compiles
- XML documentation exists
- No forbidden comments exist
- No external dependencies were added
- Platform compatibility is preserved
- Multi-framework compatibility is preserved
- Test determinism is preserved
- Performance regressions were considered
- Public APIs remain coherent
- No unnecessary allocations were introduced
- Backend abstraction integrity is preserved

