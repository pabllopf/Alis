---
title: Alis.Extension.Graphic.Ui
tags:
  - project
  - ui
  - im-gui
  - graphic
  - interface
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Graphic.Ui

## Overview

Immediate Mode GUI extension (Layer 1 - Extension). Provides Dear ImGui bindings for the engine, enabling debug overlays, editor UI, and in-game interfaces.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Graphic/Ui/src/` |
| **Test Project** | `Alis.Extension.Graphic.Ui.Test` |
| **Has Samples** | Yes (`Alis.Extension.Graphic.Ui.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Depends On**: [[Alis.Core.Graphic]] (via Alis)

## Architecture

- `src/Extras/` - ImGui extra utilities
- `src/Fonts/` - Font management for ImGui
- `src/runtimes/` - Native ImGui binaries
- Contains 90+ ImGui binding files (ImGui.cs, ImGuiNative.cs, ImDrawList.cs, etc.)

## Source Structure

```
src/
  Extras/
  Fonts/
  runtimes/
```

## Notes

This is the largest single source directory in the repository with over 115 files, all dedicated to Dear ImGui bindings and wrappers.

## Related

- [[Alis.Core.Graphic]]
- [[Alis.App.Engine]]
- [[Projects Index]]
