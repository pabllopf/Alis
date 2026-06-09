---
title: Alis.Extension.Io.FileDialog
tags:
  - presentation
  - application
  - extension
  - documentation

status: draft

license: GPLv3
---


## Overview
Cross-platform file dialog extension for ALIS. Provides native open/save file dialog integration across Windows, macOS, and Linux.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~12 C# files

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (IO Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides native file dialog functionality (open/save dialogs) for ALIS applications. Abstracts platform-specific dialog APIs behind a unified managed interface.

## Key Components

### FileDialogManager
- Native open file dialog
- Native save file dialog
- File filter support
- Multi-file selection
- Directory selection

### Platform Abstractions
- Windows native dialog integration
- macOS native dialog integration
- Linux native dialog integration
- Fallback managed dialog implementation

## Dependencies
- [[Alis.Core.Aspect.Logging]] (6_Ideation) — Logging
- **System.Windows.Forms** — Windows native dialogs (Windows only)

## Build Configuration
- **LangVersion**: 13 (inherited)
- **Nullable**: disabled (project-specific)

## Platform Support
- Windows (native dialogs via WinForms)
- macOS (native dialogs via AppKit)
- Linux (native dialogs via GTK)

## Architecture Notes
1. Platform abstraction layer for native dialogs
2. Fallback to managed implementation when native unavailable
3. File filter pattern matching for type selection
4. Async/sync operation support

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Io.FileDialog.Test)
- **Sample App**: Present

## Related Projects
- [[Alis.Core.Aspect.Logging]] — Logging infrastructure
- [[Alis.Extension.Updater]] — File download operations

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-09
