# Core Libraries (6_Ideation)

## Overview
The 6_Ideation layer contains ideation libraries that provide high-level game-specific functionality, utilities, and domain logic. These are the most specialized libraries in the architecture.

## Projects in this Layer
- [[Alis.Core.Game]] — Game logic and state management
- [[Alis.Core.Network]] — Networked game functionality

## Common Pattern
All Ideation projects follow the standard pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
All depend on:
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from other layers

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

## Key Build Targets (All Ideation Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Ideation layer contains game-specific domain logic
- Most specialized libraries in the architecture
- Consumed by Presentation layer applications
