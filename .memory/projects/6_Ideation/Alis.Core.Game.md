---
title: Alis.Core.Game
tags:
  - ideation
  - aspect
  - library
  - documentation

status: draft

license: GPLv3
---


## Overview
Game logic and state management for the ALIS engine. Provides game lifecycle, state machines, and game-specific utilities.

## Project Details
- **Layer**: 6_Ideation
- **Type**: Class Library
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

## Dependencies
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from other layers

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
- Game lifecycle management
- State machine implementation
- Game-specific utilities and helpers
