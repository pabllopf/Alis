---
title: Alis.Benchmark
tags:
  - presentation
  - application
  - extension
  - documentation

status: Draft

license: GPLv3

---


## Overview
Performance benchmarking application for ALIS engine components. Measures and compares performance of engine subsystems.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Benchmark/Performance Testing
- **Framework**: net8.0
- **Output Type**: Exe
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`

## Dependencies
- [[Alis.Core]] (3_Structuration)
- [[Alis.Core.Ecs]] (4_Operation)
- [[Alis.Core.Graphic]] (4_Operation)

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true

## Asset Pipeline
- Uses [[#Asset Pack System]] for resource management
- SHA256 hash-based change detection
- Incremental build via manifest file

## Key Build Targets
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Excluded from SonarQube analysis
- Uses benchmarking framework for performance measurement

## Related
- [[projects/1_Presentation/Engine]] — Engine runtime
- [[projects/4_Operation/Ecs]] — ECS performance
- [[architecture/build-system]] — Build configuration
- [[build-summary]] — Build overview
- [[performance-index]] — Performance tracking
- [[Alis Architecture Overview]] — Full architecture
