---
title: Engine Services Overview
tags:
  - services
  - overview
  - engine
status: Draft
license: GPLv3
---

# Engine Services Overview

## Core Services (Layer 4 - Operation)

| Service | Project | Responsibility |
|---|---|---|
| ECS Service | [[Alis.Core.Ecs]] | Entity-Component-System management |
| Audio Service | [[Alis.Core.Audio]] | Audio playback and mixing |
| Graphic Service | [[Alis.Core.Graphic]] | Graphics rendering pipeline |
| Physic Service | [[Alis.Core.Physic]] | Physics simulation |

## Aspect Services (Layer 6 - Ideation)

| Service | Project | Responsibility |
|---|---|---|
| Data Service | [[Alis.Core.Aspect.Data]] | JSON serialization/deserialization |
| Fluent Service | [[Alis.Core.Aspect.Fluent]] | Fluent API builders |
| Logging Service | [[Alis.Core.Aspect.Logging]] | Configurable logging |
| Math Service | [[Alis.Core.Aspect.Math]] | Mathematical operations |
| Memory Service | [[Alis.Core.Aspect.Memory]] | Asset and memory management |
| Time Service | [[Alis.Core.Aspect.Time]] | Clock and timing |

## Extension Services (Layer 1 - Presentation)

| Service | Project | Responsibility |
|---|---|---|
| Network Service | [[Alis.Extension.Network]] | WebSocket client-server |
| Security Service | [[Alis.Extension.Security]] | Secure types and encryption |
| Profile Service | [[Alis.Extension.Profile]] | Code profiling |
| Updater Service | [[Alis.Extension.Updater]] | Auto-update mechanism |
| Thread Service | [[Alis.Extension.Thread]] | Thread and task management |
| Media Service | [[Alis.Extension.Media.FFmpeg]] | Media encoding/decoding |
| File Dialog Service | [[Alis.Extension.Io.FileDialog]] | Cross-platform file dialogs |
| Translation Service | [[Alis.Extension.Language.Translator]] | Multi-language support |
| Dialogue Service | [[Alis.Extension.Language.Dialogue]] | Branching dialogue trees |

## Graphics Backend Services (Layer 1 - Extension)

| Service | Project | Backend |
|---|---|---|
| SDL2 Graphics | [[Alis.Extension.Graphic.Sdl2]] | SDL2 |
| SFML Graphics | [[Alis.Extension.Graphic.Sfml]] | SFML |
| GLFW Graphics | [[Alis.Extension.Graphic.Glfw]] | GLFW |
| UI Graphics | [[Alis.Extension.Graphic.Ui]] | Dear ImGui |

## Cloud Services (Layer 1 - Extension)

| Service | Project | Provider |
|---|---|---|
| Google Drive | [[Alis.Extension.Cloud.GoogleDrive]] | Google Drive API |
| Dropbox | [[Alis.Extension.Cloud.DropBox]] | Dropbox API |

## Related

- [[Services Index]]
- [[Projects Index]]
- [[Architecture Overview]]
