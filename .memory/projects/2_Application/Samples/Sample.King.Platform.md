---
title: Alis.Sample.King.Platform
tags:
  - application
  - sample
  - documentation

status: Draft

license: GPLv3

---


## Overview
2D platformer game built on the ALIS engine. A king character with animated run cycle, physics-based movement on platform terrain, and a following camera. Demonstrates sprite animation, dynamic/static collision, camera attachment to game objects, and scene persistence via `VideoGame.Save()`.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — platformer implementation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.King.Platform.Desktop.csproj` |
| Web | `Alis.Sample.King.Platform.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Player` (king) | `Sprite`, `Animator` (3-frame "Run"), `BoxCollider` (Dynamic), `PlayerMovement` script, `Camera` | Player character with attached camera |
| Platform floor | `BoxCollider` (Static, 20×1) | Ground platform |

## Key Scripts
| Script | Behavior |
|---|---|
| `PlayerMovement` | Horizontal movement input, jump, gravity response |

## Physics
- **Gravity**: `(0, -9.8)` — standard platformer gravity
- **Player**: Dynamic body, `IgnoreGravity(false)` — affected by gravity
- **Platform**: Static body, floor collision
- **Collision**: BoxCollider with AutoTilling enabled on player

## Graphics
- **Resolution**: 640×480
- **Background color**: Cyan
- **Animations**: 3-frame "Run" animation at 0.125s speed (`tile036.bmp`, `tile038.bmp`, `tile039.bmp`)

## Key Features
- `Camera` component attached directly to player GameObject (follows player)
- `VideoGame.Save()` called before `Run()` — serializes scene configuration
- Demonstrates `Animator` with multi-frame animation on a game entity
- Uses `BoxColliderBuilder` fluent construction pattern

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Aspect.Math.Definition` — Color
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Components.Collider` — BoxCollider
- `Alis.Core.Ecs.Components.Render` — Sprite, Animator, Camera
- `Alis.Core.Physic` — Physics engine

## Notes
- Camera-on-player pattern avoids needing a separate camera tracking system
- Unique among samples for calling `game.Save()` before `game.Run()`
- Minimal scene — single player + single platform demonstrates core platformer mechanics
- Fluent Builder API used throughout (`AnimatorBuilder`, `BoxColliderBuilder`, etc.)
