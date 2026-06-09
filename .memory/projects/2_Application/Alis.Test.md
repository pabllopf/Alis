---
title: Alis.Test
tags:
  - application
  - sample
  - documentation

status: draft
---


## Overview
Unit tests for the core Alis application library.

## Project Details
- **Layer**: 2_Application
- **Type**: Test Project
- **Framework**: net8.0
- **Output Dir**: `bin/$(Configuration)/$(RuntimeIdentifier)/test/$(TargetFramework)/`

## Dependencies
- [[Alis]] (2_Application) — Source project under test
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disable
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true

## Test Discovery Pattern
- Uses regex to find source project: `Alis.Test.csproj` → matches `Alis.csproj`
- Pattern: `<ProjectReference Include="..\src\Alis.csproj" />`

## Asset Pipeline
- Uses [[#Asset Pack System]] for resource management
- SHA256 hash-based change detection
- Incremental build via manifest file

## Key Build Targets
- `_PrepareAssetPackManifest` — Generates asset manifest with SHA256 hashes
- `ZipAssets` — Zips assets and encodes to base64

## Notes
- Excluded from SonarQube analysis
- Test output goes to `test/` subdirectory
