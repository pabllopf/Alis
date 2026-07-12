---
title: Repository Overview
tags:
  - summary
  - overview
  - repository
status: Draft
license: GPLv3
---

# Alis Repository Overview

## Description

Alis is a **cross-platform C# game framework** designed for Windows, macOS, Linux, Web (WASM), Android, and iOS. It is structured as a strict 6-layer clean architecture monorepo with 81+ projects.

## Technology Stack

| Component | Technology |
|---|---|
| Language | C# 13 |
| Framework | .NET 10.0 (multi-targets back to net461) |
| SDK | .NET 10.0 SDK (roll forward allowed) |
| Build | MSBuild with centralized Config.props |
| Testing | xUnit + Moq + Xunit.StaFact + coverlet |
| Source Generators | Roslyn (netstandard2.0 analyzers) |
| IDE | Rider / Visual Studio |
| Version | 1.0.8 |
| License | GPL-3.0 |

## Architecture

### 6-Layer Strict Dependency Rule

```
1_Presentation → 2_Application → 3_Structuration → 4_Operation → 5_Declaration → 6_Ideation
```

Reverse dependencies are forbidden and enforced via MSBuild configuration in `.config/Config.props`.

### Layer Map

| Layer | Name | Role | Projects |
|---|---|---|---|
| 1 | Presentation | Apps, Extensions, Benchmarks | 9 |
| 2 | Application | Main game framework assembly | 3 |
| 3 | Structuration | Core abstractions and ECS foundation | 3 |
| 4 | Operation | Audio, ECS, Graphics, Physics engines | 12 |
| 5 | Declaration | Aspect-oriented contracts | 3 |
| 6 | Ideation | Foundation: Data, Math, Memory, Time, Logging, Fluent | 18 |

### Solution Files

| Solution | Focus | Scope |
|---|---|---|
| alis.slnx | Full solution | All projects |
| alis_design.slnx | Design-time | All projects |
| alis.core.slnx | Core | Core libraries |
| alis.core.aspect.slnx | Core Aspect | Aspect-oriented layer |
| alis.extensions.slnx | Extensions | Extension projects |
| alis.apps.slnx | Applications | App projects |
| alis.test.slnx | Testing | Test projects |
| alis.samples.slnx | Samples | Sample projects |
| alis.benchmark.slnx | Benchmarks | Benchmark projects |

### Multi-Targeting

| Configuration | Target Frameworks |
|---|---|
| Debug | netcoreapp2.0;net5.0;net8.0;net10.0;netstandard2.0;net461 |
| Release | 19+ TFMs (netcoreapp2.0 → net10.0, netstandard2.0/2.1, net461→net481) |
| Win/Osx/Linux | Platform-specific subsets |
| Browser/Ios/Android | net8.0;net10.0;netstandard2.0 |

### Runtime Identifiers

browser-wasm, win-x64/86, linux-x64/arm64/arm, osx-x64/arm64, android-arm64/x64, ios-arm64, iossimulator-arm64/x64

## Repository Stats

| Metric | Count |
|---|---|
| Source projects | 48 |
| Test projects | 13 |
| Sample projects | 16 |
| Generator projects | 8 |
| Benchmark projects | 1 |
| Solutions | 11 |
| Total `.csproj` | 86+ |
| Lines of code | 200k+ (estimated) |

## Key Patterns

- **CQRS** via MediatR (in Application layer)
- **ECS** (Entity Component System) in Operation/ECS
- **Source Generators** for serialization (JSON), logging, math, memory, time, fluent
- **DI** via standard .NET DI patterns
- **DDD** tactical patterns in domain projects
- **Strict layering** enforced at build level
- **Conditional compilation** via RuntimeIdentifier-based DefineConstants (WIN, OSX, LINUX)

## Security

- GPL-3.0 licensed
- SonarCloud analysis active
- No external dependencies in core (except SourceLink)
- Conditional NuGet dependencies only in specific Extension projects (Stripe, Google Ads, Google Drive, Dropbox)
- Nullable: disabled (project-wide)
- Warnings as errors enabled

## Related Documents

- [[architecture-overview]]
- [[dependency-graph]]
- [[project-index]]
- [[conventions-overview]]
