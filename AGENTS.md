# AGENTS.md

# Alis Solution Agent Rules

## Project Overview

Alis is a fully managed high-performance multimedia, application, tooling, and game development ecosystem written entirely in C#.

The repository is a large-scale layered .NET monorepo organized by architectural responsibility and dependency direction.

The root solution is:

- `alis.sln`

All modules, tools, generators, tests, samples, and applications inside the repository must comply with the rules defined in this document.

The framework is designed around:
- High performance
- Cross-platform portability
- Long-term maintainability
- Deterministic execution
- Multi-framework compatibility
- Zero unnecessary dependencies
- Fully managed C# development
- Large-scale modular architecture

---

# Solution Architecture

The repository follows a strict layered architecture.

Folder numbering defines dependency direction.

Lower layers must never depend on higher layers.

## Layer Structure

### 1_Presentation
Presentation, UI, engine, frontend integrations, tooling frontends, visualization systems, runtime hosts, and application-facing APIs.

Contains:
- Engine
- Extensions
- UI systems
- Runtime presentation layers
- Platform frontends

### 2_Application
Application orchestration layer.

Contains:
- Main Alis applications
- Runtime composition
- Application integration logic
- Runtime startup systems
- Executable applications
- Samples

### 3_Structuration
Core structural abstractions and shared architecture foundations.

Contains:
- Core abstractions
- Base infrastructure
- Shared architecture systems

### 4_Operation
Operational modules and implementation systems.

Contains:
- Graphics
- Audio
- Media
- Runtime systems
- Platform operations
- Backend implementations

### 5_Declaration
Contracts, declarations, interfaces, metadata definitions, and declarative systems.

### 6_Ideation
Experimental systems, prototypes, research modules, and future concepts.

---

# Dependency Direction Rules

Dependencies must always respect the repository architecture.

Allowed direction:
```text
1_Presentation
    ↓
2_Application
    ↓
3_Structuration
    ↓
4_Operation
    ↓
5_Declaration
    ↓
6_Ideation
```

Reverse dependencies are forbidden.

Cross-layer violations are forbidden.

Agents must never introduce architectural dependency violations.

The dependency rules are enforced through:
- `.config/Config.props`
- Shared MSBuild imports
- Conditional `ProjectReference` rules

---

# Repository Structure

## Root Solution
- `alis.sln`

## Shared Configuration
- `.config/`

Contains:
- Shared MSBuild props
- Shared targets
- Common project templates
- Multi-targeting configuration
- Runtime packaging rules
- Shared test configuration

Important files:
- `.config/Config.props`
- `.config/default/default_csproj.props`
- `.config/default/default_test_csproj.props`

---

# Main Repository Areas

## Presentation Layer
- `1_Presentation/`

Contains:
- Engine
- Extensions
- UI systems
- Visualization systems
- Runtime frontends

Example:
- `1_Presentation/Engine/src/`

---

## Application Layer
- `2_Application/`

Contains:
- Main applications
- Runtime integration
- Samples
- Executable compositions

Example:
- `2_Application/Alis/src/Alis.csproj`

---

## Structuration Layer
- `3_Structuration/`

Contains:
- Core architecture
- Shared abstractions
- Base systems

Example:
- `3_Structuration/Core/src/Alis.Core.csproj`

---

## Operation Layer
- `4_Operation/`

Contains:
- Graphics
- Media
- Runtime systems
- Platform implementations
- Native integrations

