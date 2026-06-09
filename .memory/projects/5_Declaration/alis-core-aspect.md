---
title: Alis.Core.Aspect
tags:
  - declaration
  - contract
  - interface
  - documentation

status: draft

license: GPLv3
---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Core.Aspect` |
| **Version** | 1.0.6 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 5_Declaration |
| **Type** | Aggregator |

## Purpose

Alis.Core.Aspect is an aggregator project that compiles all Aspect-related source files from 6_Ideation into a single assembly. It has no hand-written code.

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    5_Declaration                         │
│                  Alis.Core.Aspect                        │
│                  (Aggregator)                            │
├─────────────────────────────────────────────────────────┤
│  Compiles source from:                                  │
│  └── 6_Ideation (Aspect definitions + generators)       │
└─────────────────────────────────────────────────────────┘
```

## Build Configuration

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
    <PropertyGroup>
        <OutDir>bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/</OutDir>
    </PropertyGroup>
</Project>
```

## Source Inlining (Release Mode)

In Release builds, Config.props automatically inlines source files from 6_Ideation:

```xml
<!-- From Config.props -->
<ItemGroup Condition="'$(Configuration)' == 'Release'">
    <Compile Include="$(ProjectDir)../6_Ideation/**/*.cs" />
</ItemGroup>
```

## What Gets Compiled

| Layer | Content | Source Count |
|-------|---------|--------------|
| 6_Ideation | Aspect definitions, source generators | ~40 files |

## Aspects Included

| Aspect | Purpose |
|--------|---------|
| Memory | Memory management and optimization |
| Fluent | Fluent API patterns |
| Data | Data structures and algorithms |
| Math | Mathematical operations |
| Time | Time management and scheduling |
| Logging | Logging and diagnostics |

## Source Generators

| Generator | Output |
|-----------|--------|
| MemoryGenerator | Memory-efficient code |
| FluentGenerator | Fluent API methods |
| DataGenerator | Data structure implementations |
| MathGenerator | Math operations |
| TimeGenerator | Time utilities |
| LoggingGenerator | Logging infrastructure |

## Purpose in Architecture

1. **Aspect Isolation**: Separates Aspect contracts from implementations
2. **Generator Target**: Provides compilation target for source generators
3. **Dependency Direction**: 4_Operation depends on 5_Declaration
4. **Contract Definition**: Defines interfaces for Aspect system

## Target Frameworks

Debug mode: 13 frameworks
- netstandard2.0, netstandard2.1
- netcoreapp2.0, netcoreapp2.1, netcoreapp3.0, netcoreapp3.1
- net5.0, net6.0, net7.0, net8.0, net9.0, net10.0

Release mode: 21 frameworks (adds .NET Framework)
- All Debug frameworks plus
- net461, net462, net47, net471, net472, net48, net481

## Dependencies

This project has no explicit dependencies. It compiles source from 6_Ideation.

## Usage

```csharp
// Reference Alis.Core.Aspect to use Aspect contracts
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Data;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Aspect.Logging;
```

## Generator Cascade

```
6_Ideation (generators)
    ↓
5_Declaration (Alis.Core.Aspect)
    ↓
4_Operation (uses generated code)
    ↓
3_Structuration (Alis.Core - final aggregator)
```

## Related

- [[projects/3_Structuration/alis-core|Alis.Core]]
- [[projects/5_Declaration/alis-core-aspect|Alis.Core.Aspect]]
- [[architecture/build-system|Build System]]
- [[architecture/repository-overview|Repository Overview]]
