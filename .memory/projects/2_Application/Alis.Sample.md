# Alis.Sample

## Overview
Sample/demo application demonstrating usage of the core Alis application library.

## Project Details
- **Layer**: 2_Application
- **Type**: Sample Application
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/`

## Dependencies
- [[Alis]] (2_Application) — Core application library
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
- Demonstrates core library usage patterns
- Can be used as starting point for new projects
