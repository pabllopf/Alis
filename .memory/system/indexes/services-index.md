# Services Index — ALIS

tags:
  - index,catalog,reference

## Core Engine Services

| Service | Project | Layer | Description |
|---------|---------|-------|-------------|
| ECS Engine | Alis.Core.Ecs | 4_Operation | Entity Component System with archetype storage |
| Graphics Renderer | Alis.Core.Graphic | 4_Operation | 2D/3D rendering with shaders, textures, meshes |
| Audio Player | Alis.Core.Audio | 4_Operation | Cross-platform audio playback |
| Physics Engine | Alis.Core.Physic | 4_Operation | 2D physics with collision detection, joints, controllers |

## Aspect Services

| Service | Project | Layer | Description |
|---------|---------|-------|-------------|
| Asset Registry | Alis.Core.Aspect.Memory | 6_Ideation | ZIP-based asset management with dual-cache |
| Fluent Builder | Alis.Core.Aspect.Fluent | 6_Ideation | Builder API with 120+ marker interfaces |
| JSON Serializer | Alis.Core.Aspect.Data | 6_Ideation | Custom AOT-compatible JSON parser |
| Math Library | Alis.Core.Aspect.Math | 6_Ideation | Value-type vectors, matrices, shapes |
| Time Service | Alis.Core.Aspect.Time | 6_Ideation | High-resolution clock |
| Logging Pipeline | Alis.Core.Aspect.Logging | 6_Ideation | Structured logging with pluggable filters |

## Extension Services

| Service | Project | Layer | Category |
|---------|---------|-------|----------|
| Google Ads | Alis.Extension.Ads.GoogleAds | 1_Presentation | Ads |
| Security | Alis.Extension.Security | 1_Presentation | Security |
| Stripe Payments | Alis.Extension.Payment.Stripe | 1_Presentation | Payment |
| Networking | Alis.Extension.Network | 1_Presentation | Network |
| File Dialog | Alis.Extension.Io.FileDialog | 1_Presentation | I/O |
| Self-Updater | Alis.Extension.Updater | 1_Presentation | System |
| Translation | Alis.Extension.Language.Translator | 1_Presentation | Language |
| NPC Dialogue | Alis.Extension.Language.Dialogue | 1_Presentation | Language |
| Dungeon Generation | Alis.Extension.Math.ProceduralDungeon | 1_Presentation | Math |
| Priority Queue | Alis.Extension.Math.HighSpeedPriorityQueue | 1_Presentation | Math |
| ImGui UI | Alis.Extension.Graphic.Ui | 1_Presentation | Graphics |
| SFML Backend | Alis.Extension.Graphic.Sfml | 1_Presentation | Graphics |
| GLFW Backend | Alis.Extension.Graphic.Glfw | 1_Presentation | Graphics |
| SDL2 Backend | Alis.Extension.Graphic.Sdl2 | 1_Presentation | Graphics |
| User Profile | Alis.Extension.Profile | 1_Presentation | System |
| Dropbox Storage | Alis.Extension.Cloud.DropBox | 1_Presentation | Cloud |
| Google Drive | Alis.Extension.Cloud.GoogleDrive | 1_Presentation | Cloud |
| Thread Pool | Alis.Extension.Thread | 1_Presentation | System |
| FFmpeg Media | Alis.Extension.Media.FFmpeg | 1_Presentation | Media |

## Application Services

| Service | Project | Layer | Description |
|---------|---------|-------|-------------|
| Game Engine | Alis.App.Engine | 1_Presentation | Main engine/editor |
| Project Hub | Alis.App.Hub | 1_Presentation | Project management |
| Installer | Alis.App.Installer | 1_Presentation | Installation wizard |
| Core App | Alis | 2_Application | Core application framework |

---

## Related Documentation

- [[system/indexes/projects-index]] — Complete project inventory
- [[system/indexes/handlers-index]] — Handler patterns
- [[system/indexes/domains-index]] — Bounded contexts
