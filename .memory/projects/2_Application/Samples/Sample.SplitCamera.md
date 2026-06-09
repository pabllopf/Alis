# Alis.Sample.SplitCamera

## Overview
Split-screen camera demonstration built on the ALIS engine. Features a `Config/` directory likely containing multi-camera configuration files. Demonstrates the engine's ability to render multiple viewports simultaneously.

## Project Details
- **Layer**: 2_Application
- **Type**: Technical Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Technical reference — split-screen/multi-viewport rendering

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.SplitCamera.Desktop.csproj` |
| Web | `Alis.Sample.SplitCamera.Web.csproj` |

## Scene Structure
| GameObject | Components | Purpose |
|---|---|---|
| `Sound Track` | (transform only) | Audio placeholder |

## Configuration
- **Name**: "T-Rex Dino Game" (placeholder)
- **Resolution**: 800×600
- **Gravity**: `(0, -9.8)`

## Key Features
- `Config/` directory suggests JSON/XML configuration for camera layouts
- Unique among samples for having a configuration directory
- Split-camera rendering useful for multiplayer/local co-op games

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs` — ECS, Scene, GameObject
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- `Config/` directory is unique to this sample — may contain camera layout configuration
- Demonstrates multi-viewport rendering pipeline of the ALIS engine
- Name appears to be a placeholder (copy-paste)
- Technical demonstration rather than gameplay-focused
