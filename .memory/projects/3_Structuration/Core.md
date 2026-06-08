# Core Libraries (3_Structuration)

## Overview
The 3_Structuration layer contains foundational libraries that provide core abstractions and utilities for the ALIS engine. These are the building blocks upon which all other layers depend.

## Projects in this Layer
- [[Alis.Core]] — Core engine abstractions
- [[Alis.Core.Ecs]] — Entity Component System implementation
- [[Alis.Core.Graphic]] — Core graphics abstractions

## Common Pattern
All Structuration projects follow the standard pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
All depend on:
- [[Alis]] (2_Application) — Core application library
- All generators from 4_Operation, 5_Declaration, 6_Ideation

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

## Key Build Targets (All Structuration Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Structuration layer provides the foundational abstractions
- These libraries are consumed by Operation layer and above
- No Presentation layer dependencies (pure domain logic)
