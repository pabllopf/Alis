---
title: Alis.Sample.Asteroid
tags:
  - application
  - sample
  - documentation

status: draft
---


## Overview
Classic Asteroids arcade game clone built on the ALIS engine. The player controls a spaceship in an asteroid field, shooting asteroids while avoiding collisions. Demonstrates physics-based movement, collision detection, projectile spawning, audio feedback, and multi-platform deployment (Desktop, Web, iOS, Android).

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample (multi-platform)
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web, iOS, Android (4 targets — most complex sample)
- **Purpose**: Educational/reference game — full arcade implementation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Asteroid.Desktop.csproj` |
| Web | `Alis.Sample.Asteroid.Web.csproj` |
| iOS | `Alis.Sample.Asteroid.IOS.csproj` |
| Android | `Alis.Sample.Asteroid.Android.csproj` |

## Scene Structure
### Main Scene
| GameObject | Components | Purpose |
|---|---|---|
| `Camera` | `Camera` (1024×640, black background) | Main game view |
| `Player` | `Sprite`, `AudioSource`, `BoxCollider`, `Player` script | Player ship |
| `Asteroid` (×2) | `Sprite`, `Asteroid` script, `BoxCollider` | Destructible obstacles |
| `Spawn Point Asteroid` | Transform only | Asteroid spawn location |
| `Counter` | Tag: "Points" | Score tracking |
| `HealthController` | Tag: "HealthController" | Lives/health tracking |
| `Soundtrack` | `AudioSource` (loop, volume 50) | Background music |
| `SoundPlayer` | `AudioSource` (one-shot) | SFX (explosion, fire) |
| Walls (×4) | `BoxCollider` (Static) | Screen boundaries |

## Key Scripts
| Script | Implements | Behavior |
|---|---|---|
| `Player` | `IOnStart`, `IOnUpdate`, `IOnHoldKey`, `IOnPressKey` | WASD movement, Space to fire, auto-fire timer |
| `Asteroid` | Custom component | Asteroid behavior (destructible, splits) |
| `Bullet` | Custom component | Projectile behavior |
| `SpawnAsteroid` | Custom component | Asteroid wave spawning |
| `CounterManager` | Custom component | Score tracking |
| `HealthController` | Custom component | Lives/health management |

## Physics
- **Gravity**: `(0, -9.8)` — standard downward gravity
- **Player**: Dynamic body, `IgnoreGravity(true)`, max velocity clamped to 3.0
- **Asteroids**: Dynamic bodies, `IgnoreGravity(true)`, random initial velocity
- **Walls**: Static bodies, no friction
- **Collision**: BoxCollider-based with restitution/friction tuning

## Audio
- **Soundtrack**: Looping background music (`soundtrack.wav`)
- **SFX**: Player fire (`fire.wav`), asteroid explosion (`bangLarge.wav`)

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Aspect.Math` — Vector math
- `Alis.Core.Ecs` — ECS core (Scene, GameObject, components)
- `Alis.Core.Ecs.Components.Audio` — AudioSource
- `Alis.Core.Ecs.Components.Collider` — BoxCollider
- `Alis.Core.Ecs.Components.Render` — Sprite, Camera, Transform
- `Alis.Core.Physic` — Physics engine (BodyType, body manipulation)

## Notes
- Uses the Fluent API (`VideoGame.Create()`) for full declarative scene setup
- Player implements `IHasContext<Context>` for engine context access (TimeManager, SceneManager)
- Demonstrates runtime entity creation (`CreateBullet`) as gameplay mechanic
- Only sample targeting 4 platforms (Desktop, Web, iOS, Android)
- Assets stored per-platform in `Assets/` directory
