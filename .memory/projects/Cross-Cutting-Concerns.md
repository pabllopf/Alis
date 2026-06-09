---
title: Cross-Cutting Concerns
tags: [project,documentation,reference]
---


## Overview
ALIS has several cross-cutting concerns that apply consistently across all projects in the solution.

## SonarQube Exclusion
All test projects and benchmark are excluded from SonarQube analysis:

```xml
<PropertyGroup Condition="'$(ProjectName)' != 'Alis.Test' And !$(ProjectName.Contains('Test')) And '$(ProjectName)' != 'Alis.Benchmark'">
  <SonarQubeExclude>true</SonarQubeExclude>
</PropertyGroup>
```

Actually, the pattern is inverted — test projects and benchmark are excluded:
- `Alis.Test` — Core application tests
- All `*.Test` projects — Layer-specific tests
- `Alis.Benchmark` — Performance benchmarks

## Warning Suppression
Extensive NoWarn configuration across all projects:

### Custom ALIS Warnings
- ALIS001, ALIS002, ALIS003, ALIS004, ALIS005
- ALIS006, ALIS007, ALIS008, ALIS009, ALIS010

### Microsoft.CodeAnalysis Warnings
- CA1050: Declare types in namespaces
- CA1303: Pass literal strings as parameters
- CA2007: Consider calling ConfigureAwait
- CA2243: Compute static string literal attribute

### Roslyn Analyzer Warnings
- RS0016_, RS0017_, RS0018: Public vs private APIs
- RS0024_9: Missing overloads
- RS0037_: Nullability mismatch

### NativeAOT Warnings
- IL2026: Using member which can break in tree mode
- IL3050: Calling members with RequiresDynamicAttribute
- IL2104: Code trimmed

### NuGet Warnings
- NU1507: Reference packages globally
- NU1900, NU1902, NU1903: Vulnerability warnings

### .NET Runtime Warnings
- SYSLIB1054: Use HttpFactoryProvider
- SYSLIB1116: Use matching framework version

### And many more...

## Language Version
All projects use `LangVersion: 13` (C# 13).

## Nullable Context
All projects have `Nullable: disable`.

## Unsafe Blocks
All projects have `AllowUnsafeBlocks: false`.

## Framework Versions
- **net8.0**: Most projects (Presentation, Application, Structuration, Operation, Declaration, Ideation)
- **net10.0**: Engine and Hub (latest framework)

## Asset Pipeline
All projects use the same asset pipeline:
1. `_PrepareAssetPackManifest` — Generates manifest with SHA256 hashes
2. Incremental build check — Skips if hashes unchanged
3. `ZipAssets` — Zips and base64-encodes assets

## Platform Detection
All projects support platform-specific builds:
- **LINUX**: linux-x64, linux-arm64, and distro-specific identifiers
- **OSX**: osx, osx.10.14, osx.10.15, osx.11.0, osx-arm64
- **WIN**: win, win-x64, win-x86, win-arm64

## Project Reference Pattern
All projects use dynamic glob-based project references to generators:

```xml
<ItemGroup>
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\*\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\Generator\src\*.csproj" />
  <ProjectReference Include="$(MSBuildThisFileDirectory)..\..\..\Generator\src\*.csproj" />
</ItemGroup>
```

## Configuration File
All projects import `Config.props` for shared settings:

```xml
<Import Project="$(MSBuildThisFileDirectory)..\Config.props" />
```

## Notes
- Consistent configuration across all 140+ projects
- Extensive warning suppression suggests ongoing migration/refactoring
- NativeAOT warnings indicate AOT compatibility work in progress
- NuGet vulnerability warnings suggest outdated packages

## Related

- [[projects/Build-System]] — Build configuration
- [[projects/Generators]] — Generator reference pattern
- [[build-system]] — Architecture build docs
- [[build-summary]] — Build pipeline overview
- [[Multi-Targeting Strategy]] — Framework targets
- [[Platform-Specific Build Constants]] — Platform symbols
- [[naming-conventions]] — Naming rules
- [[projects/Index]] — All project docs
- [[adr-001-layered-architecture]] — Architecture decision
- [[code-review-checklist]] — Review guidelines
- [[ai-context]] — Build reference
