# Core Libraries (5_Declaration)

## Overview
The 5_Declaration layer contains declaration libraries that provide data contracts, DTOs, and interface definitions for the ALIS engine. These define the shapes of data used across the system.

## Projects in this Layer
- [[Alis.Core.Data]] — Data contracts and DTOs
- [[Alis.Core.Log]] — Logging infrastructure

## Common Pattern
All Declaration projects follow the standard pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
All depend on:
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from 6_Ideation

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true (test projects)

## Asset Pipeline
All use the same asset pipeline:
- SHA256 hash-based change detection
- Incremental build via manifest file
- Base64-encoded zip archives

## Key Build Targets (All Declaration Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Declaration layer defines data contracts used by all other layers
- Pure interface/DTO definitions with no implementation
- Consumed by Ideation layer
