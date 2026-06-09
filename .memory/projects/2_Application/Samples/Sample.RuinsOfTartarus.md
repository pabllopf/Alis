# Alis.Sample.RuinsOfTartarus

## Overview
Dungeon-themed game built on the ALIS engine featuring an animated background with a looping 2-frame torch/fire effect. Demonstrates animated sprite backgrounds, camera setup, and scene design for atmospheric environments.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — atmospheric scene with animated backdrop

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.RuinsOfTartarus.Desktop.csproj` |
| Web | `Alis.Sample.RuinsOfTartarus.Web.csproj` |

## Scene Structure ("Dungeon Entrance")
| GameObject | Components | Purpose |
|---|---|---|
| `Main Camera` | `Camera` (1024×768) | Game view |
| `Background` | `Sprite` (`Frame001.bmp`, depth -3), `Animator` (2-frame "Run" loop) | Animated dungeon backdrop |

## Animation
- **Name**: "Run"
- **Speed**: 0.04s (fast flicker — torch/candlelight effect)
- **Frames**: `Frame001.bmp` ↔ `Frame002.bmp` (2-frame ping-pong)

## Graphics
- **Resolution**: 1024×768
- **Background sprite depth**: -3

## Physics
- **Gravity**: `(0, -9.8)`
- **Debug**: Enabled

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Components.Render` — Sprite, Animator, Camera
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Shows Animator used for environmental effects (not just character animation)
- Fast animation speed (0.04s) creates flickering torchlight effect
- Build() termination on configuration sections indicates fluent Builder API variant
- Minimal scene setup — designed as atmospheric foundation for gameplay extension
