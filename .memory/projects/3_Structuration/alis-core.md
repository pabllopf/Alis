---
title: Alis.Core
tags:
  - structuration
  - core
  - abstraction
  - documentation

status: Draft

license: GPLv3

---


## Overview

| Property | Value |
|----------|-------|
| **Namespace** | `Alis.Core` |
| **Version** | 1.0.6 |
| **License** | GPLv3 |
| **Author** | Pablo Perdomo Falcón |
| **Layer** | 3_Structuration |
| **Type** | Aggregator |

## Purpose

Alis.Core is an aggregator project that compiles all source files from lower layers (4_Operation, 5_Declaration, 6_Ideation) into a single assembly. It has no hand-written code.

## Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    3_Structuration                       │
│                    Alis.Core                             │
│                  (Aggregator)                            │
├─────────────────────────────────────────────────────────┤
│  Compiles source from:                                  │
│  ├── 4_Operation (ECS, Graphic, Audio, Physic)          │
│  ├── 5_Declaration (Aspect contracts)                   │
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

In Release builds, Config.props automatically inlines source files from lower layers:

```xml
<!-- From Config.props -->
<ItemGroup Condition="'$(Configuration)' == 'Release'">
    <Compile Include="$(ProjectDir)../6_Ideation/**/*.cs" />
    <Compile Include="$(ProjectDir)../5_Declaration/**/*.cs" />
    <Compile Include="$(ProjectDir)../4_Operation/**/*.cs" />
</ItemGroup>
```

## What Gets Compiled

| Layer | Content | Source Count |
|-------|---------|--------------|
| 4_Operation | ECS, Graphic, Audio, Physic, Platform | ~50 files |
| 5_Declaration | Aspect contracts, interfaces | ~30 files |
| 6_Ideation | Aspect definitions, source generators | ~40 files |
| **Total** | | ~120 files |

## Purpose in Architecture

1. **Dependency Simplification**: Higher layers only reference Alis.Core
2. **Compilation Efficiency**: Single assembly for lower layers
3. **Version Control**: Single version for all core functionality
4. **Deployment**: Single DLL to distribute

## Target Frameworks

Debug mode: 13 frameworks
- netstandard2.0, netstandard2.1
- netcoreapp2.0, netcoreapp2.1, netcoreapp3.0, netcoreapp3.1
- net5.0, net6.0, net7.0, net8.0, net9.0, net10.0

Release mode: 21 frameworks (adds .NET Framework)
- All Debug frameworks plus
- net461, net462, net47, net471, net472, net48, net481

## Dependencies

This project has no explicit dependencies. It compiles source from dependent layers.

## Usage

```csharp
// Reference Alis.Core to use all core functionality
using Alis.Core.Ecs;
using Alis.Core.Graphic;
using Alis.Core.Audio;
using Alis.Core.Physic;
```

## Related

- [[projects/3_Structuration/alis-core|Alis.Core]]
- [[projects/5_Declaration/alis-core-aspect|Alis.Core.Aspect]]
- [[architecture/build-system|Build System]]
- [[architecture/repository-overview|Repository Overview]]
