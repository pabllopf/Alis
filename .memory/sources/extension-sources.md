---
title: Extension Sources
tags:
  - source
  - reference
  - documentation

status: draft

license: GPLv3
---


18+ modular extensions in `1_Presentation/Extension/`.

## Extension Categories

### Graphics Extensions

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Graphic.Ui** | 50+ | UI framework and rendering |
| **Graphic.Sfml** | 40+ | Simple Fast Multimedia Library wrapper |
| **Graphic.Glfw** | 30+ | OpenGL context management |
| **Graphic.Sdl2** | 45+ | Simple DirectMedia Layer 2 wrapper |

### Cloud & Storage

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Cloud.DropBox** | 25+ | Dropbox integration and file sync |
| **Cloud.GoogleDrive** | 20+ | Google Drive integration |

### Payment & Security

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Payment.Stripe** | 30+ | Stripe payment processing |
| **Security** | 25+ | Security abstractions and utilities |

### Network & Communication

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Network** | 35+ | Network layer abstractions |
| **Thread** | 20+ | Threading and concurrency utilities |

### I/O Operations

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Io.FileDialog** | 15+ | Cross-platform file dialog interface |

### Media Processing

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Media.FFmpeg** | 40+ | FFmpeg multimedia framework wrapper |

### Math & Algorithms

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Math.ProceduralDungeon** | 35+ | Procedural dungeon generation algorithms |
| **Math.HighSpeedPriorityQueue** | 20+ | High-performance priority queue implementation |

### Communication & Localization

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Language.Translator** | 25+ | Translation services and localization |
| **Language.Dialogue** | 30+ | Dialogue system for games |

### System Management

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Updater** | 15+ | Application update mechanism |
| **Profile** | 20+ | User profile management |

### Advertising

| Extension | Files | Purpose |
|-----------|-------|---------|
| **Ads.GoogleAds** | 20+ | Google Ads integration |

## Extension Source Pattern

```csharp
public class GraphicExtension : IExtension
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGraphicsRenderer<SfmlGraphicsRenderer>();
        services.AddGraphicsRenderer<GlfwGraphicsRenderer>();
    }
}
```

## See Also
- [[Layered Architecture]]
- [[Extension System]]
- [[Multi-Platform Samples]]
