# Alis.Core.Data

## Overview
Data contracts and DTOs for the ALIS engine. Defines the shape of data used across the system.

## Project Details
- **Layer**: 5_Declaration
- **Type**: Class Library
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

## Dependencies
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from 6_Ideation

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
- Data transfer objects (DTOs)
- Data contracts for inter-layer communication
- Pure data definitions with no business logic