Example:
- `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

---

## Declaration Layer
- `5_Declaration/`

Contains:
- Contracts
- Interfaces
- Shared declarations
- Metadata systems

---

## Ideation Layer
- `6_Ideation/`

Contains:
- Experimental systems
- Research modules
- Prototype implementations

---

# Platform Compatibility

All code must remain compatible with the supported platforms.

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

All systems must be designed with platform abstraction and portability in mind.

Platform-specific implementations must remain isolated.

---

# Framework Compatibility

All code must remain compatible with all supported frameworks.

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

# Build and Test Workflows

## Restore
```bash
dotnet restore alis.sln
```

## Build
```bash
dotnet build alis.sln -c Debug
```

## Run Tests
```bash
dotnet test alis.sln
```

---

# Repository Scripts

## Test Scripts
- `docs/scripts/macos/run_tests.sh`

Runs:
- Debug tests
- Release tests
- All test projects

Skips:
- Templates

---

## Build Scripts
- `docs/scripts/macos/build_all.sh`
- `docs/scripts/macos/pack_all.sh`

These scripts:
- Iterate all projects
- Handle runtime packaging
- Apply repository-wide conventions

---

# Project Rules

## Project Creation Rules

Agents must never:
- Create new projects
- Create new solutions
- Modify repository architecture
- Change dependency directions

Agents must not:
- Edit `.csproj` configurations unless explicitly requested
- Modify shared build infrastructure without necessity

The repository structure is intentionally automated and convention-driven.

---

# Dependency Policy

Third-party dependencies are strictly prohibited.

## Forbidden
- External NuGet packages
- Community libraries
- External frameworks
- Third-party runtime helpers
- Dependency injection frameworks
- External serialization libraries
- External utility libraries

## Allowed
- Standard .NET libraries
- System libraries
- Native platform APIs
- OpenGL
- Vulkan
- Metal
- DirectX
- Internal framework modules

The framework must remain fully self-contained.

---

# Source Generator Rules

Source generators are first-class architecture components.

Generators are referenced through analyzers using:
- `OutputItemType="Analyzer"`

Generators must:
- Produce deterministic code
- Preserve compatibility
- Avoid allocations when possible
- Generate XML documentation
- Never generate invalid code

Generated code quality must match manual code quality.

---

# Language Rules

Everything must be written entirely in English.

## Mandatory English Usage
- Source code
- APIs
- Documentation
- XML comments
- Tests
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
/// Represents a graphics device.
/// </summary>
public sealed class GraphicDevice
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

Documentation must be:
- Technical
- Precise
- Maintainable
- Consistent

All public, protected, and internal APIs must be documented.

---

# File Generation Rules

Only C# source files may be created.

## Allowed
- `.cs`

## Forbidden
- `.md`
- `.txt`
- `.rst`
- `.json`
- `.yaml`
- `.yml`
- `.xml`
- `.docx`
- Temporary reports
- Summary files
- Migration files

Agents must not generate repository documentation files.

---

# Coding Standards

## General Principles
- Prefer explicit code.
- Prefer deterministic behavior.
- Prefer predictable memory usage.
- Prefer maintainable abstractions.
- Prefer performance-oriented design.

---

## Naming Rules
- PascalCase for types and members
- camelCase for locals and parameters
- Meaningful names only
- Avoid unclear abbreviations

---

## Performance Rules

Performance is a first-class requirement.

All implementations should consider:
- Allocation reduction
- Cache locality
- SIMD opportunities
- Data-oriented design
- Deterministic execution
- Low-overhead abstractions

Avoid:
- LINQ in hot paths
- Boxing
- Reflection
- Hidden allocations
- Unnecessary heap allocations

Use spans and memory-efficient APIs when target compatibility allows.

---

# Architecture Rules

## Mandatory Principles
- Cross-platform portability
- Backend abstraction
- Minimal overhead
- API consistency
- Deterministic behavior
- Thread safety where required

---

## Forbidden Practices
- Hidden side effects
- Global mutable state when avoidable
- Runtime-specific assumptions
- Platform leaks into shared APIs
- Architecture shortcuts that break layering

---

# Graphics and Native Backend Rules

Graphics systems may integrate:
- OpenGL
- Vulkan
- DirectX
- Metal
- WebGL

Backend-specific implementations must remain isolated behind abstractions.

Public APIs must remain backend-agnostic.

---

# Testing Rules

All development must follow strict TDD practices.

## Mandatory Workflow
1. Write failing tests
2. Implement functionality
3. Validate tests
4. Refactor safely

---

# Test Requirements

Every code change must include:
- Unit tests
- Integration tests when applicable
- Regression tests when applicable
- Performance tests for performance-sensitive code

---

# Test Infrastructure

The repository uses:
- xUnit
- Xunit.StaFact
- Moq
- coverlet.collector

Shared configuration:
- `.config/default/default_test_csproj.props`

---

# Test Output Rules

Test results are stored under:
```text
.test/<TargetFramework>/
```

---

# Samples Rules

Samples must:
- Compile successfully
- Demonstrate real usage
- Validate platform behavior
- Remain minimal
- Avoid unnecessary complexity

---

# Packaging and Runtime Rules

The repository contains:
- Runtime packaging
- Asset packing
- Native runtime bundling
- Platform-specific publishing

Do not modify:
- Output paths
- Packaging logic
- Runtime bundle structure

without explicit necessity.

---

# Agent Behavior Rules

The agent must:
- Respect repository architecture
- Preserve compatibility
- Minimize breaking changes
- Keep APIs coherent
- Avoid unnecessary refactors
- Follow existing conventions
- Maintain performance characteristics

The agent must never:
- Add external dependencies
- Create new projects
- Change solution architecture
- Reduce compatibility targets
- Add undocumented APIs
- Generate unsupported files

---

# Validation Checklist

Before completing any task verify:

- All tests pass
- All projects compile
- No forbidden comments exist
- XML documentation exists
- No external dependencies were added
- Platform compatibility is preserved
- Multi-framework compatibility is preserved
- Performance impact was considered
- Architecture rules were respected
- No dependency direction violations were introduced
- No unsupported files were generated
