# Alis.Sample.Rogue

tags:
  - application,sample,documentation

## Overview
Roguelike 2D game built on the ALIS engine. Features a foundational dungeon-crawler setup with physics, audio, and a named sound track. Demonstrates the base configuration for tile-based or procedurally generated roguelike experiences.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — roguelike foundation

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Rogue.Desktop.csproj` |
| Web | `Alis.Sample.Rogue.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Sound Track` | (transform only) | Audio placeholder |

## Configuration
- **Name**: "T-Rex Dino Game" (note: likely placeholder name)
- **Resolution**: 800×600
- **Gravity**: `(0, -9.8)`
- **Audio volume**: 50

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Name may be a placeholder copy-paste from Dino sample
- Provides base scene + physics for roguelike gameplay extension
- Roguelike genre systems (procedural generation, turn-based movement, etc.) would extend this foundation
