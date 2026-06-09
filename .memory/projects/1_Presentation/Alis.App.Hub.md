# Alis.App.Hub

tags:
  - presentation,application,extension,documentation

## Overview
Editor hub application for ALIS game engine. Provides development environment and project management.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Editor/Hub)
- **Framework**: net8.0
- **Output Type**: Exe

## Purpose
Main editor interface for ALIS game engine. Provides visual development environment, project management, asset browser, and game preview capabilities. Serves as the primary development tool for ALIS creators.

## Key Components

### HubEngine Class
- Main engine runtime for the hub application
- OpenGL rendering with ImGui integration
- Multi-platform window management (OSX, Windows, Linux)

### Core Interfaces
- **IRuntime** - Runtime management
- **SpaceWork** - Workspace operations

### Entity Models
- **LearningResource** - Educational content management
- **Gallery** - Asset and project gallery
- **GalleryItem** - Individual gallery entries
- **InstalledVersion** - Version management
- **Project** - Project data model

### UI Components
- **HubWindow** - Main hub interface window
- **ImageLoader** - Asset image handling

## Dependencies
- [[Alis]] (2_Application) - Core application
- [[Alis.Extension.Graphic.Ui]] (1_Presentation) - UI framework
- [[Alis.Core.Graphic.OpenGL]] (4_Operation) - OpenGL rendering
- [[Alis.Core.Aspect.*]] (6_Ideation) - Various aspects
- [[Alis.Extension.Graphic.Ui.Extras]] - UI extras (GuizMo, Node, Plot)

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disabled
- **AllowUnsafeBlocks**: true (OpenGL interop)

### Platform-Specific Builds
- **macOS**: Creates .app bundle with Info.plist
- **Linux**: Creates zip distribution  
- **Windows**: Creates zip distribution

### Bundle Creation Targets
- CreateMacOsBundle - macOS .app bundle generation
- CreateLinuxBundle - Linux zip packaging
- CreateWindowsBundle - Windows zip packaging

## Testing Status
- **Unit Tests**: Present (Alis.App.Hub.Test)
- **Sample Apps**: None (editor only)

## Architecture Notes
1. OpenGL + ImGui for cross-platform UI
2. Native window integration per platform
3. Asset management and gallery system
4. Version control for installed engines

## Related Projects
- [[Alis.App.Engine]] - Runtime engine
- [[Alis.App.Installer]] - Installation wizard
- [[Alis.Extension.Graphic.Ui]] - UI framework

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
