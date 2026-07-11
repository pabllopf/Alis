---
title: Alis (Main Application)
tags:
  - project
  - application
  - composition
  - layer-2
status: Draft
license: GPLv3
---

# Alis (Main Application)

## Overview

Main application composition project (Layer 2 - Application). Serves as the root composition root that assembles all engine systems into a cohesive application.

## Properties

| Property | Value |
|---|---|
| **Layer** | 2 - Application |
| **Project Path** | `2_Application/Alis/src/` |
| **Test Project** | `Alis.Test` |
| **Generator** | `Alis.Generator` |
| **Has Samples** | Yes (12 sample projects) |

## Dependencies

- **Depends On**: [[Alis.Core]] (Layer 3 - Structuration)
- **Used By**: All Layer 1 projects ([[Alis.App.Engine]], [[Alis.App.Hub]], [[Alis.App.Installer]], [[Alis.Benchmark]])

## Architecture

- `src/Builder/` - Application builder
- `src/Core/` - Core composition
  - `src/Core/Ecs/` - ECS integration
    - `Components/` - Built-in ECS components
    - `Systems/` - Built-in ECS systems

## Source Structure

```
src/
  Builder/
    Core/
  Core/
    Ecs/
      Components/
      Systems/
```

## Samples

The Alis project includes 12 sample games:
- [[Alis.Sample.Asteroid]]
- [[Alis.Sample.Dino]]
- [[Alis.Sample.Egg]]
- [[Alis.Sample.Empty]]
- [[Alis.Sample.FlappyBird]]
- [[Alis.Sample.Inefable]]
- [[Alis.Sample.KingPlatform]]
- [[Alis.Sample.Pong]]
- [[Alis.Sample.Rogue]]
- [[Alis.Sample.RuinsOfTartarus]]
- [[Alis.Sample.Snake]]
- [[Alis.Sample.SpaceSimulator]]
- [[Alis.Sample.SplitCamera]]

## Testing

- Test project: `Alis.Test`
- Located at `2_Application/Alis/test/`

## Related

- [[Alis.Core]]
- [[Alis.App.Engine]]
- [[Samples Index]]
- [[Projects Index]]
