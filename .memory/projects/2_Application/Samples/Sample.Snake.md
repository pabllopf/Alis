---
title: Alis.Sample.Snake
tags:
  - application
  - sample
  - documentation

status: Draft

license: GPLv3

---


## Overview
Classic Snake game built on the ALIS engine. Minimal boilerplate — demonstrates the simplest possible game setup using `VideoGame.Create().Run()` with zero configuration.

## Project Details
- **Layer**: 2_Application
- **Type**: Game Sample
- **Framework**: `net10.0`
- **Platforms**: Desktop, Web
- **Purpose**: Educational/reference — minimal engine bootstrap

## Platform Variants
| Platform | Project File |
|---|---|
| Desktop | `Alis.Sample.Snake.Desktop.csproj` |
| Web | `Alis.Sample.Snake.Web.csproj` |

## Scene Structure
- **Minimal**: No explicit scene setup in `Program.cs`
- Single call: `VideoGame.Create().Run()` — all defaults

## Dependencies
- [[projects/2_Application/Alis]] (Core application library)
- `Alis.Core.Ecs.Systems` — VideoGame

## Notes
- Most minimal sample — showcase of absolute minimum code to start an ALIS game
- Gameplay logic likely in separate script files (not in `Program.cs`)
- Demonstrates that ALIS engine works with zero-configuration bootstrap
- All settings use engine defaults (resolution, physics, audio)
