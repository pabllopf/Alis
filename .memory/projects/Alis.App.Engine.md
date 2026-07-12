---
title: Alis.App.Engine
tags:
  - presentation
  - engine
  - editor
  - imgui
status: Draft
license: GPLv3
---

# Alis.App.Engine

**Layer:** 1_Presentation
**Path:** `1_Presentation/Engine/src/Alis.App.Engine.csproj`

## Purpose

Game engine editor application with ImGui-based UI. Provides a visual development environment for building games with the Alis framework.

## Features

- ImGui-based editor UI
- Scene, game, inspector, project, asset, console, audio player, and solution windows
- DockSpace menu, top/bottom menus
- Shortcuts system
- Custom shader support
- Font management (Hack, Jetbrain, Segoe)
- Demo modes (ImGui, ImGuizmo, ImNode, ImPlot)
- Project management

## Architecture

- `Engine.cs` — Main engine class
- `Program.cs` — Entry point
- `Windows/` — Editor window implementations (12+ window types)
- `Menus/` — Menu system
- `Icons/` — Icon management
- `Fonts/` — Font assets
- `Shaders/` — Shader code
- `Configuration/` — Editor configuration
- `Core/` — Runtime abstractions
- `Demos/` — Feature demos

## Dependencies

- Alis (2_Application)

## Testing

**Path:** `1_Presentation/Engine/test/`

## Related Documents

- [[Alis]]
- [[Alis.App.Hub]]
- [[Alis.App.Installer]]
