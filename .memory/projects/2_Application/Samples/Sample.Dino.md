---
title: Alis.Sample.Dino
tags:
  - application
  - sample
  - documentation

status: Draft

license: GPLv3

---


## Overview
Chrome T-Rex Dino game clone built on the ALIS engine. Features a runner-style game with physics, basic scene setup, and audio. Demonstrates configuration with settings blocks and minimalist world construction.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — runner game implementation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Dino.Desktop.csproj` |
| Web | `Alis.Sample.Dino.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `SoundTrack` | (empty) | Audio placeholder |

## Configuration
- **Name**: "T-Rex Dino Game"
- **Resolution**: 800×600
- **Gravity**: `(0, -9.8)`
- All configuration sections use `.Build()` termination

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Demonstrates multi-section configuration pattern (Settings blocks)
- Soundtrack GameObject exists as placeholder — audio setup deferred to gameplay scripts
- Uses Build() method termination (fluent API variant)
- Gameplay logic expected in separate script files
