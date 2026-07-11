---
title: Alis.Extension.Graphic.Sdl2
tags:
  - project
  - sdl2
  - graphic
  - rendering
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Graphic.Sdl2

## Overview

SDL2 graphics extension (Layer 1 - Extension). Provides SDL2-based window management, rendering, and input handling with image and TrueType font support.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Graphic/Sdl2/src/` |
| **Test Project** | `Alis.Extension.Graphic.Sdl2.Test` |
| **Has Samples** | Yes (`Alis.Extension.Graphic.Sdl2.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Depends On**: [[Alis.Core.Graphic]] (via Alis)

## Architecture

- `src/Delegates/` - SDL2 delegate definitions
- `src/Enums/` - SDL2 enum definitions
- `src/Mapping/` - Platform/Runtime mapping
- `src/runtimes/` - Native SDL2 binaries per platform
- `src/Sdl2Image/` - SDL2_image integration
- `src/Sdl2Ttf/` - SDL2_ttf font integration
- `src/Structs/` - SDL2 struct definitions

## Native Dependencies

Requires SDL2 native libraries per platform:
- macOS: `brew install sdl2 sdl2_image sdl2_ttf`
- Linux: `apt install libsdl2-dev libsdl2-image-dev libsdl2-ttf-dev`
- Windows: Included via NuGet or manual install

## Source Structure

```
src/
  Delegates/
  Enums/
  Mapping/
  runtimes/
  Sdl2Image/
  Sdl2Ttf/
  Structs/
```

## Testing

- Test project: `Alis.Extension.Graphic.Sdl2.Test`
- Located at `1_Presentation/Extension/Graphic/Sdl2/test/`

## Related

- [[Alis.Core.Graphic]]
- [[Alis.Extension.Graphic.Sfml]]
- [[Alis.Extension.Graphic.Glfw]]
- [[Projects Index]]
