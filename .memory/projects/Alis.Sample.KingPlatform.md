---
title: Alis.Sample.KingPlatform
tags:
  - sample
  - game
  - platformer
  - 2d
status: Draft
license: GPLv3
---

# Alis.Sample.KingPlatform

## Overview

2D platformer sample demonstrating player movement, animation, camera follow, and game state serialization.

## Properties

| Property | Value |
|---|---|
| **Type** | Sample Game |
| **Path** | `2_Application/Alis/samples/alis.sample.king.platform/` |
| **Framework** | net10.0 |
| **Output Type** | Exe (AOT published) |

## Gameplay Features

- Player sprite with animated run cycle (3-frame animation)
- Platform physics with gravity
- Camera attached to player (follow-cam)
- Floor collision detection
- Game state save/load

## Components

| Component | Type | Description |
|---|---|---|
| `PlayerMovement` | Custom ECS Component | Player input and movement |
| `Animator` | Engine Component | 3-frame run animation |
| `BoxCollider` | Engine Component | Player/floor collision |
| `Camera` | Engine Component | Player-follow camera |
| `Sprite` | Engine Component | Visual |

## Notable

- Only sample that calls `game.Save()` before `game.Run()`
- Demonstrates engine serialization API
- Camera follows player entity

## Related

- [[Alis.Sample.Asteroid]]
- [[Alis.Sample.Dino]]
- [[Alis]]
- [[Samples Index]]
