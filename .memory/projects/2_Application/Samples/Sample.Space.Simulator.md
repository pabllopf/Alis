---
title: Alis.Sample.Space.Simulator
tags:
  - application
  - sample
  - documentation

status: draft

license: GPLv3
---


## Overview
Space simulation game built on the ALIS engine. Provides a physics-based foundation for space/sandbox gameplay with basic scene setup and audio placeholder.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — space simulation foundation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Space.Simulator.Desktop.csproj` |
| Web | `Alis.Sample.Space.Simulator.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Sound Track` | (transform only) | Audio placeholder |

## Configuration
- **Name**: "T-Rex Dino Game" (note: likely placeholder)
- **Resolution**: 800×600
- **Gravity**: `(0, -9.8)`
- **Audio volume**: 50

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Name field appears to be a placeholder (copy-paste from Dino sample)
- Gameplay scripts (spacecraft physics, orbital mechanics, etc.) would extend this foundation
- Basic scene with Sound Track placeholder for spatial audio
