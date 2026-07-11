---
title: Alis.App.Engine
tags:
  - project
  - engine
  - game-engine
  - application
  - layer-1
status: Draft
license: GPLv3
---

# Alis.App.Engine

## Overview

Main game engine application (Layer 1 - Presentation). The primary editor/engine executable that integrates all engine systems.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation |
| **Project Path** | `1_Presentation/Engine/src/` |
| **Test Project** | `Alis.App.Engine.Test` |
| **Generator** | Referenced from lower layers |
| **Has Samples** | No |
| **Output Type** | Exe |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Depends On**: [[Alis.Extension.Graphic.Ui]]
- **Depends On**: [[Alis.Extension.Updater]]
- **Depends On**: [[Alis.Extension.Io.FileDialog]]
- Also references all generator projects from Layers 2-6 as analyzers

## Architecture

- `src/Assets/` - Engine assets
- `src/Configuration/` - Configuration management
- `src/Core/` - Core engine logic
- `src/Demos/` - Demo scenes
- `src/Entity/` - Entity definitions
- `src/Fonts/` - Font resources
- `src/Icons/` - Icon resources
- `src/Menus/` - Menu system
- `src/Shaders/` - Shader programs
- `src/Shortcut/` - Keyboard shortcuts
- `src/Windows/` - Window management

## Build System

The Engine project has a sophisticated MSBuild system that:
1. References the Hub project for bundling
2. Creates platform-specific bundles (macOS DMG, Linux ZIP, Windows ZIP)
3. Manages asset packing through ZIP/base64 pipeline

## Testing

- Test project: `Alis.App.Engine.Test`
- Located at `1_Presentation/Engine/test/`

## Related

- [[Alis]]
- [[Alis.App.Hub]]
- [[Alis.Extension.Graphic.Ui]]
- [[Alis.Extension.Updater]]
- [[Projects Index]]
