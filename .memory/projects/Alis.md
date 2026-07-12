---
title: Alis (Application)
tags:
  - application
  - main
  - framework
  - game-engine
status: Draft
license: GPLv3
---

# Alis (Application Assembly)

**Layer:** 2_Application
**Path:** `2_Application/Alis/src/Alis.csproj`

## Purpose

The main game framework assembly. Orchestrates all subsystems (audio, graphics, physics, ECS, input, networking) and provides the public API surface for game development.

## Architecture

### Builder Pattern
- `Builder/Core/Ecs/Components/` — Component builders (Light, Audio, Collider, Render, Body, UI)
- `Builder/Core/Ecs/Entity/` — Entity construction
- `Builder/Core/Ecs/System/` — System configuration builders (ManagerBuilders, ConfigurationBuilders)

### Core ECS Integration
- `Core/Ecs/Systems/` — System definitions for:
  - Scope, Execution
  - Manager (Scene, Physic, Audio, Graphic, Time, Network, Input)
  - Configuration
- `Core/Ecs/Components/` — Game-ready component types:
  - Light, Audio, Collider, Render, Body, UI
  - `Transform`, `Info`

## Dependencies

- Alis.Core (3_Structuration)
- All generators (via Config.props)

## Upstream Dependents

- All Presentation projects (1_Presentation)
- All Extension projects

## Source Generator

**Path:** `2_Application/Alis/generator/`

- `Alis.Generator.csproj` — Application-level code generation

## Samples

12 C# sample games demonstrating engine capabilities:
- Asteroid, Dino, Egg, Empty, FlappyBird, Inefable
- KingPlatform, Pong, Rogue, RuinsOfTartarus, Snake
- SpaceSimulator, SplitCamera

## Testing

**Path:** `2_Application/Alis/test/`

- `Alis.Test.csproj` — Integration and unit tests for the application assembly
- Tests cover ECS systems, configuration, and game object lifecycle

## Related Documents

- [[Alis.Core]]
- [[Alis.Core.Ecs]]
- [[Alis.App.Engine]]
- [[repository-overview]]
