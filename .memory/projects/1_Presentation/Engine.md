---
title: Alis.App.Engine
tags: [presentation,application,extension,documentation]
---


## Overview
The main game engine runtime application. Launches and manages game instances. Entry point for game execution.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Desktop)
- **Framework**: net10.0
- **Output Type**: Exe
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`

## Dependencies
- [[Alis]] (2_Application) — Core application library
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true
- **ApplicationIcon**: `Assets/app.ico` (if exists)

## AOT & Trimming (Debug & Release)
- **PublishAot**: true
- **SelfContained**: true
- **PublishTrimmed**: true
- **TrimMode**: link
- **OptimizationPreference**: Size
- **IlcDisableReflection**: true
- **IlcFoldIdenticalMethodBodies**: true
- **StripSymbols**: true

## Platform-Specific Targets
- **macOS**: `CreateMacAppBundle` — Creates .app bundle with Info.plist and icon
- **Linux**: `CreateLinuxBundle` — Creates zip distribution
- **Windows**: `CreateWindowsBundle` — Creates zip distribution

## Asset Pipeline
- Uses [[#Asset Pack System]] for resource management
- SHA256 hash-based change detection
- Incremental build via manifest file

## Key Build Targets
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64
- `CreateMacAppBundle` — Creates macOS .app bundle (Release only)
- `GenerateDynamicInfoPlist` — Generates Info.plist for macOS bundle

## Platform Detection
- **LINUX**: Defined when RuntimeIdentifier contains 'linux' or matches distro patterns
- **OSX**: Defined when RuntimeIdentifier contains 'osx'
- **WIN**: Defined when RuntimeIdentifier contains 'win'
- **Runtime-specific**: e.g., `linuxx64`, `osxarm64` derived from RuntimeIdentifier

## Notes
- Uses .NET 10.0 (latest framework version in the solution)
- AOT compilation enabled for both Debug and Release configurations
- Generates analysis files: .mstat, .dgml, .map, IL dump

## Related
- [[projects/1_Presentation/Hub]] — Launcher application
- [[projects/1_Presentation/Benchmark]] — Performance benchmarks
- [[projects/2_Application/Alis]] — Core application library
- [[projects/4_Operation/Ecs]] — ECS implementation
- [[projects/Cross-Cutting-Concerns]] — Build configuration
- [[architecture/build-system]] — Build configuration
- [[Alis Architecture Overview]] — Full architecture
- [[Multi-Platform Samples]] — Sample platforms
- [[Platform-Specific Build Constants]] — Platform detection
