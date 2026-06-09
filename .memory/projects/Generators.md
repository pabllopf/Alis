---
title: Generator Projects
tags:
  - project
  - documentation
  - reference

status: draft

license: GPLv3
---


## Overview
5 Roslyn code generation / analysis projects across 2 layers. Each generator ships as an `Analyzer` dependency (`PrivateAssets=all`, `ReferenceOutputAssembly=false`) consumed by the Alis.Core.Aspect aggregator. Shared build template: `.config/default/default_generator_csproj.props`.

## Generator Catalog

| # | Project | Layer | Type | .cs Files | Purpose |
|---|---|---|---|---|---|
| 1 | [[projects/Generators/Alis.Core.Ecs.Generator\|Alis.Core.Ecs.Generator]] | 4_Operation | `IIncrementalGenerator` + `DiagnosticAnalyzer` | 13 | ECS component type registry |
| 2 | [[projects/Generators/Alis.Core.Graphic.Generator\|Alis.Core.Graphic.Generator]] | 4_Operation | `ISourceGenerator` (stub) | 1 | Skeleton/placeholder |
| 3 | [[projects/Generators/Alis.Core.Aspect.Memory.Generator\|Alis.Core.Aspect.Memory.Generator]] | 6_Ideation | `IIncrementalGenerator` | 1 | AOT-safe resource embedding |
| 4 | [[projects/Generators/Alis.Core.Aspect.Fluent.Generator\|Alis.Core.Aspect.Fluent.Generator]] | 6_Ideation | `DiagnosticAnalyzer` | 1 | AOT-safety reflection analyzer |
| 5 | [[projects/Generators/Alis.Core.Aspect.Data.Generator\|Alis.Core.Aspect.Data.Generator]] | 6_Ideation | `ISourceGenerator` | 5 | JSON serialization code gen |
| | **Totals** | | | **21** | |

## Generator Dependency Flow
```
5_Declaration ─── Alis.Core.Aspect (aggregator, consumes all generators via Analyzer refs)
        ▲
        │
┌───────┴───────────────┐
│    Generators          │
│  ┌──────────────────┐  │
│  │ 4_Operation       │  │
│  │ ├ Ecs.Generator   │  │
│  │ └ Graphic.Generator│  │
│  └──────────────────┘  │
│  ┌──────────────────┐  │
│  │ 6_Ideation        │  │
│  │ ├ Memory.Generator│  │
│  │ ├ Fluent.Generator│  │
│  │ └ Data.Generator  │  │
│  └──────────────────┘  │
└───────────────────────┘
```

## Generator Directory Structure
```
4_Operation/Ecs/generator/         — Ecs.Generator (13 .cs files)
4_Operation/Graphic/generator/     — Graphic.Generator (1 .cs file)
6_Ideation/Memory/generator/       — Memory.Generator (1 .cs file)
6_Ideation/Fluent/generator/       — Fluent.Generator (1 .cs file)
6_Ideation/Data/generator/         — Data.Generator (5 .cs files)
```

## Shared Build Template
`.config/default/default_generator_csproj.props`:
- **Targets**: `netstandard2.0;net8.0;net10.0`
- **LangVersion**: 13
- **EnforceExtendedAnalyzerRules**: true
- **Packages**: `Microsoft.CodeAnalysis.CSharp` (4.3.0), `Microsoft.CodeAnalysis.Analyzers` (3.3.4)

## Generator Reference Pattern
Generators are referenced via MSBuild as analyzers (not project references):
```xml
<ProjectReference Include="path/to/generator/*.csproj"
                  PrivateAssets="all"
                  ReferenceOutputAssembly="false"
                  OutputItemType="Analyzer" />
```

## Related
- [[projects/5_Declaration/Aspect]] — Aspect aggregator consuming all generators
- [[projects/Generators/Alis.Core.Ecs.Generator]] — ECS type registry generator
- [[projects/Generators/Alis.Core.Graphic.Generator]] — Graphic generator (stub)
- [[projects/Generators/Alis.Core.Aspect.Memory.Generator]] — Resource embedding generator
- [[projects/Generators/Alis.Core.Aspect.Fluent.Generator]] — AOT reflection analyzer
- [[projects/Generators/Alis.Core.Aspect.Data.Generator]] — JSON serialization generator
