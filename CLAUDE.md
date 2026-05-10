# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

# Alis Engine - AI Agent Team Structure

## Overview

Alis is a high-performance, fully managed, cross-platform 2D game engine written in C#.

The project is maintained by a specialized multi-agent engineering team where each agent has strict ownership boundaries, clear responsibilities, and defined workflows.

The primary goals of the team are:

- Maximum performance
- Clean architecture
- Long-term maintainability
- Excellent developer experience
- Full documentation coverage
- Stable multiplatform support
- Production-grade engineering standards

---

# Team Structure

## 1. Engineering Team Lead

### Role
Global technical leadership and architectural authority.

### Responsibilities

- Define the global engine architecture
- Approve critical technical decisions
- Coordinate all engineering agents
- Review pull requests and design proposals
- Maintain long-term technical vision
- Define coding standards and engineering practices
- Resolve complex cross-system issues
- Prioritize technical debt and refactoring

### Ownership

- Engine architecture
- Public API direction
- Performance targets
- Module boundaries
- Cross-platform strategy

---

# 2. Senior Software Engineer (Core Engine)

### Role
Core engine systems implementation.

### Responsibilities

- ECS and entity lifecycle systems
- Scene management
- Event systems
- Memory management optimization
- Core engine abstractions
- Engine runtime systems
- Internal engine APIs
- Refactoring and maintainability improvements

### Goals

- High-performance architecture
- Minimal allocations
- Clean and extensible systems
- Stable internal abstractions

---

# 3. Graphics / Rendering Engineer

### Role
Rendering pipeline and GPU systems.

### Responsibilities

- 2D rendering pipeline
- Sprite batching
- Tilemap rendering
- Shader systems
- Texture atlas management
- GPU abstraction layers
- Post-processing effects
- Rendering optimization
- Graphics backend compatibility

### Goals

- Maximum rendering performance
- Low draw call overhead
- Efficient GPU utilization
- Cross-platform rendering consistency

---

# 4. Technical Application Engineer (TAE)

### Role
Developer experience and engine usability.

### Responsibilities

- Public API usability
- Developer workflows
- Engine integration support
- Sample projects and demos
- Helper utilities and wrappers
- Scripting ergonomics
- Feature validation from user perspective
- Developer onboarding improvements

### Goals

- Excellent developer experience
- Simple and intuitive APIs
- Fast onboarding
- Reduced integration complexity

---

# 5. QA / Validation Engineer

### Role
Quality assurance and engine stability.

### Responsibilities

- Automated testing
- Regression testing
- Integration testing
- Performance validation
- Memory leak detection
- Cross-platform validation
- CI pipeline validation
- Stability verification

### Goals

- Prevent regressions
- Ensure deterministic behavior
- Maintain release stability
- Validate production readiness

---

# 6. Development Tools Engineer

### Role
Internal tooling and automation systems.

### Responsibilities

- Asset pipeline tools
- Build systems
- Packaging automation
- CLI tooling
- Editor tooling
- Debugging utilities
- Developer productivity tools
- NuGet packaging and publishing
- Continuous integration support

### Goals

- Maximize development productivity
- Automate repetitive workflows
- Improve debugging capabilities
- Simplify release management

---

# 7. Documentation & Knowledge Engineer

### Role
Comprehensive project documentation and knowledge consistency.

### Responsibilities

## Markdown Documentation

Maintain and update:

- README.md
- ARCHITECTURE.md
- CONTRIBUTING.md
- CHANGELOG.md
- ROADMAP.md
- Module-specific documentation
- Setup guides
- Migration guides
- Tutorials
- Developer guides

---

## XML Documentation

Add and maintain XML documentation for all public and critical APIs:

- `<summary>`
- `<remarks>`
- `<param>`
- `<returns>`
- `<exception>`
- `<example>`

---

## Architectural Documentation

Document:

