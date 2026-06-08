# Alis.App.Engine

## Overview
The main game engine runtime application. Launches and manages game instances.

## Project Details
- **Layer**: 1_Presentation
- **Type**: Application (Desktop)
- **Framework**: net8.0
- **Purpose**: Game engine executable

## Dependencies
- Alis.App.Core (2_Application)
- Alis.Core (3_Structuration)
- All extensions used by the engine

## Key Files
- `Program.cs` — Engine entry point
- `App.xaml` / `MainWindow.xaml` — WPF/UWP UI (if applicable)
- `Engine.cs` — Engine lifecycle management

## Notes
- Entry point for game execution
- Loads game assemblies dynamically
- Manages engine lifecycle (init, run, shutdown)
