---
title: Domains Index — ALIS
tags: [index,catalog,reference]
---


## Bounded Contexts

| Domain | Projects | Description | Layer |
|--------|----------|-------------|-------|
| Core Engine | Alis.Core.Ecs, Alis.Core.Graphic, Alis.Core.Audio, Alis.Core.Physic | Fundamental engine capabilities | 4_Operation |
| Aspect Framework | Alis.Core.Aspect.Memory, Fluent, Data, Math, Time, Logging | Cross-cutting concerns via AOP | 6_Ideation |
| Graphics Backends | Alis.Extension.Graphic.Sfml, Glfw, Sdl2, Ui | Platform-specific rendering | 1_Presentation |
| Cloud Services | Alis.Extension.Cloud.DropBox, GoogleDrive | Cloud storage integration | 1_Presentation |
| Language | Alis.Extension.Language.Translator, Dialogue | Multi-language and NPC dialogue | 1_Presentation |
| Math Utilities | Alis.Extension.Math.ProceduralDungeon, HighSpeedPriorityQueue | Specialized math algorithms | 1_Presentation |
| Networking | Alis.Extension.Network | TCP/UDP communication | 1_Presentation |
| Payments | Alis.Extension.Payment.Stripe | Stripe payment processing | 1_Presentation |
| Security | Alis.Extension.Security | Encryption and auth | 1_Presentation |
| System | Alis.Extension.Updater, Profile, Thread | System-level utilities | 1_Presentation |
| Media | Alis.Extension.Media.FFmpeg | Video/audio processing | 1_Presentation |
| Applications | Alis.App.Engine, Hub, Installer | User-facing applications | 1_Presentation |
| Game Samples | Alis.Sample.* (13 games) | Reference implementations | 2_Application |

## Domain Responsibilities

1. **Core Engine**: Entity management, rendering, audio, physics simulation
2. **Aspect Framework**: Cross-cutting concerns (logging, memory, data, math, time, fluent API)
3. **Graphics Backends**: Platform-specific window management and rendering
4. **Cloud Services**: File synchronization with Dropbox and Google Drive
5. **Language**: Translation services and NPC dialogue systems
6. **Math Utilities**: Procedural generation and high-performance data structures
7. **Networking**: Client-server communication with buffer pooling
8. **Payments**: PCI-compliant payment processing via Stripe
9. **Security**: Encryption, authentication, and secure configuration
10. **System**: Application updates, user profiles, thread management
11. **Media**: Video and audio processing via FFmpeg
12. **Applications**: Editor, project management, and installation
13. **Game Samples**: Reference implementations demonstrating engine capabilities

---

## Related Documentation

- [[system/indexes/services-index]] — Service inventory
- [[system/indexes/projects-index]] — Project inventory
- [[architecture/repository-overview]] — Architecture overview
