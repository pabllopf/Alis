---
title: Alis.Sample.Egg
tags:
  - application
  - sample
  - documentation

status: draft
---


## Overview
**"The Egg"** — a narrative/philosophical game based on Andy Weir's short story, built on the ALIS engine. Demonstrates configuration-driven scene setup with named scene and sound track, suitable for narrative-focused game experiences.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — narrative game foundation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Egg.Desktop.csproj` |
| Web | `Alis.Sample.Egg.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Sound Track` | (transform only) | Audio placeholder |

## Configuration
- **Name**: "The Egg"
- **Resolution**: 800×600
- **Gravity**: `(0, -9.8)`
- **Icon**: `app.ico`

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Named after Andy Weir's "The Egg" — suggests narrative/dialogue focus
- Audio volume set to 50 (balanced for dialogue)
- Basic scene with named GameObject — foundation for narrative interactions
- Uses `.ico` icon format (vs `.bmp` used by other samples)
