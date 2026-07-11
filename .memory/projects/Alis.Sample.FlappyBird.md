---
title: Alis.Sample.FlappyBird
tags:
  - sample
  - game
  - flappy-bird
  - arcade
status: Draft
license: GPLv3
---

# Alis.Sample.FlappyBird

## Overview

Full Flappy Bird clone demonstrating multi-scene game flow, animations, and collision-based game mechanics.

## Properties

| Property | Value |
|---|---|
| **Type** | Sample Game |
| **Path** | `2_Application/Alis/samples/alis.sample.flappy.bird/` |
| **Framework** | net10.0 |
| **Output Type** | Exe (AOT published) |

## Gameplay Features

- Two scenes: Main Menu and Game Scene
- Bird with 3-frame fly animation cycle
- Pipe obstacles with automatic scrolling
- Collision death zones
- Score counter
- Floor scrolling animation
- Main menu controller

## Components

| Component | Type | Description |
|---|---|---|
| `BirdController` | Custom ECS Component | Bird movement/flap |
| `BirdIdle` | Custom ECS Component | Idle animation state |
| `CounterController` | Custom ECS Component | Score display |
| `DeathZone` | Custom ECS Component | Collision detection |
| `FloorAnimation` | Custom ECS Component | Scrolling floor |
| `MainMenuController` | Custom ECS Component | Menu logic |
| `PipelineController` | Custom ECS Component | Pipe management |
| `Animator` | Engine Component | Frame animation |
| `BoxCollider` | Engine Component | Collision |
| `Sprite` | Engine Component | Visual |

## Settings

- Resolution: 288x512
- Target FPS: 30
- Graphics Target: OpenGL

## Related

- [[Alis.Sample.Asteroid]]
- [[Alis.Sample.Pong]]
- [[Alis]]
- [[Alis.Core.Ecs]]
- [[Samples Index]]
