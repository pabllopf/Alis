---
title: Dependency Index
tags:
  - index
  - dependencies
status: Draft
license: GPLv3
---

# Dependency Index

| Project | Depends On | Used By |
|---|---|---|
| Alis.Core.Aspect | - | All layers |
| Alis.Core.Aspect.Data | Alis.Core.Aspect | Alis.Core |
| Alis.Core.Aspect.Fluent | Alis.Core.Aspect | Alis.Core |
| Alis.Core.Aspect.Logging | Alis.Core.Aspect | All layers |
| Alis.Core.Aspect.Math | Alis.Core.Aspect | Alis.Core.Physic, Alis.Core.Graphic |
| Alis.Core.Aspect.Memory | Alis.Core.Aspect | Alis.Core.Ecs |
| Alis.Core.Aspect.Time | Alis.Core.Aspect | Alis.Core.Ecs |
| Alis.Core.Audio | Alis.Core.Aspect | Alis.App.Engine |
| Alis.Core.Ecs | Alis.Core.Aspect | Alis.App.Engine |
| Alis.Core.Graphic | Alis.Core.Aspect | Alis.App.Engine |
| Alis.Core.Physic | Alis.Core.Aspect, Alis.Core.Aspect.Math | Alis.App.Engine |
| Alis.Core | Multiple | Alis (app) |
| Alis.App.Engine | Alis.Core.* | - |
| Alis.App.Hub | - | - |
| Alis.App.Installer | - | - |
| Alis.Extension.Network | Alis.Core.Aspect | Samples |
| Alis.Extension.Security | Alis.Core.Aspect | - |
| Alis.Extension.Graphic.Sdl2 | Alis.Core.Graphic | Samples |
| Alis.Extension.Graphic.Sfml | Alis.Core.Graphic | Samples |
| Alis.Extension.Graphic.Glfw | Alis.Core.Graphic | Samples |
