# Extension System

tags:
  - concept,theory,documentation

Alis provides 18+ modular extensions organized under `1_Presentation/Extension/` for cross-platform functionality.

## Extension Categories

### Graphics Extensions
| Extension | Purpose |
|-----------|---------|
| `Graphic.Ui` | UI framework and rendering |
| `Graphic.Sfml` | Simple Fast Multimedia Library wrapper |
| `Graphic.Glfw` | OpenGL context management |
| `Graphic.Sdl2` | Simple DirectMedia Layer 2 wrapper |

### Cloud & Storage
| Extension | Purpose |
|-----------|---------|
| `Cloud.DropBox` | Dropbox integration and file sync |
| `Cloud.GoogleDrive` | Google Drive integration |

### Payment & Security
| Extension | Purpose |
|-----------|---------|
| `Payment.Stripe` | Stripe payment processing |
| `Security` | Security abstractions and utilities |

### Network & Communication
| Extension | Purpose |
|-----------|---------|
| `Network` | Network layer abstractions |
| `Thread` | Threading and concurrency utilities |

### I/O Operations
| Extension | Purpose |
|-----------|---------|
| `Io.FileDialog` | Cross-platform file dialog interface |

### Media Processing
| Extension | Purpose |
|-----------|---------|
| `Media.FFmpeg` | FFmpeg multimedia framework wrapper |

### Math & Algorithms
| Extension | Purpose |
|-----------|---------|
| `Math.ProceduralDungeon` | Procedural dungeon generation algorithms |
| `Math.HighSpeedPriorityQueue` | High-performance priority queue implementation |

### Communication & Localization
| Extension | Purpose |
|-----------|---------|
| `Language.Translator` | Translation services and localization |
| `Language.Dialogue` | Dialogue system for games |

### System Management
| Extension | Purpose |
|-----------|---------|
| `Updater` | Application update mechanism |
| `Profile` | User profile management |

### Advertising
| Extension | Purpose |
|-----------|---------|
| `Ads.GoogleAds` | Google Ads integration |

## Extension Architecture

Each extension follows a consistent pattern:
1. **Abstraction layer** - Interface definitions
2. **Implementation layer** - Platform-specific code
3. **Integration** - Integration with main engine

## Extension Registration

Extensions are registered in the dependency injection container:
```csharp
services.AddExtension<GraphicExtension>();
services.AddExtension<CloudExtension>();
```

## See Also
- [[Layered Architecture]]
- [[Solution Composition]]
- [[Alis Architecture Overview]]

## Related
- [[projects/1_Presentation/Extension]] — Extension project docs
- [[Alis.Extension.Graphic.Ui]] — Ui extension
- [[Alis.Extension.Graphic.Sfml]] — SFML extension
- [[Alis.Extension.Network]] — Networking extension
- [[Alis.Extension.Security]] — Security extension
- [[Alis.Extension.Payment.Stripe]] — Payment extension
- [[Alis.Extension.Cloud.DropBox]] — Cloud storage
- [[Multi-Platform Samples]] — Sample game platforms
- [[Platform-Specific Build Constants]] — Platform detection
- [[build-system]] — Build configuration
- [[onboarding/getting-started]] — Adding extensions guide
