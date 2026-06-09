---
title: Alis.App.Installer
tags:
  - presentation
  - application
  - extension
  - documentation

status: Draft

license: GPLv3

---


## Overview
Installation wizard application for ALIS game engine. Handles engine installation, updates, and version management.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Installer)
- **Framework**: net8.0
- **Output Type**: Exe

## Purpose
Provides user-friendly installation experience for ALIS engine. Handles downloading, installing, updating, and managing different engine versions. Integrates with Hub for seamless setup experience.

## Key Components

### Installer Class
- **Run** - Main installation workflow
  - Downloads engine packages
  - Extracts to target location
  - Registers with system
  
- **Program** - Entry point
  - Parses command-line arguments
  - Initializes installer instance

### Interfaces
- **IExample** - Example installation scenarios
- **ImguiSample** - ImGui-based installer UI

## Dependencies
- [[Alis.Extension.Graphic.Ui]] (1_Presentation) - UI framework with ImGui
- [[Alis]] (2_Application) - Core framework

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disabled
- **AllowUnsafeBlocks**: true (ImGui interop)

## Features
1. Multi-platform installation (Windows, macOS, Linux)
2. Version selection and management
3. Automatic updates
4. Integration with Hub application
5. Command-line installation support

## Testing Status
- **Unit Tests**: Present (Alis.App.Installer.Test)
- **Sample Apps**: None

## Architecture Notes
1. ImGui-based cross-platform UI
2. Download manager for engine packages
3. Version comparison and upgrade logic
4. System integration (registry, shortcuts, etc.)

## Related Projects
- [[Alis.App.Engine]] - Runtime engine
- [[Alis.App.Hub]] - Editor hub
- [[Alis.Extension.Graphic.Ui]] - UI framework

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