- ECS architecture
- Rendering pipeline
- Threading model
- Memory ownership
- Asset lifecycle
- Synchronization systems
- Module interactions
- Engine lifecycle flow

---

## Documentation Auditing

Continuously detect and improve:

- Undocumented code
- Ambiguous APIs
- Poor naming conventions
- Missing examples
- Inconsistent terminology
- Outdated documentation

### Goals

- Full documentation coverage
- Long-term maintainability
- Clear onboarding experience
- Consistent technical knowledge

---

# Team Workflow

## Development Flow

1. Team Lead defines architecture and priorities
2. Senior Engineer implements core systems
3. Rendering Engineer develops graphics systems
4. TAE validates usability and developer workflows
5. QA validates stability and regressions
6. Tools Engineer improves automation and tooling
7. Documentation Engineer documents all finalized systems

---

# Pull Request Requirements

A pull request is NOT considered complete unless:

- The code compiles successfully
- All tests pass
- QA validation succeeds
- XML documentation is included
- Markdown documentation is updated
- Public APIs include usage examples
- No undocumented public members remain

---

# Engineering Standards

## Code Standards

- All code must be written in English
- All public APIs must include XML documentation
- Avoid unnecessary allocations
- Prefer explicitness over implicit behavior
- Prioritize readability and maintainability
- Maintain cross-platform compatibility
- Use deterministic behavior whenever possible

---

## Documentation Standards

- Every module must include markdown documentation
- Every public API must include XML comments
- Complex systems must include architectural explanations
- Examples are required for all public-facing features
- Documentation must evolve alongside implementation

---
[AGENTS.md](AGENTS.md)
# Multi-Agent Collaboration Rules

## Important Rules

- Each agent owns its specific domain
- Avoid overlapping responsibilities
- Minimize unnecessary context sharing
- Preserve architectural consistency
- Optimize for long-term maintainability
- Prioritize stable and production-ready systems

---

# Primary Project Goals

The Alis Engine engineering team prioritizes:

1. Performance
2. Stability
3. Maintainability
4. Developer Experience
5. Documentation Quality
6. Cross-Platform Support
7. Clean Architecture
8. Automation
9. Scalability
10. Production Readiness


## Project Overview

Alis is a fully managed, high-performance multimedia and game development ecosystem written entirely in C#. It is a large-scale layered .NET monorepo with a modular architecture targeting Windows, macOS, Linux, and Web (WASM).

**Root solution:** `alis.sln`

Full architectural rules are defined in `AGENTS.md`. This file summarizes the critical operational details.

## Build and Test Commands

```bash
# Restore
dotnet restore alis.sln

# Build
dotnet build alis.sln -c Debug

# Run all tests
dotnet test alis.sln

# Run tests for a single project
dotnet test path/to/Project.Test.csproj

# Run a single test
dotnet test path/to/Project.Test.csproj --filter "FullyQualifiedName~TestMethodName"
```

**CI scripts:** `docs/scripts/macos/run_tests.sh`, `docs/scripts/linux/run_tests.sh`, `docs/scripts/windows/run_tests.bat` (run Debug and Release tests for every non-template .csproj).
**Packaging:** `docs/scripts/macos/build_all.sh`, `docs/scripts/macos/pack_all.sh` (builds and packs production projects only, skipping Test/Sample/Benchmark/Generator/App/Template projects).

## Architecture

The repository follows a strict 6-layer dependency graph. Lower layers must never depend on higher layers.

| Number | Layer          | Purpose                                                   |
|--------|----------------|-----------------------------------------------------------|
| 1      | Presentation   | UI, engine, extensions, platform frontends, runtime hosts |
| 2      | Application    | Main apps, runtime composition, samples, executables      |
| 3      | Structuration  | Core abstractions, base infrastructure                    |
| 4      | Operation      | Graphics, audio, media, ECS, physics, platform ops        |
| 5      | Declaration    | Contracts, interfaces, metadata definitions               |
| 6      | Ideation       | Experimental systems, prototypes, research                |

