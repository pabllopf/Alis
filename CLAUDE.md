# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

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
