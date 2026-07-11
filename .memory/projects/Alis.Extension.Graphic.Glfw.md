---
title: Alis.Extension.Graphic.Glfw
tags:
  - project
  - glfw
  - graphic
  - rendering
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Graphic.Glfw

## Overview

GLFW graphics extension (Layer 1 - Extension). Provides GLFW-based window and OpenGL context management.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Graphic/Glfw/src/` |
| **Test Project** | `Alis.Extension.Graphic.Glfw.Test` |
| **Has Samples** | Yes (`Alis.Extension.Graphic.Glfw.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Depends On**: [[Alis.Core.Graphic]] (via Alis)

## Architecture

- `src/Enums/` - GLFW enum definitions
- `src/Structs/` - GLFW struct definitions
- `src/runtimes/` - Native GLFW binaries

## Source Structure

```
src/
  Enums/
  Structs/
  runtimes/
```

## Related

- [[Alis.Core.Graphic]]
- [[Alis.Extension.Graphic.Sdl2]]
- [[Alis.Extension.Graphic.Sfml]]
- [[Projects Index]]