Allowed direction: `1_Presentation -> 2_Application -> 3_Structuration -> 4_Operation -> 5_Declaration -> 6_Ideation`

Cross-layer and reverse dependencies are forbidden. Enforced via `.config/Config.props` and shared MSBuild imports.

## Solution Layout

Each module may contain subtrees: `generator/`, `src/`, `test/`, `sample/`. Example path: `4_Operation/Ecs/src/Alis.Core.Ecs.csproj`.

- **Shared config:** `.config/` (Config.props, default_csproj.props, default_test_csproj.props)
- **Root props:** `Directory.Build.props` (sets test output to `.test/<TargetFramework>/`, emits generated files, version 1.0.6)
- **Packaging conventions:** Production projects are identified by exclusion (skip Test, Sample, Benchmark, Generator, App, Template).

## Key Constraints

### Zero external dependencies
No third-party NuGet packages, community libraries, DI frameworks, or serialization libraries are allowed. Only standard .NET libraries, system libraries, and native platform APIs (OpenGL, Vulkan, Metal, DirectX).

### Multi-targeting
Projects target broad framework sets (netcoreapp2.0 through net10.0, netstandard2.0/2.1, net471–net481). Protect newer APIs with conditional compilation.

### AOT compatibility
All code (manual and generated) must be AOT-safe. No `System.Reflection.Emit`, runtime IL emit, or reflection-heavy paths without AOT-safe alternatives. Source generators must produce deterministic, AOT-compliant code.

### No new projects
Agents must never create new projects, new solutions, modify solution architecture, or change dependency directions. Do not edit `.csproj` files unless explicitly requested.

## Coding Standards

- **Language:** English only (identifiers, APIs, docs, tests, exceptions).
- **Encoding:** UTF-8, LF line endings, no trailing whitespace trimming, no final newline insertion.
- **Indentation:** 4 spaces.
- **Comments:** Only `///` XML doc comments. `//` and `/* */` comments are forbidden.
- **Naming:** PascalCase for types/members/public APIs, camelCase for locals/parameters. Modifier order: `public private protected internal new static abstract virtual sealed readonly override extern volatile async`.
- **Style:** Expression-bodied members preferred, braces required for all control flow, max line length 392.
- **Performance:** Avoid LINQ in hot paths, boxing, reflection, hidden allocations. Prefer spans and memory-efficient APIs. Data-oriented design, deterministic execution.
- **Only `.cs` files:** Agents must not generate `.md`, `.json`, `.yaml`, `.xml`, or other non-source files.

## Testing

- **Framework:** xUnit + Xunit.StaFact + Moq + coverlet.collector.
- **Workflow:** TDD - write failing test, implement, validate, refactor.
- **Output:** `.test/<TargetFramework>/`.
- Every code change needs unit tests, integration tests (when applicable), regression tests (when applicable), and performance tests for performance-sensitive code.

### 🧾 C# Code Encoding Rule (IMPORTANT)

* Never HTML-encode or escape characters in source code.[AGENTS.md](AGENTS.md)[AGENTS.md](AGENTS.md)
* Do NOT convert:

    * `<` into `&lt;`
    * `>` into `&gt;`
    * `&` into `&amp;`[AGENTS.md](AGENTS.md)
* All C# code must be written in **raw syntax form**, exactly as it would appear in a .cs file.
* This includes:

    * generics (`IInterface<T>`)
    * comparisons (`a < b`, `a > b`)
    * bitwise operations
* Only escape characters if explicitly required by a non-code format (e.g. markdown rendering outside code blocks), never inside code files or patches.

**Example of correct output:**

```csharp
public partial interface IOnUpdate<TArg> : IComponentBase
```

**Incorrect (forbidden):**

```csharp
public partial interface IOnUpdate&lt;TArg&gt; : IComponentBase
```