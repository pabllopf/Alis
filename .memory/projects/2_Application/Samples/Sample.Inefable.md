---
title: Alis.Sample.Inefable
tags: [application,sample,documentation]
---


## Overview
**Inefable** — a "Roguelike 2D multiplayer with RPG and arcade components" built on the ALIS engine. The most narratively ambitious sample, featuring a dungeon entrance scene with animated background, sprite rendering, and camera system. Intended as a reference for more complex game compositions combining multiple genres.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — hybrid genre game composition

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Inefable.Desktop.csproj` |
| Web | `Alis.Sample.Inefable.Web.csproj` |

## Scene Structure ("Dungeon Entrance")
| GameObject | Components | Purpose |
|---|---|---|
| `Main Camera` | `Camera` (1024×768) | Game view |
| `Background` | `Sprite` (`Draw001.bmp`, depth -3, tagged "Environment") | Dungeon backdrop |

## Graphics
- **Resolution**: 1024×768
- **Sprite depth**: -3 (renders behind other elements)

## Physics
- **Gravity**: `(0, -9.8)`
- **Debug**: Enabled

## Audio
- **Volume**: 100

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Components.Render` — Sprite, Camera
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Most complex game description among samples ("Roguelike 2D multiplayer with RPG and arcade components")
- Current implementation is a minimal scene setup (camera + background) — gameplay systems would extend this foundation
- Uses `General.Debug(false)` — release-mode configuration
- Build() calls terminate each configuration section (fluent API variant)
