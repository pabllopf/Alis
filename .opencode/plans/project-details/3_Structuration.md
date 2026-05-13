# Alis — Layer 3: Structuration (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `3_Structuration/`
- **Total .cs files**: ~208 (src: 6, test: 206, sample: 2)
- **Total projects**: 3 (1 src, 1 sample, 1 test)
- **Build target**: Multi-target (Config.props: net461–net481, netcoreapp2.0–3.1, netstandard2.0/2.1, net5.0–net10.0)
- **Outputs**: Library (Core), EXE (sample)

## Projects

| Project | Path | Type | Files |
|---------|------|------|-------|
| Alis.Core | `3_Structuration/Core/src/` | Library | 6 .cs |
| Alis.Core.Sample | `3_Structuration/Core/sample/` | Executable | 2 .cs |
| Alis.Core.Test | `3_Structuration/Core/test/` | Test (xunit) | 206 .cs |

## Test-Heavy Module

This is the most test-heavy module in the solution by far — 206 test files for only 6 source files. Tests are organized into:

### Test Categories (Core tests)

| Test Directory | Files | Purpose |
|----------------|-------|---------|
| `Comprehensive/` | 100 | Core comprehensive tests |
| `Generated/` | 50 | Generated code tests |
| `Validation/` | 30 | Validation tests |
| `Boundary/` | 20 | Boundary condition tests |
| Other | ~6 | misc core tests |

### Key Observations

- The `Comprehensive/` namespace with 100 files suggests deep, systematic testing of core abstractions
- `Generated/` tests (50 files) validate source generator output
- `Validation/` and `Boundary/` suggest robust input validation and edge case handling
- Only 6 source files means this module is API definitions, interfaces, or lightweight abstractions

## Dependencies

### Alis.Core.csproj References
```
6_Ideation/Data/
6_Ideation/Fluent/
6_Ideation/Logging/
6_Ideation/Math/
6_Ideation/Memory/
6_Ideation/Time/
5_Declaration/Aspect/
```

### Alis.Core.Test.csproj References
```
1_Presentation/ (via conditional ProjectReference)
2_Application/Alis/src/ (via conditional ProjectReference)
3_Structuration/Core/src/ (this project)
4_Operation/ (via conditional ProjectReference)
5_Declaration/Aspect/ (via conditional ProjectReference)
```

Test projects reference conditional paths for cross-layer testing.

## Key Types (from 6 source files)

Without direct file reads, the naming convention and test structure indicate:
- Core abstractions shared across engine systems
- Possibly interfaces for ECS primitives, math operations, or data handling
- The Comprehensive/ test namespace suggests these are foundational types

## Build Notes

- Uses multi-targeting via Config.props (same as all library projects)
- Sample project targets `net10.0`
- Test project targets `net8.0`
- `SonarQubeExclude` — not included in SonarQube analysis (for non-core modules)
