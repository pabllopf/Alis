# Alis

## Overview
Core application framework for the ALIS cross-platform game engine.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: ~88 C# files

## Project Details
- **Layer**: 2_Application
- **Type**: Core Application Library
- **Framework**: net8.0 (multi-targeting supported)
- **Output Type**: Class Library

## Purpose
Provides the core game engine runtime application that launches and manages game instances. Serves as the main entry point for ALIS applications and integrates all engine subsystems including ECS (Entity Component System), rendering, audio, and physics.

## Key Components

### ECS (Entity Component System)
- **Camera** - 2D/3D camera component
  - Position and resolution management (Vector2F)
  - OnStart/OnExit lifecycle methods
  - Context-aware component
  
- **RigidBody** - Physics body component
- **Sprite** - 2D sprite rendering
- **Animation** - Animation system
- **IAnimator** - Animation controller interface

### Systems
- **Scope System** - Entity scope management

## Dependencies
- [[Alis.Core.Aspect.Fluent]] (6_Ideation) - Fluent components
- [[Alis.Core.Aspect.Logging]] (6_Ideation) - Logging aspect
- [[Alis.Core.Aspect.Math]] (6_Ideation) - Vector2F, Color
- [[Alis.Core.Ecs]] (4_Operation) - ECS systems
- [[Alis.Core.Graphic]] (4_Operation) - Graphics primitives

## Build Configuration
- **LangVersion**: 13
- **Nullable**: disabled (project-specific)
- **AllowUnsafeBlocks**: false

## Platform Support
- Windows
- macOS
- Linux
- Web (via Blazor/WebAssembly)
- Mobile (Android, iOS - planned)

## Testing Status
- **Unit Tests**: Present (Alis.Test)
- **Sample Apps**: Multiple samples included
  - Asteroid game
  - Dino runner
  - Egg game
  - Flappy Bird clone
  - King of the Hill
  - Pong
  - Rogue-like
  - Snake
  - Space Simulator
  - Ruins of Tartarus
  - Split Camera

## Architecture Notes
1. ECS-based game architecture
2. Component-based design with struct components
3. Context-aware components for engine lifecycle
4. Fluent API for component configuration

## Sample Applications
The project includes 11+ sample games demonstrating engine capabilities:
- 2D platformers
- Puzzle games
- Arcade classics
- Simulation games

## Related Projects
- [[Alis.App.Engine]] (1_Presentation) - Engine runtime
- [[Alis.Core.Ecs]] (4_Operation) - ECS implementation
- [[Alis.Core.Graphic]] (4_Operation) - Graphics subsystem

## Documentation Version
Auto-generated from source code analysis. Last updated: 2026-06-08
