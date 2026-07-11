---
title: Alis.Extension.Graphic.Sfml
tags:
  - project
  - sfml
  - graphic
  - rendering
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Graphic.Sfml

## Overview

SFML graphics extension (Layer 1 - Extension). Provides SFML-based window management, audio, and rendering.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Graphic/Sfml/src/` |
| **Test Project** | `Alis.Extension.Graphic.Sfml.Test` |
| **Has Samples** | Yes (`Alis.Extension.Graphic.Sfml.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **Depends On**: [[Alis.Core.Graphic]] (via Alis)

## Architecture

- `src/Audios/` - SFML audio integration
- `src/Render/` - SFML rendering
- `src/runtimes/` - Native SFML binaries
- `src/Systems/` - SFML system utilities
- `src/Windows/` - SFML window management

## Source Structure

```
src/
  Audios/
  Render/
  runtimes/
  Systems/
  Windows/
```

## Related

- [[Alis.Core.Graphic]]
- [[Alis.Extension.Graphic.Sdl2]]
- [[Alis.Extension.Graphic.Glfw]]
- [[Projects Index]]
