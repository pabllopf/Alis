# Alis - Extension Catalog

## Overview
The Alis framework provides 25+ extensions organized into 12 categories. Each extension follows the src/sample/test pattern.

## Extension Categories

### Graphic Extensions (4)
| Extension | Project | Files | Purpose |
|-----------|---------|-------|---------|
| **SDL2** | Alis.Extension.Graphic.Sdl2 | 179 | SDL2 bindings, windowing, input, image/TTF support |
| **GLFW** | Alis.Extension.Graphic.Glfw | - | GLFW bindings, context creation, input processing |
| **SFML** | Alis.Extension.Graphic.Sfml | - | SFML wrappers for 2D rendering, audio, windows |
| **UI** | Alis.Extension.Graphic.Ui | 251 | UI framework, GuizMo, Node system, Plot, Fonts |

**Namespace:** `Alis.Extension.Graphic.*`
**Dependencies:** Alis (app core), 4_Operation/Ecs, 4_Operation/Graphic
**External:** SDL2, GLFW, SFML native libraries

### Network Extension (1)
| Extension | Project | Files | Purpose |
|-----------|---------|-------|---------|
| **Network** | Alis.Extension.Network | 303 | Client/server architecture, protocols, multiplayer |

**Namespace:** `Alis.Extension.Network`
**Sub-structure:** Client/, Core/, Exceptions/, Internal/, Server/
**Samples:** ConsoleGame, SimpleChat, SimpleGame (each with client/server)

### Media Extension (1)
| Extension | Project | Files | Purpose |
|-----------|---------|-------|---------|
| **FFmpeg** | Alis.Extension.Media.FFmpeg | 276 | Audio/video encoding, decoding, stream handling |

**Namespace:** `Alis.Extension.Media.FFmpeg`
**Sub-structure:** Audio/Models/, BaseClasses/, Encoding/Builders/, Video/Models/
**External:** FFmpeg binaries

### Cloud Extensions (2)
| Extension | Project | External Package | Purpose |
|-----------|---------|-----------------|---------|
| **DropBox** | Alis.Extension.Cloud.DropBox | Dropbox.Api v7.0.0 | Cloud file sync, remote asset access |
| **GoogleDrive** | Alis.Extension.Cloud.GoogleDrive | Google.Apis.Drive.v3 v1.68.0.3601 | Cloud persistence, content sharing |

**Namespace:** `Alis.Extension.Cloud.*`
**Dependencies:** Alis (app core)

### Language Extensions (2)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **Translator** | Alis.Extension.Language.Translator | Multilingual interfaces, localization |
| **Dialogue** | Alis.Extension.Language.Dialogue | Structured conversations, branching text |

**Namespace:** `Alis.Extension.Language.*`
**Translator sub-structure:** Abstractions/, Cache/, Pluralization/, Providers/
**Dialogue sub-structure:** Core/

### Math Extensions (2)
| Extension | Project | Files | Purpose |
|-----------|---------|-------|---------|
| **ProceduralDungeon** | Alis.Extension.Math.ProceduralDungeon | 215 | Procedural dungeon generation, level layouts |
| **HighSpeedPriorityQueue** | Alis.Extension.Math.HighSpeedPriorityQueue | - | High-performance priority queue |

**Namespace:** `Alis.Extension.Math.*`
**ProceduralDungeon sub-structure:** Helpers/, Interfaces/, Models/, Services/, Validators/
**Dependencies:** Alis (app core), 6_Ideation/Math

### Payment Extension (1)
| Extension | Project | External Package | Purpose |
|-----------|---------|-----------------|---------|
| **Stripe** | Alis.Extension.Payment.Stripe | Stripe.net v49.2.0 | Secure payment processing, commerce |

**Namespace:** `Alis.Extension.Payment.Stripe`
**Dependencies:** Alis (app core)

### Ads Extension (1)
| Extension | Project | External Package | Purpose |
|-----------|---------|-----------------|---------|
| **GoogleAds** | Alis.Extension.Ads.GoogleAds | Google.Ads.Common v9.5.3 | Ad monetization for games/apps |

**Namespace:** `Alis.Extension.Ads.GoogleAds`
**Dependencies:** Alis (app core)

### I/O Extension (1)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **FileDialog** | Alis.Extension.Io.FileDialog | Native file dialog integration |

**Namespace:** `Alis.Extension.Io.FileDialog`
**Dependencies:** Alis (app core)

### Profile Extension (1)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **Profile** | Alis.Extension.Profile | Player settings, user metadata, profiling |

**Namespace:** `Alis.Extension.Profile`
**Sub-structure:** Builders/, Factories/, Helpers/, Implementations/, Interfaces/, Models/, Utilities/
**Dependencies:** Alis (app core)

### Security Extension (1)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **Security** | Alis.Extension.Security | Protection, hardening, secure data handling |

**Namespace:** `Alis.Extension.Security`
**Dependencies:** Alis (app core)

### Thread Extension (1)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **Thread** | Alis.Extension.Thread | Thread pooling, scheduling, concurrency |

**Namespace:** `Alis.Extension.Thread`
**Sub-structure:** Attributes/, Builder/, Configuration/, Core/, Execution/, Integration/, Interfaces/, Scheduling/, Strategies/
**Dependencies:** Alis (app core)

### Updater Extension (1)
| Extension | Project | Purpose |
|-----------|---------|---------|
| **Updater** | Alis.Extension.Updater | Version upgrades, update delivery |

**Namespace:** `Alis.Extension.Updater`
**Sub-structure:** Events/, Services.Api/, Services.Files/
**Dependencies:** Alis (app core)

## Extension Dependency Summary

### Extensions with External Dependencies
| Extension | External Package | Version |
|-----------|-----------------|---------|
| Payment.Stripe | Stripe.net | 49.2.0 |
| Ads.GoogleAds | Google.Ads.Common | 9.5.3 |
| Cloud.GoogleDrive | Google.Apis.Drive.v3 | 1.68.0.3601 |
| Cloud.DropBox | Dropbox.Api | 7.0.0 |
| Graphic.Sdl2 | SDL2 bindings | Native |
| Graphic.Glfw | GLFW bindings | Native |
| Graphic.Sfml | SFML bindings | Native |
| Media.FFmpeg | FFmpeg binaries | Native |

### Extensions with Internal Dependencies
| Extension | Internal Dependencies |
|-----------|----------------------|
| Graphic.Ui | 4_Operation/Ecs, 4_Operation/Graphic |
| Math.ProceduralDungeon | 6_Ideation/Math |
| All others | 2_Application/Alis (app core) only |

## Extension File Count Summary
| Rank | Extension | Est. .cs Files |
|------|-----------|----------------|
| 1 | Network | 303 |
| 2 | Media.FFmpeg | 276 |
| 3 | Graphic.Ui | 251 |
| 4 | Graphic.Sdl2 | 179 |
| 5 | Math.ProceduralDungeon | 215 |
| 6 | Thread | ~100+ |
| 7 | Profile | ~80+ |
| 8 | Language.Translator | ~60+ |
| 9 | All others | ~20-50 each |
