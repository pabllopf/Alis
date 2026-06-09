---
title: Solution Files Strategy
tags:
  - concept
  - theory
  - documentation

status: draft
---


Alis uses 8 modular `.slnx` solution files for different build targets, enabling focused compilation and faster development cycles.

## Solution Files Overview

| File | Purpose | Contents |
|------|---------|----------|
| `alis.slnx` | Full solution | All projects (apps, samples, core, aspects, extensions) |
| `alis.core.slnx` | Core libraries | Core libraries only (no tests, samples, presentation) |
| `alis.apps.slnx` | Applications | Installer, Engine, Hub + core dependencies |
| `alis.extensions.slnx` | Extensions | All extensions + core dependencies |
| `alis.test.slnx` | Testing | Test projects across all layers |
| `alis.samples.slnx` | Samples | Sample games + core samples |
| `alis.core.aspect.slnx` | Aspects only | 5_Declaration + 6_Ideation layers |
| `alis.benchmark.slnx` | Benchmarks | Benchmark project only |

## Build Commands Reference

```bash
# Full build - all projects
dotnet build alis.slnx

# Core libraries only (fastest)
dotnet build alis.core.slnx

# Applications only
dotnet build alis.apps.slnx

# Extensions only
dotnet build alis.extensions.slnx

# Run all tests
dotnet test alis.test.slnx

# Build samples
dotnet build alis.samples.slnx

# Aspects only (declaration + ideation)
dotnet build alis.core.aspect.slnx

# Benchmarks
dotnet build alis.benchmark.slnx
```

## Focused Development Benefits

1. **Faster incremental builds** - Only compile what's needed
2. **Targeted testing** - Run tests for specific layers
3. **Code navigation** - Focused context in IDE
4. **Reduced context switching** - Work on specific concerns
5. **Better CI/CD** - Parallel builds across solutions

## Solution Dependency Graph

```
alis.slnx (full)
├── alis.core.slnx ← alis.apps.slnx, alis.extensions.slnx
├── alis.apps.slnx ← Engine, Hub, Installer
├── alis.extensions.slnx ← 18+ extensions
├── alis.test.slnx ← all test projects
├── alis.samples.slnx ← 12+ samples
└── alis.core.aspect.slnx ← Declaration + Ideation
```

## See Also
- [[Layered Architecture]]
- [[Alis Architecture Overview]]
- [[Build System Configuration]]

## Related
- [[Repository Structure]] — Directory layout
- [[Application Composition]] — Solution contents
- [[Extension System]] — Extension solutions
- [[multi-platform-samples]] — Sample solutions
- [[build-system]] — Build configuration
- [[dependency-graph]] — Solution dependencies
- [[projects/Index]] — All project docs
- [[onboarding/getting-started]] — Build commands
- [[project-index]] — Project enumeration
