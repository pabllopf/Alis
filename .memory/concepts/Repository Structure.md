---
title: Repository Structure
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Alis uses a well-organized directory structure with 6 main layers and supporting directories.

## Root Directories

| Directory | Purpose |
|-----------|---------|
| `1_Presentation/` | User-facing applications and extensions |
| `2_Application/` | Main application and samples |
| `3_Structuration/` | Core foundations and abstractions |
| `4_Operation/` | Operational systems (ECS, graphics, audio, physics) |
| `5_Declaration/` | Declarative foundation (Core.Aspect) |
| `6_Ideation/` | Experimental aspects and modules |
| `.config/` | Build configuration files |
| `.memory/` | Generated documentation and knowledge base |
| `docs/` | Project documentation |
| `openspec/` | Open specification files |

## Layer Details

### 1_Presentation
- **Engine/** - Main runtime engine
- **Hub/** - Hub application
- **Installer/** - Installation application
- **Extension/** - 18+ modular extensions

### 2_Application
- **Alis/src/** - Main application entry point
- **samples/** - 12+ sample games

### 3_Structuration
- **Core/** - Core library with foundational types

### 4_Operation
- **Ecs/** - Entity Component System
- **Graphic/** - Graphics rendering
- **Audio/** - Audio processing
- **Physic/** - Physics engine

### 5_Declaration
- **Aspect/** - Core.Aspect - declarative foundation

### 6_Ideation
- **Memory/** - Memory abstractions
- **Fluent/** - Fluent APIs
- **Math/** - Mathematical utilities
- **Time/** - Time management
- **Data/** - Data structures
- **Logging/** - Logging infrastructure

## Configuration Files

| File | Location | Purpose |
|------|----------|---------|
| `Config.props` | `.config/` | Multi-targeting, global properties |
| `default.sln` | `.config/` | Default solution file |
| `coverlet.runsettings` | `.config/` | Code coverage settings |
| `xunit.runner.json` | `.config/` | xUnit test runner config |
| `SonarQube.Analysis.xml` | `.config/` | Static analysis rules |

## Solution Files

| File | Purpose |
|------|---------|
| `alis.slnx` | Full solution |
| `alis.core.slnx` | Core libraries only |
| `alis.apps.slnx` | Applications |
| `alis.extensions.slnx` | Extensions |
| `alis.test.slnx` | Tests |
| `alis.samples.slnx` | Samples |
| `alis.core.aspect.slnx` | Aspects only |
| `alis.benchmark.slnx` | Benchmarks |

## See Also
- [[Layered Architecture]]
- [[Build System Configuration]]
- [[Solution Files Strategy]]

## Related
- [[Alis Architecture Overview]] — Full architecture
- [[Solution Files Strategy]] — Solution organization
- [[Application Composition]] — App layer structure
- [[Extension System]] — Extension structure
- [[dependency-graph]] — Layer dependencies
- [[repository-overview]] — Repository overview
- [[projects/Index]] — All project docs
- [[projects/1_Presentation]] — Presentation layer
- [[projects/2_Application]] — Application layer
- [[projects/3_Structuration]] — Foundation layer
- [[projects/4_Operation]] — Operation layer
- [[projects/5_Declaration]] — Declaration layer
- [[projects/6_Ideation]] — Ideation layer
- [[indexes-summary]] — Index overview
