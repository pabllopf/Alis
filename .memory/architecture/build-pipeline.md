---
title: Build Pipeline
tags:
  - architecture
  - build
  - pipeline
status: Draft
license: GPLv3
---

# Build Pipeline

## Overview

The build system uses MSBuild with centralized configuration in `.config/Config.props`.

## Key Build Properties

| Property | Value |
|---|---|
| LangVersion | 13 |
| Nullable | disabled |
| WarningsAsErrors | true |
| TreatWarningsAsErrors | true |
| AnalysisMode | AllEnabledByDefault |
| AnalysisLevel | latest |
| AllowUnsafeBlocks | false |
| Version | 1.0.8 (from Directory.Build.props) |

## Build Commands

```bash
# Full solution build
dotnet build alis.slnx -c Debug

# Focused builds (faster)
dotnet build alis.core.slnx -c Debug
dotnet build alis.extensions.slnx -c Debug

# Tests (net8.0 for speed)
dotnet test alis_design.sln -c Release -f net8.0

# Full test run
./docs/scripts/macos/run_tests.sh
```

## Source Generator Build Order

Generators must be built first before the full solution:

```bash
dotnet build <generator>.csproj -f netstandard2.0
```

## Output Structure

```text
bin/
├── <Configuration>/
│   ├── <RuntimeIdentifier>/
│   │   └── lib/
│   │       └── <TargetFramework>/
│   │           └── <Assembly>.dll
│   └── analyzers/
│       └── dotnet/
│           └── cs/
│               └── <Generator>.dll
```

## Test Output

```text
.test/
└── <TargetFramework>/
    └── <TestProject>.trx
```

## NuGet Packaging

- All projects are packable (`IsPackable=true`)
- Package version follows `AssemblyVersion` (1.0.8)
- SourceLink is enabled for all packages
- Generator DLLs are included as analyzers in NuGet packages
- Runtime-specific assets are included per RID

## Related Documents

- [[multi-targeting-strategy]]
- [[source-generator-architecture]]
- [[config-props-details]]
