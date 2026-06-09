---
title: Alis.App.Installer
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft
---


## Overview
Installer application for ALIS engine and game distribution. Handles runtime installation and configuration.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Installer)
- **Framework**: net8.0
- **Output Type**: Exe
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
- Used by Hub to install engine components
- Platform-specific output via RuntimeIdentifier
