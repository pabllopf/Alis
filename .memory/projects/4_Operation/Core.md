---
title: Core Libraries (4_Operation)
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft
---


## Overview
The 4_Operation layer contains operational libraries that provide concrete implementations and runtime services for the ALIS engine. These build upon the abstractions in 3_Structuration.

## Projects in this Layer
- [[Alis.Core.Audio]] — Audio engine and sound management
- [[Alis.Core.Input]] — Input handling (keyboard, mouse, gamepad)
- [[Alis.Core.Physics]] — Physics simulation
- [[Alis.Core.Resource]] — Resource loading and management
- [[Alis.Core.Scene]] — Scene management
- [[Alis.Core.Serialization]] — Data serialization
- [[Alis.Core.Window]] — Window management

## Common Pattern
All Operation projects follow the standard pattern:
- src/ — Main library
- test/ — Unit tests (SonarQube excluded)
- sample/ — Sample applications

## Dependencies
All depend on:
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from 5_Declaration, 6_Ideation

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

## Key Build Targets (All Operation Projects)
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Operation layer provides concrete runtime implementations
- Builds upon Structuration layer abstractions
- Consumed by Declaration and Ideation layers

## Related
- [[projects/3_Structuration/Alis.Core]] — Core abstractions
- [[projects/5_Declaration/Core]] — Declaration layer
- [[projects/6_Ideation/Core]] — Ideation layer
- [[projects/2_Application/Alis]] — Application layer
- [[projects/4_Operation/Ecs]] — ECS subsystem
- [[projects/Cross-Cutting-Concerns]] — Build config
- [[Layered Architecture]] — Layer structure
- [[Alis Architecture Overview]] — Full architecture
- [[generator-pattern]] — Generator pattern
- [[operation-index]] — Operations index
