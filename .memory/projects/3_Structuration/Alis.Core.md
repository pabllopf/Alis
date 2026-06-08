# Alis.Core

## Overview
The foundational core library providing basic abstractions, utilities, and cross-platform services for the ALIS engine.

## Project Details
- **Layer**: 3_Structuration
- **Type**: Class Library
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

## Dependencies
- [[Alis]] (2_Application) — Core application library
- All generators from 4_Operation, 5_Declaration, 6_Ideation

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
- Foundation for all other Structuration libraries
- Provides cross-platform abstractions
- No Presentation layer dependencies
