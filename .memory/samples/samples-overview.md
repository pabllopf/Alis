---
title: Samples Overview
tags:
  - samples
  - overview
  - demos
status: Draft
license: GPLv3
---

# Samples Overview

The repository contains **49 sample projects** demonstrating engine features:

## Alis Sample Games (13)

Sample game projects living under `2_Application/Alis/samples/`:

| Category | Samples |
|---|---|
| Arcade | Asteroid, Pong, Snake, Flappy Bird |
| Platformer | Dino, King Platform, Split Camera |
| RPG/Roguelike | Rogue, Ruins of Tartarus |
| Simulation | Space Simulator, Inefable |
| Template | Empty |
| Puzzle | Egg |

These samples demonstrate:
- Full game loop integration (ECS + Audio + Graphic + Physic)
- Platform-specific builds (Desktop + Web)
- Asset packing system

## Extension Samples (30)

Each extension project includes a sample project demonstrating its API:

| Area | Samples |
|---|---|
| Graphics | SDL2, SFML, GLFW, UI (4) |
| Cloud | GoogleDrive, DropBox (2) |
| Payment | Stripe (1) |
| Ads | GoogleAds (1) |
| Media | FFmpeg (1) |
| IO | FileDialog (1) |
| Language | Dialogue, Translator (2) |
| Math | HighSpeedPriorityQueue, ProceduralDungeon (2) |
| Network | SimpleChat, SimpleGame, ConsoleGame (6) |
| Security | Security (1) |
| Thread | Thread (1) |
| Profile | Profile (1) |
| Updater | Updater (1) |
| Core* | Core, ECS, Audio, Graphic, Physic, Aspect, Data, Fluent, Logging, Math, Memory, Time (12) |

## Network Samples (6)

| Project | Path |
|---|---|
| SimpleChat Client | `1_Presentation/Extension/Network/samples/SimpleChat/client/` |
| SimpleChat Server | `1_Presentation/Extension/Network/samples/SimpleChat/server/` |
| SimpleGame Client | `1_Presentation/Extension/Network/samples/SimpleGame/client/` |
| SimpleGame Server | `1_Presentation/Extension/Network/samples/SimpleGame/server/` |
| ConsoleGame Client | `1_Presentation/Extension/Network/samples/ConsoleGame/client/` |
| ConsoleGame Server | `1_Presentation/Extension/Network/samples/ConsoleGame/server/` |

## Multi-Platform Support

All sample projects build for:
- Windows (x64, x86, arm64)
- macOS (x64, arm64)
- Linux (x64, arm64, arm)
- Web (WASM)
- Android (arm64, x64)
- iOS (arm64, simulator)

## Related

- [[Samples Index]]
- [[Alis]]
- [[Projects Index]]
