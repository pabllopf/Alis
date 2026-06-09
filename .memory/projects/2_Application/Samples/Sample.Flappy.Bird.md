---
title: Alis.Sample.Flappy.Bird
tags:
  - application
  - sample
  - documentation

status: draft

license: GPLv3
---


## Overview
Complete Flappy Bird clone built on the ALIS engine. Features a bird with animated wing flaps, procedurally generated pipes, scrolling floor, score counter, and two-scene game flow (main menu + gameplay). Demonstrates scene management, sprite animation, trigger-based scoring, and physics collisions.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference game — arcade-style runner

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Flappy.Bird.Desktop.csproj` |
| Web | `Alis.Sample.Flappy.Bird.Web.csproj` |

## Scene Structure

### Main Menu Scene ("Main_Menu")
| GameObject | Components | Purpose |
|---|---|---|
| `Camera` | `Camera` (288×512, black background) | Menu view |
| `Background` | `Sprite` (`background-day.bmp`) | Static background |
| `Floor` | `Sprite`, `FloorAnimation` script | Animated scrolling floor |
| `Message Menu` | `Sprite` (`message.bmp`), `MainMenuController` script | Start prompt |
| `Bird` | `Sprite`, `Animator` (3-frame "Fly"), `BirdIdle` script | Idle bird animation |
| `Soundtrack` | `AudioSource` (loop, `main_theme.wav`) | Background music |
| `Counter` | Transform holder | Score display container |

### Game Scene ("Game_Scene")
| GameObject | Components | Purpose |
|---|---|---|
| `Camera` | `Camera` (288×512) | Game view |
| `Background` | `Sprite` (`background-day.bmp`) | Scrolling background |
| `Floor` | `Sprite`, `FloorAnimation` | Animated floor |
| `Floor Collision` | `BoxCollider` (Kinematic), `DeathZone` | Kill zone |
| `Sky Collision` | `BoxCollider` (Kinematic), `DeathZone` | Ceiling boundary |
| `Pipeline UP` | `Sprite`, `BoxCollider` (Trigger), `PipelineController`, `DeathZone` | Top pipe |
| `Pipeline Middle` | `BoxCollider` (Trigger), `AudioSource`, `PipelineController`, `CounterController` | Score trigger zone |
| `Pipeline Down` | `Sprite`, `BoxCollider` (Trigger), `PipelineController`, `DeathZone` | Bottom pipe |
| `Bird` (Player) | `Sprite`, `Animator`, `AudioSource`, `BoxCollider`, `BirdController` | Player character |

## Key Scripts
| Script | Behavior |
|---|---|
| `BirdController` | Flap on input, apply upward force, rotation based on velocity |
| `BirdIdle` | Idle bobbing animation on menu |
| `PipeLineController` | Pipe movement, recycling off-screen pipes, random height |
| `FloorAnimation` | Endless scrolling floor texture |
| `CounterController` | Score tracking on trigger enter (pipe middle zone) |
| `DeathZone` | Collision detection — triggers game over |
| `MainMenuController` | Menu input handling to start game |

## Physics
- **Gravity**: `(0, -4.5)` — reduced gravity for flappy feel
- **Bird**: Dynamic body, `IgnoreGravity(false)`, 1×1 collider
- **Pipes/Floor**: Kinematic bodies (moving colliders)
- **Debug**: Red debug rendering in Debug builds only

## Graphics
- **Resolution**: 288×512 (portrait mobile aspect)
- **Background color**: Sky blue `(141, 212, 247)`
- **Frame rate**: 30 FPS (targeted)
- **Window**: Non-resizable
- **Renderer**: OpenGL target
- **Animations**: 3-frame bird wing flap at 0.2s speed

## Audio
- **Soundtrack**: `main_theme.wav` (looping)
- **SFX**: `wing.wav` (flap), `point.wav` (score)

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Aspect.Math.Definition` — Color, Transform
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Components` — Audio, Collider, Render, Animator
- `Alis.Core.Physic` — Physics engine

## Notes
- Two-scene architecture demonstrates ALIS scene management
- Uses trigger colliders for score zones (not physics response)
- Animator component shows multi-frame sprite animation
- Floor animation demonstrates transform-based scrolling without physics
- Demonstrates debug-mode conditional physics visualization
