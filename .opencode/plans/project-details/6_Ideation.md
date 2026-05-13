# Alis — Layer 6: Ideation (Projects, Dependencies, Key Types)

## Overview

- **Directory**: `6_Ideation/`
- **Total .cs files**: ~447 (src: 203, test: 218, samples: ~26, generators: ~26)
- **Total projects**: 21 (6 aspects × [src+sample+test] + 3 generators = 21)
- **Build target**: Multi-target via Config.props for libs, `netstandard2.0` for generators, `net10.0` for samples, `net8.0` for tests
- **Outputs**: Library (aspects), EXE (samples), Analyzer (generators)
- **No internal dependencies** — this is the leaf layer of the entire solution

## Aspect Modules (6)

### 1. Data — JSON Serialization/Deserialization

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Data | `Data/src/` | 5 | JSON serialization/deserialization, parsing, file operations, helpers, exceptions |
| Alis.Core.Aspect.Data.Generator | `Data/generator/` | 5 | JSON-related source generator |
| Alis.Core.Aspect.Data.Sample | `Data/sample/` | 7 | JSON aspect usage samples |
| Alis.Core.Aspect.Data.Test | `Data/test/` | 24+7+2+3+7+2+1 | JSON models, serialization, parsing, deserialization, integration, exceptions, helpers, regression, file operations |

**Namespace**: `Alis.Core.Aspect.Data.*`
- `Json/` — Core JSON handling
  - `Json/Serialization/` — Serialization logic
  - `Json/Parsing/` — JSON parsing
  - `Json/Deserialization/` — Deserialization logic
  - `Json/Models/` — JSON data models (24 files)
  - `Json/Helpers/` — JSON helpers
  - `Json/Exceptions/` — JSON exceptions (3 files)
  - `Json/FileOperations/` — JSON file I/O
- Test namespaces mirror source: `Json/Models/`, `Json/Serialization/`, `Json/Parsing/`, `Json/Deserialization/`, `Json/Integration/`, `Json/Helpers/`, `Json/Exceptions/`, `Json/Regression/`, `Json/FileOperations/`

### 2. Fluent — Fluent API Builder

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Fluent | `Fluent/src/` | ~9+86+39=~134 | Fluent API with word builders and component builders |
| Alis.Core.Aspect.Fluent.Generator | `Fluent/generator/` | 1 | Fluent API source generator |
| Alis.Core.Aspect.Fluent.Sample | `Fluent/sample/` | 4 | Fluent usage samples |
| Alis.Core.Aspect.Fluent.Test | `Fluent/test/` | ~9+29+33=71 | Fluent component/word tests |

**Namespace**: `Alis.Core.Aspect.Fluent.*`
- `Components/` (39 files) — Fluent component definitions
- `Words/` (86+29 files) — Word builders and string manipulation
- Test: `Components/` (33), `Words/` (29)

### 3. Logging — Logging Framework

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Logging | `Logging/src/` | ~6+2+5+3+5=21 | Logging abstractions with filters, formatters, outputs |
| Alis.Core.Aspect.Logging.Sample | `Logging/sample/` | 2 | Logging samples |
| Alis.Core.Aspect.Logging.Test | `Logging/test/` | ~31+5+4+2+5=47 | Logging test suite |

**Namespace**: `Alis.Core.Aspect.Logging.*`
- `Abstractions/` (6) — Logging interfaces/contracts
- `Filters/` (2+2) — Log filtering logic
- `Formatters/` (3+2) — Log output formatters
- `Outputs/` (5+4) — Log output targets (console, file, etc.)
- `Core/` (2+5) — Core logging infrastructure
- Test: mirrors source namespace + `Abstractions/`, `Filters/`, `Formatters/`, `Outputs/`, `Attributes/`

### 4. Math — Math Primitives

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Math | `Math/src/` | ~2+3+5+2+4+2+4+2 = ~24 | Vector, Matrix, Shapes (Circle, Line, Point, Rectangle, Square) |
| Alis.Core.Aspect.Math.Sample | `Math/sample/` | 2 | Math usage samples |
| Alis.Core.Aspect.Math.Test | `Math/test/` | ~10+6+4+4+5+2+2+2+2+3+3 = ~43 | Math primitive tests |

