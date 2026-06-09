---
title: Alis.App.Engine
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft

license: GPLv3
---


## Overview
Main game engine runtime application that launches and manages game instances.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Desktop)
- **Framework**: net8.0
- **Output Type**: Exe

## Purpose
Entry point for game execution. Launches the ALIS engine runtime and manages game lifecycle. Provides the main executable that users run to start ALIS-based applications.

## Key Components

### Program Class
- **Main** - Application entry point
  - Initializes engine instance
  - Calls Engine.Run() to start game loop
  
- **Engine** - Core engine runtime
  - Game loop management
  - Subsystem initialization
  - Platform-specific setup

## Dependencies
- [[Alis]] (2_Application) - Core application library
- All generators from 3_Structuration, 4_Operation, 5_Declaration, 6_Ideation

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disabled
- **AllowUnsafeBlocks**: false
- **SonarQubeExclude**: true

### Platform-Specific Builds
- **macOS**: Creates .app bundle with Info.plist and icon
- **Linux**: Creates zip distribution
- **Windows**: Creates zip distribution

### AOT & Trimming (Debug & Release)
- **PublishAot**: true
- **SelfContained**: true
- **PublishTrimmed**: true
- **TrimMode**: link
- **OptimizationPreference**: Size

## Asset Pipeline
- SHA256 hash-based change detection
- Incremental build via manifest file
- Asset packing and base64 encoding

## Testing Status
- **Unit Tests**: Present (Alis.App.Engine.Test)
- **Sample Apps**: None (runtime only)

## Architecture Notes
1. Minimal entry point - delegates to Engine class
2. Platform-specific bundle creation targets
3. Asset management system for game resources
4. AOT compilation support for performance

## Related Projects
- [[Alis.App.Hub]] - Editor hub application
- [[Alis.App.Installer]] - Installation wizard
- [[Alis]] (2_Application) - Core application framework

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
