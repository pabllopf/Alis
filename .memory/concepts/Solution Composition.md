---
title: Solution Composition
tags:
  - concept
  - theory
  - documentation

status: Draft

license: GPLv3

---


Alis uses 8 modular `.slnx` solution files for different build targets, enabling focused compilation and faster development cycles.

## Solution Files

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

## Build Commands

```bash
# Full build - all projects
dotnet build alis.slnx

# Core libraries only
dotnet build alis.core.slnx

# Applications only
dotnet build alis.apps.slnx

# Extensions only
dotnet build alis.extensions.slnx

# Run all tests
dotnet test alis.test.slnx

# Build samples
dotnet build alis.samples.slnx

# Aspects only
dotnet build alis.core.aspect.slnx

# Benchmarks
dotnet build alis.benchmark.slnx
```

## Focused Development Benefits

1. **Faster incremental builds** - Only compile what's needed
2. **Targeted testing** - Run tests for specific layers
3. **Code navigation** - Focused context in IDE
4. **Reduced context switching** - Work on specific concerns

## See Also
- [[Layered Architecture]]
- [[Alis Architecture Overview]]
- [[Build System Configuration]]
- [[Alis Architecture Overview]]
- [[Multi-Platform Samples]]
- [[Build System Configuration]]

## Related Architecture

- [[build-system]] — Build commands and structure
- [[build-summary]] — Build pipeline overview
- [[projects/Index]] — Project structure in solutions
- [[project-index]] — All projects by solution
