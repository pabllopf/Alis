---
title: Alis.Core.Resource
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft
---


## Overview
Resource loading and management system for the ALIS engine. Handles asset loading, caching, and lifecycle management.

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
- Asset loading and caching
- Resource lifecycle management
- Dependency tracking for assets
