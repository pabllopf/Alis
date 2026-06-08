# Alis.App.Core

## Overview
Core application library providing base functionality for all ALIS applications and games.

## Project Details
- **Layer**: 2_Application
- **Type**: Application Core Library
- **Framework**: net8.0 / netstandard2.0
- **Purpose**: Base application framework

## Dependencies
- Alis.Core (3_Structuration)
- Alis.Core.Ecs (4_Operation)
- Alis.Core.Graphic (4_Operation)
- Alis.Core.Audio (4_Operation)
- Alis.Core.Physic (4_Operation)

## Key Files
- `Game.cs` — Base game class
- `Application.cs` — Application lifecycle
- `GameLoop.cs` — Game loop implementation

## Notes
- All game samples inherit from this base
- Provides game lifecycle management
- Integrates engine subsystems
