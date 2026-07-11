---
title: Alis.Extension.Math.ProceduralDungeon
tags:
  - project
  - dungeon
  - procedural-generation
  - math
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Math.ProceduralDungeon

## Overview

Procedural dungeon generation extension (Layer 1 - Extension). Provides algorithms for procedural dungeon and map generation using validation-based generation.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Math/ProceduralDungeon/src/` |
| **Test Project** | `Alis.Extension.Math.ProceduralDungeon.Test` |
| **Has Samples** | Yes |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)

## Architecture

- `src/Helpers/` - Dungeon generation helpers
- `src/Interfaces/` - Generation interfaces
- `src/Models/` - Dungeon data models (Dungeon, BoardSquare, Direction)
- `src/Services/` - Generation services
- `src/Validators/` - Dungeon validation logic

## Source Structure

```
src/
  Helpers/
  Interfaces/
  Models/
  Services/
  Validators/
```

## Key Types

- `Dungeon` - Core dungeon data structure
- `BoardSquare` - Individual tile/square representation
- `Direction` - Direction enumeration
- Various validators ensuring generated dungeons meet requirements

## Testing

- Test project at `1_Presentation/Extension/Math/ProceduralDungeon/test/`

## Related

- [[Alis.Extension.Math.HighSpeedPriorityQueue]]
- [[Projects Index]]
