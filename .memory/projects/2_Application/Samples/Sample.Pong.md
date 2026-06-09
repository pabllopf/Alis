---
title: Alis.Sample.Pong
tags:
  - application
  - sample
  - documentation

status: draft

license: GPLv3
---


## Overview
Classic Pong game built on the ALIS engine. Two-player local multiplayer with paddle collision, ball physics, and wall boundaries. Demonstrates kinematic body control, ball restitution physics, two-player input handling, and minimal scene setup.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference game — classic arcade implementation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Pong.Desktop.csproj` |
| Web | `Alis.Sample.Pong.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Camera` | `Camera` (1024×640) | Game view |
| `Soundtrack` | `AudioSource` (loop, volume 100) | Background music |
| `Player 1` (left) | `BoxCollider` (Kinematic), `PlayerController(1)` | Left paddle |
| `Player 2` (right) | `BoxCollider` (Kinematic), `PlayerController(2)` | Right paddle |
| `Ball` | `BoxCollider` (Dynamic) | Play ball |
| `downWall` | `BoxCollider` (Static) | Bottom boundary |
| `upWall` | `BoxCollider` (Static) | Top boundary |
| `leftWall` | `BoxCollider` (Static) | Left scoring boundary |
| `rightWall` | `BoxCollider` (Static) | Right scoring boundary |

## Key Scripts
| Script | Behavior |
|---|---|
| `PlayerController` | Keyboard input (W/S for P1, Up/Down for P2), paddle movement |

## Physics
- **Gravity**: `(0, -9.8)` — though all dynamic bodies have `IgnoreGravity(true)`
- **Ball**: Dynamic body, linear velocity `(-5.5, -5)`, restitution `1.0` (perfect bounce), friction `0`
- **Paddles**: Kinematic bodies (move via script, physics collision response)
- **Walls**: Static bodies (4 walls, some double as score zones)
- **Collision**: BoxCollider-based with perfect restitution for ball bounces

## Graphics
- **Resolution**: 1024×640

## Audio
- **Soundtrack**: `soundtrack.wav` (looping, volume 100)

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Components.Audio` — AudioSource
- `Alis.Core.Ecs.Components.Collider` — BoxCollider
- `Alis.Core.Ecs.Components.Render` — Sprite, Camera
- `Alis.Core.Physic` — Physics engine (BodyType)

## Notes
- Simplest game sample with physics-based gameplay
- Ball uses maximum restitution (1.0) for classic arcade bounce behavior
- No Sprite component on paddles/ball — purely physics-driven rendering
- Two-player input demonstrates `PlayerController` differentiation by player ID
- Wall colliders double as both boundaries and scoring triggers
- No UI overlay — scoring would occur through wall-trigger events
