---
title: Alis.Core.Window
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft
---


## Overview
Window management system for the ALIS engine. Handles window creation, resizing, fullscreen mode, and platform-specific window behavior.

## Project Details
- **Layer**: 4_Operation
- **Type**: Class Library
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/lib/$(TargetFramework)/`

## Dependencies
- [[Alis.Core]] (3_Structuration) — Core engine abstractions
- [[Alis]] (2_Application) — Core application library
- All generators from 5_Declaration, 6_Ideation

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
- Cross-platform window management
- Window resizing and fullscreen support
- Platform-specific window behavior
