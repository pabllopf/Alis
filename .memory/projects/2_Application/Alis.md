# Alis (Core Application Library)

## Overview
The core application library that provides fundamental services for ALIS games and applications. Acts as the central dependency for all Presentation layer projects.

## Project Details
- **Layer**: 2_Application
- **Type**: Class Library
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

## Dependencies
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

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
- Central library consumed by all Presentation layer projects
- No direct framework dependencies beyond .NET runtime
- Provides core abstractions for game development