**Namespace**: `Alis.Core.Aspect.Math.*`
- `Definition/` (2) — Math definitions/constants
- `Util/` (4) — Math utilities
- `Vector/` (3+10) — Vector operations (2D, 3D?)
- `Matrix/` (5) — Matrix operations
- `Shapes/`
  - `Circle/` (2) — Circle shape
  - `Line/` (2) — Line shape
  - `Point/` (2) — Point shape
  - `Rectangle/` (2) — Rectangle shape
  - `Square/` (2) — Square shape
- `Collections/` (2+4) — Math collections

### 5. Memory — Memory Management

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Memory | `Memory/src/` | 3 | Memory management utilities |
| Alis.Core.Aspect.Memory.Generator | `Memory/generator/` | 1 | Memory-related source generator |
| Alis.Core.Aspect.Memory.Sample | `Memory/sample/` | 2 | Memory usage samples |
| Alis.Core.Aspect.Memory.Test | `Memory/test/` | 4 | Memory management tests |

**Namespace**: `Alis.Core.Aspect.Memory.*`

### 6. Time — Time Utilities

| Project | Path | Src Files | Notes |
|---------|------|-----------|-------|
| Alis.Core.Aspect.Time | `Time/src/` | 1 | Time management |
| Alis.Core.Aspect.Time.Sample | `Time/sample/` | 2 | Time usage samples |
| Alis.Core.Aspect.Time.Test | `Time/test/` | 3 | Time utility tests |

**Namespace**: `Alis.Core.Aspect.Time.*`

## Generator Projects (3)

All generators follow the same pattern:

| Generator | Host Aspect | Target Frameworks | Purpose |
|-----------|-------------|-------------------|---------|
| Alis.Core.Aspect.Data.Generator | Data | netstandard2.0, net8.0, net10.0 | JSON serialization code gen |
| Alis.Core.Aspect.Fluent.Generator | Fluent | netstandard2.0, net8.0, net10.0 | Fluent API code gen |
| Alis.Core.Aspect.Memory.Generator | Memory | netstandard2.0, net8.0, net10.0 | Memory management code gen |

Each uses:
- `Microsoft.CodeAnalysis.CSharp 4.3.0`
- `Microsoft.CodeAnalysis.Analyzers 3.3.4`
- `EnforceExtendedAnalyzerRules=true`
- `ExcludeFromCodeCoverage=true`
- `TargetFramework=netstandard2.0` (for analyzer compatibility)

## Size Rankings (by src/ .cs count)

| Rank | Aspect | Files | Tests | Ratio |
|------|--------|-------|-------|-------|
| 1 | Fluent | ~134 | 71 | 1.89:1 |
| 2 | Data | 5 | ~47 | 0.11:1 |
| 3 | Logging | ~21 | ~47 | 0.45:1 |
| 4 | Math | ~24 | ~43 | 0.56:1 |
| 5 | Memory | 3 | 4 | 0.75:1 |
| 6 | Time | 1 | 3 | 0.33:1 |

## Total Ideation Summary

| Category | Library | Generator | Sample | Test | Total Projects |
|----------|---------|-----------|--------|------|---------------|
| Data | 1 | 1 | 1 | 1 | 4 |
| Fluent | 1 | 1 | 1 | 1 | 4 |
| Logging | 1 | 0 | 1 | 1 | 3 |
| Math | 1 | 0 | 1 | 1 | 3 |
| Memory | 1 | 1 | 1 | 1 | 4 |
| Time | 1 | 0 | 1 | 1 | 3 |
| **Total** | **6** | **3** | **6** | **6** | **21** |

## Key Architectural Notes

- Layer 6 is the absolute leaf — no internal dependencies
- Aspects are independently packagable NuGet packages (Alis.Core.Aspect.Data, Alis.Core.Aspect.Fluent, etc.)
- Only Data, Fluent, and Memory have source generators; Logging, Math, and Time do not
- Test coverage is generally high (Fluent has 1.89:1 ratio, Data/Math have <1:1 but are still well-tested)
- Math aspect provides the foundational vector/matrix/shape types used across the engine
- Logging provides the observability layer for all engine systems
- Data aspect handles JSON serialization used by configuration and save systems
- Fluent aspect provides builder-pattern utilities used throughout the codebase
- Memory and Time are lightweight utility aspects
