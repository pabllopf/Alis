---
title: Alis.Sample.Asteroid
tags:
  - sample
  - game
  - arcade
  - asteroid
status: Draft
license: GPLv3
---

# Alis.Sample.Asteroid

## Overview

Full Asteroids arcade clone demonstrating core engine capabilities: ECS, physics, audio, graphics, and collision detection.

## Properties

| Property | Value |
|---|---|
| **Type** | Sample Game |
| **Path** | `2_Application/Alis/samples/alis.sample.asteroid/` |
| **Framework** | net10.0 |
| **Output Type** | Exe (AOT published) |

## Gameplay Features

- Player spaceship with thrust and rotation
- Asteroid spawning with random trajectories
- Bullet firing
- Collision-based health/damage system
- Score counter
- Soundtrack audio
- Arena boundaries with wall colliders

## Components

| Component | Type | Description |
|---|---|---|
| `Player` | Custom ECS Component | Player ship data |
| `Asteroid` | Custom ECS Component | Asteroid data |
| `Bullet` | Custom ECS Component | Projectile data |
| `SpawnAsteroid` | Custom ECS Component | Asteroid spawner |
| `CounterManager` | Custom ECS Component | Score tracking |
| `HealthController` | Custom ECS Component | Damage handling |
| `BoxCollider` | Engine Component | Collision shapes |
| `AudioSource` | Engine Component | Sound playback |
| `Sprite` | Engine Component | Visual rendering |

## Physics

- Uses `BoxCollider` for all entities
- `BodyType.Dynamic` for player and asteroids
- Wall colliders for arena boundaries
- Collision-based interactions

## Related

- [[Alis.Sample.Pong]]
- [[Alis.Sample.FlappyBird]]
- [[Alis]]
- [[Alis.Core.Ecs]]
- [[Samples Index]]
