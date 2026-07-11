---
title: Alis.Core.Graphic
tags:
  - project
  - graphic
  - rendering
  - opengl
  - layer-4
status: Draft
license: GPLv3
---

# Alis.Core.Graphic

## Overview

Graphics rendering library (Layer 4 - Operation). Provides OpenGL-based rendering pipeline with platform abstraction and UI integration.

## Properties

| Property | Value |
|---|---|
| **Layer** | 4 - Operation |
| **Project Path** | `4_Operation/Graphic/src/` |
| **Test Project** | `Alis.Core.Graphic.Test` |
| **Generator** | `Alis.Core.Graphic.Generator` |
| **Has Samples** | Yes (`Alis.Core.Graphic.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (via Layer 3/5 chain)
- **Depends On**: [[Alis.Core.Aspect.Math]]
- **Used By**: [[Alis.App.Engine]], Graphic extensions (SDL2, SFML, GLFW, UI)

## Architecture

- `src/OpenGL/` - OpenGL bindings and abstractions
- `src/Platforms/` - Platform-specific rendering (Mac, Windows, Linux, WebAssembly)
- `src/Ui/` - UI rendering system

## Source Structure

```
src/
  OpenGL/
  Platforms/
  Ui/
```

## Testing

- Test project: `Alis.Core.Graphic.Test`
- Located at `4_Operation/Graphic/test/`

## Related

- [[Alis.Core.Aspect.Math]]
- [[Alis.Extension.Graphic.Sdl2]]
- [[Alis.Extension.Graphic.Sfml]]
- [[Alis.Extension.Graphic.Glfw]]
- [[Alis.Extension.Graphic.Ui]]
- [[Projects Index]]
