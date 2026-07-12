---
title: Session Metadata
tags:
  - system
  - metadata
  - session
status: Draft
license: GPLv3
---

# Session Metadata

| Property | Value |
|---|---|
| Repository | Alis |
| Language | C# 13 |
| Framework | .NET 10.0 (multi-target) |
| Total Projects | 140+ |
| Solutions | 11 |
| Architecture | 6-layer clean architecture |
| License | GPLv3 |
| First Generated | 2026-07-12 |
| Last Updated | 2026-07-12 |
| Memory Version | 2.0.0 |

## Module Inventory

| Module | Files | Purpose |
|---|---|---|
| Application Facade | 88 | VideoGame entry point, builders, managers |
| ECS Kernel | 108 | Entity Component System core |
| Physics Engine | 194 | 2D physics (Farseer/Box2D class) |
| Graphics/OpenGL | 147 | OpenGL bindings, BMP loader, platform abstraction |
| Audio | 8 | Cross-platform audio playback |
| Data (JSON) | ~40 | NativeAOT-safe JSON serialization |
| Fluent | ~30 | Builder interfaces, lifecycle contracts |
| Logging | ~60 | Logger system with multiple outputs |
| Math | ~80 | Custom math (vectors, matrices, shapes) |
| Memory | ~10 | Asset registry, embedded resource loading |
| Time | ~5 | Clock/stopwatch utility |
| Extensions | 724 | 19 extension modules |
