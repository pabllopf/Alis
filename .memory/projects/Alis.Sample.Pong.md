---
title: Alis.Sample.Pong
tags:
  - sample
  - game
  - pong
  - arcade
status: Draft
license: GPLv3
---

# Alis.Sample.Pong

## Overview

Classic Pong clone demonstrating 2-player input handling, physics collisions, and audio integration.

## Properties

| Property | Value |
|---|---|
| **Type** | Sample Game |
| **Path** | `2_Application/Alis/samples/alis.sample.pong/` |
| **Framework** | net10.0 |
| **Output Type** | Exe (AOT published) |

## Gameplay Features

- 2-player local multiplayer
- Ball with physics-based movement
- Perfect bouncing (restitution 1.0)
- Paddle collision-based ball deflection
- Arena wall boundaries
- Soundtrack audio

## Components

| Component | Type | Description |
|---|---|---|
| `PlayerController` | Custom ECS Component | 2-player input handling (161 lines) |
| `BoxCollider` | Engine Component | Paddle, ball, wall collisions |
| `AudioSource` | Engine Component | Background music |
| `Sprite` | Engine Component | Visual rendering |

## Physics

- Ball uses `LinearVelocity` for movement
- `BoxCollider` with `Restitution(1.0)` for perfect bouncing
- Static wall colliders for arena boundaries

## Related

- [[Alis.Sample.Asteroid]]
- [[Alis.Sample.FlappyBird]]
- [[Alis]]
- [[Samples Index]]
