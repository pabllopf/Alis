---
title: Alis.Extension.Graphic.Ui
tags:
  - presentation
  - application
  - extension
  - documentation

status: Draft

license: GPLv3

---


## Overview
ImGui (Immediate Mode GUI) bindings for C#. Provides cross-platform immediate mode graphical user interface.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0

## Project Details
- **Layer**: 1_Presentation
- **Type**: Library (UI Extension)
- **Framework**: net8.0
- **Output Type**: Class Library

## Purpose
Provides C# bindings for ImGui library (via cimgui native library). Enables rapid UI development with immediate mode rendering pattern. Used throughout ALIS for editor interfaces, debugging tools, and runtime UI.

## Key Components

### ImGuiNative Class
- P/Invoke bindings to cimgui native library
- All ImGui functions exposed as static methods
- Platform integration (IME, window management)

### Core Types
- **ImGuiBackendFlags** - Backend capability flags
- **ImGuiPlatformImeData** - Input method editor data
- **ImGuiWindowFlags** - Window creation flags
- **ImGuiPayload** - Drag and drop payload
- **Vector2F** - 2D vector for UI coordinates

### UI Extras (Separate Projects)
- **GuizMo** - 3D gizmos for scene editing
- **Node** - Node graph/editor functionality
- **Plot** - Data visualization and plotting

## Dependencies
- [[Alis.Core.Aspect.Math]] (6_Ideation) - Vector2F
- **cimgui** - Native ImGui bindings (via NuGet)

## Build Configuration
- **LangVersion**: 13
- **Nullable**: enabled
- **AllowUnsafeBlocks**: true (ImGui native calls)

## Platform Support
- Windows
- macOS
- Linux

## Testing Status
- **Unit Tests**: Present (Alis.Extension.Graphic.Ui.Test)
- **Sample Apps**: Included

## Architecture Notes
1. Immediate mode GUI pattern
2. Native cimgui library bindings
3. Platform-specific backend integration
4. Extension system for additional UI components

## Known Limitations
- Requires native cimgui library per platform
- Immediate mode requires high frame rates for smooth UI

## Related Projects
- [[Alis.Extension.Graphic.Ui.Extras.GuizMo]] - 3D gizmos
- [[Alis.Extension.Graphic.Ui.Extras.Node]] - Node editor
- [[Alis.Extension.Graphic.Ui.Extras.Plot]] - Data plotting

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
