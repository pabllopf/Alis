---
title: Presentation Domain
tags:
  - domain
  - presentation
  - application
  - engine
  - hub
status: Draft
license: GPLv3
---

# Presentation Domain

## Overview

Top-level application layer containing the game engine apps, IDE hub, installer, benchmark, and 19 extension modules.

## Layer

**Layer:** 1_Presentation
**Path:** `1_Presentation/`
**Projects:** 4 apps + 1 benchmark + 19 extensions

## Applications

### Alis.App.Engine
- **Type:** Console app (net8.0)
- **Purpose:** Standalone game engine runtime
- **Dependencies:** Alis, Alis.Extension.Graphic.Ui, Alis.Extension.Updater, Alis.Extension.Io.FileDialog
- **Features:** Asset packing, platform-specific bundles (macOS .app/.dmg, Linux .zip, Windows .zip)

### Alis.App.Hub
- **Type:** Desktop app
- **Purpose:** IDE/project hub for managing games
- **Dependencies:** Alis (auto-builds Engine and Installer)
- **Features:** Project management, editor integration

### Alis.App.Installer
- **Type:** Desktop app
- **Purpose:** Game installer/packaging
- **Dependencies:** Alis
- **Features:** Installation wizard, file deployment

### Alis.Benchmark
- **Type:** Benchmark app
- **Purpose:** Performance comparisons
- **Dependencies:** Alis only (Release config)
- **Benchmarks:** Class vs struct, collections, ECS iteration, interfaces, loops

## Extensions

| Extension | Category | Purpose |
|---|---|---|
| Network | Communication | WebSocket server/client (RFC 6455) |
| Security | Cryptography | Secure random value wrappers |
| Profile | Monitoring | Profiling and resource monitoring |
| Thread | Parallelism | Parallel ECS update execution |
| Updater | Distribution | GitHub-based auto-update |
| Graphic.Ui | Graphics | UI rendering components |
| Graphic.Sdl2 | Graphics | SDL2 bindings |
| Graphic.Sfml | Graphics | SFML bindings |
| Graphic.Glfw | Graphics | GLFW bindings |
| Io.FileDialog | I/O | Native file dialog |
| Language.Dialogue | Language | Dialog tree system |
| Language.Translator | Language | Internationalization |
| Math.HighSpeedPriorityQueue | Math | Priority queue data structure |
| Math.ProceduralDungeon | Math | Procedural dungeon generation |
| Media.FFmpeg | Media | FFmpeg media processing |
| Payment.Stripe | Payment | Stripe payment integration |
| Ads.GoogleAds | Advertising | Google Ads integration |
| Cloud.GoogleDrive | Cloud | Google Drive storage |
| Cloud.DropBox | Cloud | DropBox storage |

## Dependencies

- All Presentation projects depend on: `2_Application/Alis`
- Extension projects are independent of each other
- Generator references flow from higher to lower layers

## Related

- [[Alis.App.Engine]]
- [[Alis.App.Hub]]
- [[Alis.App.Installer]]
- [[Alis.Benchmark]]
